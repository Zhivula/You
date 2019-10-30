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
using You.Properties;
using You.View;
using You.ViewModel;

namespace You
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            ProgressCount.Content = Settings.Default["ProgressCount"].ToString();
            ScoreCount.Content = Settings.Default["ScoreCount"].ToString();
            if (Settings.Default["PathPhotoUser"].ToString() == "") CircleUserPhoto.Fill = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            UserFam.Content = Settings.Default["FamUser"].ToString();
            UserName.Content = Settings.Default["NameUser"].ToString();
        }
        //<summary>
        //ЗАПУСКАЕТСЯ ПРИ ЗАПУСКЕ ПРИЛОЖЕНИЯ -> ВНОСИТ НАЧАЛЬНЫЕ ДАННЫЕ, СОХРАНЕННЫЕ В ПАМЯТИ ПОД ПРИЛОЖЕНИЕ
        //</summary>
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            window.mainGrid.Children.Add(new View.SectionsPageView());
        }
        //<summary>
        //ЗАПУСКАЕТСЯ ПРИ ЗАПУСКЕ ПРИЛОЖЕНИЯ -> ВЫХОДЕ ИЗ ПРИЛОЖЕНИЯ
        //</summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var response = MessageBox.Show("Вы действительно хотите выйти?", "ВЫХОД", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (response == MessageBoxResult.Yes) Application.Current.Shutdown();
        }

        private void PersonSettings_Click(object sender, RoutedEventArgs e)
        {
              MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
              WindowWelcom windowWelcom = new WindowWelcom();
              windowWelcom.Show();
              window.Close();
        }
    }
}
