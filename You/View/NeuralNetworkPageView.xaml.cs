using System;
using System.Collections.Generic;
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
using System.Globalization;

namespace You.View
{
    /// <summary>
    /// Логика взаимодействия для NeuralNetworkPageView.xaml
    /// </summary>
    public partial class NeuralNetworkPageView : UserControl
    {
       public const int hoursInDay = 24;
        public NeuralNetworkPageView()
        {
            GregorianCalendar gregorianCalendar = new GregorianCalendar();//КАЛЕНДАРЬ
            DateTime dateTime = DateTime.Now;//ТЕКУЩАЯ ДАТА
            int daysInMonth = gregorianCalendar.GetDayOfMonth(dateTime);//ПОЛУЧАЕМ ЗНАЧЕНИЕ ТЕКУЩЕЙ ДНЯ В МЕСЯЦЕ


            int hours = DateTime.Now.Hour;
            DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
            int hoursInWeek = (int)dayOfWeek == 0 ? 6 * hoursInDay : ((byte)(dayOfWeek-1)) * hoursInDay;
            int bypher = (int)Settings.Default["CountGoodHoursInWeek"];
            int porcent = (bypher * 100) / (hoursInWeek + hours);


            int hoursInMonth = (daysInMonth-1) * hoursInDay;
            bypher = (int)Settings.Default["CountGoodHoursInMonth"];
            int porcentMonth = (bypher * 100) / (hoursInMonth + hours);


            InitializeComponent();
            DataContext = new NeuralNetworkViewModel("Твой показатель", porcent, porcentMonth);
            AllResultNumber.Content = hoursInWeek + hours;
            SuccessfullyResultNumber.Content = (int)Settings.Default["CountGoodHoursInWeek"];
            BadResultNumber.Content = hoursInWeek + hours - (int)Settings.Default["CountGoodHoursInWeek"];

            AllResultNumberMonth.Content = hoursInMonth + hours;
            SuccessfullyResultNumberMonth.Content = (int)Settings.Default["CountGoodHoursInMonth"];
            BadResultNumberMonth.Content = hoursInMonth + hours - (int)Settings.Default["CountGoodHoursInMonth"];
            Label[] labelsName = new Label[] { nameOne, nameTwo, nameThree };
            Label[] labelsClock = new Label[] { clockOne, clockTwo, clockThree };
            Top(Path.currentWeek, labelsName, labelsClock); // 3  ЛЕЙБЛА КОТОРЫЕ БУДУТ ЗАПОЛНЕНЫ
            labelsName = new Label[] { name1, name2, name3, name4, name5 };
            labelsClock = new Label[] { clock1, clock2, clock3, clock4, clock5 };
            Top(Path.currentMonth, labelsName, labelsClock); // 5  ЛЕЙБЛОВ КОТОРЫЕ БУДУТ ЗАПОЛНЕНЫ
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowKnowMore windowKnowMore = new WindowKnowMore(Path.currentWeek);
            windowKnowMore.Show();
        }
        private void Top(string path, Label[] labelsName, Label[] labelsClock)
        {
            int sizeV = File.ReadAllLines(path).Where(x => x != "").Count();
            byte sizeG = 2;
            int sizeR = sizeV / sizeG;
            string[] name = new string[0];
            int[] clock = new int[0];
            Array.Resize(ref name, sizeR);
            Array.Resize(ref clock, sizeR);
            string[] full = File.ReadAllLines(path, Encoding.Default).Take(sizeV).ToArray();
            for (int i = 0; i < sizeV / sizeG; i++)
            {
                for (byte j = 0; j < sizeG; j++)
                {
                    switch (j)
                    {
                        case 0:
                            name[i] = full[i * sizeG + j];
                            break;
                        case 1:
                            clock[i] = int.Parse(full[i * sizeG + j]);
                            break;
                    }
                }
            }
            //ЗДЕСЬ НУЖНО ОТСОРТИРОВАТЬ, ЧТОБЫ НАЗВАНИЯ БЫЛИ ОДИНАКОВЫЕ
            //ТОГДА МОЖНО ПРОДОЛЖАТЬ ВСЁ ДАЛЬШЕ ПО СПИСКУ
            //===================================================================================
            string[] nameAssorted = new string[0];
            int[] clockAssorted = new int[0];
            for (int i = 0; i < name.Length; i++)
            {
                if (!nameAssorted.Contains(name[i]))
                {
                    Array.Resize(ref nameAssorted, nameAssorted.Length + 1);
                    Array.Resize(ref clockAssorted, clockAssorted.Length + 1);
                    for (int j = i; j < name.Length; j++)
                    {
                        if (name[i] == name[j])
                        {
                            clockAssorted[clockAssorted.Length-1] += clock[j];
                            nameAssorted[nameAssorted.Length-1] = name[i];
                        }
                    }
                }               
            }
            //===================================================================================УСПЕШНО
            var myTuple = WindowKnowMore.Corteg(clockAssorted, nameAssorted);
            int masSize = labelsName.Length;
            if (labelsName.Length > nameAssorted.Length) masSize = nameAssorted.Length;
            for (byte i = 0; i < masSize; i++)
            {
                labelsName[i].Content = myTuple.Item2[i] + ": ";
                labelsClock[i].Content = myTuple.Item1[i];
            }
        }

        private void ButtonMonth_Click(object sender, RoutedEventArgs e)
        {
            WindowKnowMore windowKnowMore = new WindowKnowMore(Path.currentMonth);
            windowKnowMore.Show();
        }
    }
    public class ChartEffect
    {
        public int Porcent { set; get; }
        public string String { set; get; }
    }
}
