using System.Linq;
using System.Windows;
using You.Helpers;
using You.Properties;

namespace You.ViewModel
{
    public class MainWindowViewModel
    {
        MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        public MainWindowViewModel()
        {
            OpenSectionsCommand = new DelegateCommand(o => OpenSections());
            OpenNeuralNetworkCommand = new DelegateCommand(o => OpenNeuralNetwork());
            OpenVictoryCommand = new DelegateCommand(o => OpenVictory());
            OpenTrainingCommand = new DelegateCommand(o => OpenTraining());
            PathUserPhoto = Settings.Default["PathPhotoUser"].ToString();
        }
        public string PathUserPhoto { get; set; }
        #region Command
        public DelegateCommand OpenAddCommand { get; set; }
        public DelegateCommand OpenSectionsCommand { get; set; }
        public DelegateCommand OpenNeuralNetworkCommand { get; set; }
        public DelegateCommand OpenVictoryCommand { get; set; }
        public DelegateCommand OpenTrainingCommand { get; set; }
        #endregion
        #region Command implementation
        private void OpenSections()
        {
            window.mainGrid.Children.Clear();
            window.mainGrid.Children.Add(new View.SectionsPageView());
        }
        private void OpenNeuralNetwork()
        {
            window.mainGrid.Children.Clear();
            window.mainGrid.Children.Add(new View.NeuralNetworkPageView());
        }
        private void OpenVictory()
        {
            window.mainGrid.Children.Clear();
            window.mainGrid.Children.Add(new View.VictoryPageView());
        }
        private void OpenTraining()
        {
            window.mainGrid.Children.Clear();
            window.mainGrid.Children.Add(new View.TrainingPageView());
        }
        #endregion
    }
}
