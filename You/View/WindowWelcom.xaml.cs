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
    /// Логика взаимодействия для WindowWelcom.xaml
    /// </summary>
    public partial class WindowWelcom : Window
    {
        public WindowWelcom()
        {
            InitializeComponent();
            DataContext = new WindowWelcomViewModel();
            if (Settings.Default["PathPhotoUser"].ToString() == "") CircleUserPhoto.Fill = new SolidColorBrush(Color.FromRgb(200,200,200));
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void PathToPhotoUser_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".jpg"; // Default file extension
            
            dlg.Filter = "Файлы фотографий|*.jpg;*.png;*.ico"; // Filter files by extension
            
            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                InputPathPhotoUser.Text = filename;
                StackSucc.Visibility = Visibility.Visible;
                MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
                mainWindowViewModel.PathUserPhoto = filename;
                ImagePhotoUser.ImageSource = new BitmapImage(new Uri(filename));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Settings.Default["FamUser"] = InputFamUser.Text.ToString();
            Settings.Default["NameUser"] = InputNameUser.Text.ToString();
            Settings.Default["PathPhotoUser"] = InputPathPhotoUser.Text.ToString();
            Settings.Default.Save();
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
