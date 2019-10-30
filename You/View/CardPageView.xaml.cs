using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using You.Properties;
using You.ViewModel;

namespace You.View
{
    /// <summary>
    /// Логика взаимодействия для CardPageView.xaml
    /// </summary>
    public partial class CardPageView : UserControl
    {
        public string NameCard { get; set; }
        public CardPageView()
        {
            InitializeComponent();
            DataContext = new CardViewModel();
        }
        
        private void OutCard_Click(object sender, RoutedEventArgs e)
        {
           var response = MessageBox.Show("Вы действительно желаете удалить элемент?", "Ощистить?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
           if (response == MessageBoxResult.Yes)
            {
            int sizeV = File.ReadAllLines(@"grids.txt").Where(x => x != "").Count();
            byte sizeG = 2;
            int sizeR = sizeV / sizeG;
            Array.Resize(ref Resource.name, sizeR);
            Array.Resize(ref Resource.clock, sizeR);
            string[] full = File.ReadAllLines(@"grids.txt", Encoding.Default).Take(sizeV).ToArray();
            for (int i = 0; i < sizeR; i++)
            {
                for (byte j = 0; j < sizeG; j++)
                {
                    switch (j)
                    {
                        case 0:
                            Resource.name[i] = full[i * sizeG + j];
                            break;
                        case 1:
                            Resource.clock[i] = int.Parse(full[i * sizeG + j]);
                            break;
                    }
                }
            }
            File.WriteAllText(@"grids.txt", string.Empty);
            for (int i = 0; i < sizeR; i++)
            {
                if (Resource.name[i] == NameCardText.Content.ToString())
                {
                    for (int j = i; j < sizeR - 1; j++)
                    {
                        Resource.name[j] = Resource.name[j + 1];
                        Resource.clock[j] = Resource.clock[j + 1];
                    }
                    Array.Resize(ref Resource.name, sizeR - 1);
                    Array.Resize(ref Resource.clock, sizeR - 1);                  
                    using (StreamWriter sw = new StreamWriter(@"grids.txt", true, Encoding.Default))
                    {
                        for (int j=0; j<Resource.name.Length;j++)
                        {
                            sw.WriteLine(Resource.name[j]);
                            sw.WriteLine(Resource.clock[j]);
                        }
                        sw.Close();
                    }
                    MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                    window.mainGrid.Children.Clear();
                    window.mainGrid.Children.Add(new SectionsPageView());
                    break;
                }
            }
            }

        }
        //ДОБАВЛЕНИЕ ДОСТИЖЕНИЯ
        private void ADDVictoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (ADDVictoryTextBox.Text == "")
            {
                MessageBox.Show("Параметр пуст!");
            }
            else
            {
            string time_Now = DateTime.Now.ToShortDateString();
            Random random = new Random();
            int ochko = random.Next(1,8);
            using (StreamWriter sw = new StreamWriter(@"VictoryUser.txt", true, Encoding.Default))
            {
                sw.WriteLine(NameCardText.Content.ToString());
                sw.WriteLine(ADDVictoryTextBox.Text.ToString());
                sw.WriteLine(ochko.ToString());
                sw.WriteLine(time_Now);
                sw.Close();
            }
            ADDVictoryTextBox.Text = "";
            int bypher = (int)Settings.Default["ScoreCount"];
            Settings.Default["ScoreCount"] = bypher + ochko;
            bypher = (int)Settings.Default["ProgressCount"];
            Settings.Default["ProgressCount"] = bypher + 1;
            Settings.Default.Save();
            MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            window.ScoreCount.Content = (int)Settings.Default["ScoreCount"];
            window.ProgressCount.Content = (int)Settings.Default["ProgressCount"];
            }

        }
        /// <summary>
        /// КАРТОЧКА ОТДЕЛЬНОГО УВЛЕЧЕНИЯ : НАЖАТИЕ КНОПКИ ДОБАВЛЕНИЯ ЧАСОВ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ADDClockButton_Click(object sender, RoutedEventArgs e)
        {
            int hours = DateTime.Now.Hour;
            DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
            int hoursInWeek = (int)dayOfWeek == 0 ? 6 * NeuralNetworkPageView.hoursInDay : ((byte)(dayOfWeek-1)) * NeuralNetworkPageView.hoursInDay;

            GregorianCalendar gregorianCalendar = new GregorianCalendar();//КАЛЕНДАРЬ
            DateTime dateTime = DateTime.Now;//ТЕКУЩАЯ ДАТА
            int daysInMonth = gregorianCalendar.GetDayOfMonth(dateTime);//ПОЛУЧАЕМ ЗНАЧЕНИЕ ТЕКУЩЕЙ ДНЯ В МЕСЯЦЕ
            int hoursInMonth = (daysInMonth - 1) * NeuralNetworkPageView.hoursInDay;

            try
            {
                if (ADDClockTextBox.Text != "")
                {
                    try
                    {
                        byte.Parse(ADDClockTextBox.Text.ToString());
                    }
                    catch (FormatException)
                    {
                        ADDClockTextBox.Text = "";
                        MessageBox.Show("Строка имела неверный формат!");
                    }
                }
            }
            catch (OverflowException)
            {
                ADDClockTextBox.Text = "";
                MessageBox.Show("Ошибка \n Слишком большие числа!\rПодсказка: Внесите частями! ");
            }
            if (ADDClockTextBox.Text == "")
            {
                MessageBox.Show("Некоторые параметры пусты!");
            }
            else if (byte.Parse(ADDClockTextBox.Text.ToString()) > 24)
            {
                MessageBox.Show("В сутках 24 часа!\r Не более!");
            }
            else if (((((int)Settings.Default["CountGoodHoursInWeek"] + byte.Parse(ADDClockTextBox.Text.ToString())) * 100) / (hoursInWeek + hours)) >= 100)
            {
                MessageBox.Show("Количество часов занятий превышает количество всех часов за неделю!");
            }
            else if (((((int)Settings.Default["CountGoodHoursInMonth"] + byte.Parse(ADDClockTextBox.Text.ToString())) * 100) / (hoursInMonth + hours)) >= 100)
            {
                MessageBox.Show("Количество часов занятий превышает количество всех часов за месяц!");
            }
            else
            {
            int sizeV = File.ReadAllLines(@"grids.txt").Where(x => x != "").Count();
            byte sizeG = 2;
            int sizeR = sizeV / sizeG;
            Array.Resize(ref Resource.name, sizeR);
            Array.Resize(ref Resource.clock, sizeR);
            string[] full = File.ReadAllLines(@"grids.txt", Encoding.Default).Take(sizeV).ToArray();
            for (int i = 0; i < sizeR; i++)
            {
                for (byte j = 0; j < sizeG; j++)
                {
                    switch (j)
                    {
                        case 0:
                            Resource.name[i] = full[i * sizeG + j];
                            break;
                        case 1:
                            Resource.clock[i] = int.Parse(full[i * sizeG + j]);
                            break;
                    }
                }
            }
            File.WriteAllText(@"grids.txt", string.Empty);//ОЧИЩАЕМ ФАЙЛ grids.txt
            for (int i = 0; i < sizeR; i++)
            {
                if (Resource.name[i] == NameCardText.Content.ToString())
                {
                    Resource.clock[i] += byte.Parse(ADDClockTextBox.Text.ToString());

                    using (StreamWriter sw = new StreamWriter(@"grids.txt", true, Encoding.Default))
                    {
                        for (int j = 0; j < sizeR; j++)
                        {
                            sw.WriteLine(Resource.name[j]);
                            sw.WriteLine(Resource.clock[j]);
                        }
                        sw.Close();
                    }
                    //ЗАПИСЬ В ФАЙЛ ТЕКУЩЕЙ НЕДЕЛИ
                        using (StreamWriter sw = new StreamWriter(@"CurrentWeek.txt", true, Encoding.Default))
                        {
                            sw.WriteLine(Resource.name[i]);
                            sw.WriteLine(ADDClockTextBox.Text.ToString());
                            sw.Close();
                        }
                        //ЗАПИСЬ В ФАЙЛ ТЕКУЩЕГО МЕСЯЦА
                        using (StreamWriter sw = new StreamWriter(@"CurrentMonth.txt", true, Encoding.Default))
                        {
                            sw.WriteLine(Resource.name[i]);
                            sw.WriteLine(ADDClockTextBox.Text.ToString());
                            sw.Close();
                        }
                        int bypher = (int)Settings.Default["CountGoodHoursInWeek"];
                        Settings.Default["CountGoodHoursInWeek"] = bypher + byte.Parse(ADDClockTextBox.Text.ToString());
                        bypher = (int)Settings.Default["CountGoodHoursInMonth"];
                        Settings.Default["CountGoodHoursInMonth"] = bypher + byte.Parse(ADDClockTextBox.Text.ToString());
                        Settings.Default.Save();

                    MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                    window.mainGrid.Children.Clear();
                    window.mainGrid.Children.Add(new SectionsPageView());
                    break;
                }
            }
            }                 
        }
    }
}
