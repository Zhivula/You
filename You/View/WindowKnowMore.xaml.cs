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
using System.Windows.Shapes;
using You.Properties;
using You.ViewModel;

namespace You.View
{
    /// <summary>
    /// Логика взаимодействия для WindowKnowMore.xaml
    /// </summary>
    public partial class WindowKnowMore : Window
    {
        public WindowKnowMore(string Path)
        {
            int sizeV = File.ReadAllLines(Path).Where(x => x != "").Count();
            byte sizeG = 2;
            int sizeR = sizeV / sizeG;
            string[] name = new string[0];
            int[] clock = new int[0];
            Array.Resize(ref name, sizeR);
            Array.Resize(ref clock, sizeR);
            string[] full = File.ReadAllLines(Path, Encoding.Default).Take(sizeV).ToArray();
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
            
            InitializeComponent();
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
                            clockAssorted[clockAssorted.Length - 1] += clock[j];
                            nameAssorted[nameAssorted.Length - 1] = name[i];
                        }
                    }
                }
            }
            var myTuple = Corteg(clockAssorted, nameAssorted);
            Start(nameAssorted.Length, myTuple.Item2, myTuple.Item1);
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Start(int sizeV, string[] name, int[] clock)
        {
            Grid gridName = new Grid();
            Grid gridCount = new Grid();
            gridName.Height = sizeV * 35;//ВЫСОТА ПОД ОДИН "СЛОЙ" НЕСКОЛЬКИХ Grid 
            gridCount.Height = sizeV * 35;//ВЫСОТА ПОД ОДИН "СЛОЙ" НЕСКОЛЬКИХ Grid 
            for (int i = 0; i < sizeV; i++) gridName.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < sizeV; i++) gridCount.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < sizeV; i++)
            {
                Label label = new Label();
                label.Content = name[i];
                Thickness thickness = new Thickness(20, 0, 0, 0);// УСТАНОВКА margin
                label.Margin = thickness;                     //
                SolidColorBrush solidColorBrush = new SolidColorBrush();
                solidColorBrush.Color = Color.FromRgb(150, 150, 150);
                label.Foreground = solidColorBrush;
                Grid.SetRow(label, i);
                gridName.Children.Add(label);
            }
            for (int i = 0; i < sizeV; i++)
            {
                Label label = new Label();
                label.Content = clock[i];
                Thickness thickness = new Thickness(20, 0, 0, 0);// УСТАНОВКА margin
                label.Margin = thickness;                     //
                SolidColorBrush solidColorBrush = new SolidColorBrush();
                solidColorBrush.Color = Color.FromRgb(150, 150, 150);
                label.Foreground = solidColorBrush;
                Grid.SetRow(label, i);
                gridCount.Children.Add(label);
            }
            GridCount.Children.Add(gridCount);
            GridName.Children.Add(gridName);
        }
        /// <summary>
        /// МЕТОДА РЕАЛИЗАЦИИ ПУЗЫРЬКА 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="clock"></param>
       public static Tuple<int[], string[]> Corteg(int[] clock, string[] name)
        {
            int bypherClock = 0;
            string bypherName = string.Empty;
            for (int i = 0; i < name.Length; i++)
            {
                for (int j = 0; j < name.Length - i - 1; j++)
                {
                    if (clock[j] > clock[j + 1])
                    {
                        bypherClock = clock[j];
                        clock[j] = clock[j + 1];
                        clock[j + 1] = bypherClock;
                        bypherName = name[j];
                        name[j] = name[j + 1];
                        name[j + 1] = bypherName;
                    }
                }
            }
            Array.Reverse(name);
            Array.Reverse(clock);
            return Tuple.Create<int[],string[]>(clock, name);
        }
    }
}
