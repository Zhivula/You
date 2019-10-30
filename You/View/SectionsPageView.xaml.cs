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
using You.ViewModel;
using You.View;
using System.Windows.Media.Animation;

namespace You.View
{
    /// <summary>
    /// Логика взаимодействия для SectionsPageView.xaml
    /// </summary>
    public partial class SectionsPageView : UserControl
    {
        public SectionsPageView()
        {
            int VerticalLine = File.ReadAllLines(@"grids.txt").Where(x => x != "").Count();
            byte HorizontalLine = 3;
            byte sizeG = 2;
            Array.Resize(ref Resource.name, VerticalLine);
            Array.Resize(ref Resource.clock, VerticalLine);
            string[] full = File.ReadAllLines(@"grids.txt", Encoding.Default).Take(VerticalLine).ToArray();
            for (int i = 0; i < VerticalLine/ sizeG; i++)
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
            int sizeV = (int)Math.Ceiling((decimal)(VerticalLine/2) / HorizontalLine);//ОКРУГЛЯЕМ В БОЛЬШУЮ СТОРОНУ Math.Ceiling()
            int sizeVmin = (int)Math.Floor((decimal)(VerticalLine/2) / HorizontalLine);//ОКРУГЛЯЕМ В МЕНЬШУЮ СТОРОНУ Math.Floor()
            InitializeComponent();
            DataContext = new SectionsViewModel();
            InitOldGrid(sizeV, (VerticalLine/2), sizeVmin, HorizontalLine);
            
        }
        public void InitOldGrid(int sizeV, int VerticalLine, int sizeVmin,byte HorizontalLine)
        {
            Grid grid = new Grid();
            grid.Height = sizeV * 240;//240 - ВЫСОТА ПОД ОДИН "СЛОЙ" НЕСКОЛЬКИХ Grid 
            for (int i=0; i < sizeV; i++) grid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < HorizontalLine; i++) grid.ColumnDefinitions.Add(new ColumnDefinition());
            int bypher = 0;
            for (int i=0; i < sizeVmin; i++)
            {              
                for (int j = 0; j < HorizontalLine; j++)
                {                                    
                    Grid CardGrid = new Grid();
                    CardPageView cardPageView = new CardPageView();
                    CardGrid.Children.Add(cardPageView);
                    cardPageView.NameCardText.Content = Resource.name[bypher];
                    cardPageView.ALLClock.Content = Resource.clock[bypher];
                    VerticalAlignment = VerticalAlignment.Top;
                    int level = 0;
                    int summa = 0;
                    while (Resource.clock[bypher] > summa)
                    {
                        level++;
                        summa += level;
                        if ((summa + level + 1) > Resource.clock[bypher]) break;
                    }
                    int NowClockLevel = Resource.clock[bypher] - summa;
                    int YetClockLevel = summa + level + 1 - Resource.clock[bypher];
                    float progressCard = (NowClockLevel * 100) / (NowClockLevel + YetClockLevel);
                    cardPageView.ProgressBarCard.Value = progressCard;
                    cardPageView.NumberLevel.Content = level;
                    cardPageView.ToNextLevelClock.Content = YetClockLevel;
                    cardPageView.ProgressValueCard.Content = progressCard;
                    Grid.SetRow(CardGrid, i);
                    Grid.SetColumn(CardGrid, j);
                    grid.Children.Add(CardGrid);
                    bypher++;
                }
            }
            for (int j = 0; j < VerticalLine - (sizeVmin * HorizontalLine); j++)
            {
                Grid CardGrid = new Grid();
                CardPageView cardPageView = new CardPageView();
                VerticalAlignment = VerticalAlignment.Top;
                CardGrid.Children.Add(cardPageView);
                cardPageView.NameCardText.Content = Resource.name[bypher];
                cardPageView.ALLClock.Content = Resource.clock[bypher];
                int level = 0;
                int summa = 0;
                while (Resource.clock[bypher] > summa)
                {
                    level++;
                    summa += level;
                    if ((summa + level + 1) > Resource.clock[bypher]) break;
                }
                int NowClockLevel = Resource.clock[bypher] - summa;
                int YetClockLevel = summa + level + 1 - Resource.clock[bypher];
                float progressCard = (NowClockLevel * 100) / (NowClockLevel + YetClockLevel);
                cardPageView.ProgressBarCard.Value = progressCard;
                cardPageView.NumberLevel.Content = level;
                cardPageView.ToNextLevelClock.Content = YetClockLevel;
                cardPageView.ProgressValueCard.Content = progressCard;
                Grid.SetRow(CardGrid, sizeV);
                Grid.SetColumn(CardGrid, j);
                grid.Children.Add(CardGrid);
                bypher++;
            }
            SectionGrid.Children.Add(grid);
            Help help = new Help();
            help.Successfully();
        }
        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            if (ADDNewCardTextBox.Text != "")
            {
                using (StreamWriter sw = new StreamWriter(@"grids.txt", true, Encoding.Default))
                {
                    sw.WriteLine(ADDNewCardTextBox.Text);
                    sw.WriteLine("0");
                    sw.Close();
                }
                ADDNewCardTextBox.Text = "";
                Help help = new Help();
                help.Successfully();
                MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                window.mainGrid.Children.Add(new View.SectionsPageView());
            }
            else
            {
                Help help = new Help();
                help.NotSuccessfully();
            }
        }
    }
}
