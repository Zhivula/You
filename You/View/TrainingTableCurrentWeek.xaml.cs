using System;
using System.Collections.Generic;
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
using You.ViewModel;

namespace You.View
{
    /// <summary>
    /// Логика взаимодействия для TrainingTableCurrentWeek.xaml
    /// </summary>
    public partial class TrainingTableCurrentWeek : UserControl
    {
        public TrainingTableCurrentWeek()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush gray = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            Change.IsEnabled = true;
            Save.IsEnabled = false;
            Name1.IsEnabled = false;
            Name1.Foreground = gray;
            Name2.IsEnabled = false;
            Name2.Foreground = gray;
            Name3.IsEnabled = false;
            Name3.Foreground = gray;
            Name4.IsEnabled = false;
            Name4.Foreground = gray;
            Name5.IsEnabled = false;
            Name5.Foreground = gray;
            Plan1.IsEnabled = false;
            Plan1.Foreground = gray;
            Plan2.IsEnabled = false;
            Plan2.Foreground = gray;
            Plan3.IsEnabled = false;
            Plan3.Foreground = gray;
            Plan4.IsEnabled = false;
            Plan4.Foreground = gray;
            Plan5.IsEnabled = false;
            Plan5.Foreground = gray;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush black = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Change.IsEnabled = false;
            Save.IsEnabled = true;
            Name1.IsEnabled = true;
            Name1.Foreground = black;
            Name2.IsEnabled = true;
            Name2.Foreground = black;
            Name3.IsEnabled = true;
            Name3.Foreground = black;
            Name4.IsEnabled = true;
            Name4.Foreground = black;
            Name5.IsEnabled = true;
            Name5.Foreground = black;
            Plan1.IsEnabled = true;
            Plan1.Foreground = black;
            Plan2.IsEnabled = true;
            Plan2.Foreground = black;
            Plan3.IsEnabled = true;
            Plan3.Foreground = black;
            Plan4.IsEnabled = true;
            Plan4.Foreground = black;
            Plan5.IsEnabled = true;
            Plan5.Foreground = black;
        }
    }
}
