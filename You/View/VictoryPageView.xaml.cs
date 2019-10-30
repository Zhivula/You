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

namespace You.View
{
    /// <summary>
    /// Логика взаимодействия для VictoryPageView.xaml
    /// </summary>
    public partial class VictoryPageView : UserControl
    {
        public VictoryPageView()
        {
            int sizeV = File.ReadAllLines(@"VictoryUser.txt").Where(x => x != "").Count();
            byte sizeG = 4;
            int sizeR = sizeV / sizeG;
            Array.Resize(ref VictoryData.category, sizeR);
            Array.Resize(ref VictoryData.name, sizeR);
            Array.Resize(ref VictoryData.ochki, sizeR);
            Array.Resize(ref VictoryData.time, sizeR);
            string[] full = File.ReadAllLines(@"VictoryUser.txt", Encoding.Default).Take(sizeV).ToArray();
            for (int i = 0; i < sizeR; i++)
            {
                for (byte j = 0; j < sizeG; j++)
                {
                    switch (j)
                    {
                        case 0:
                            VictoryData.category[i] = full[i * sizeG + j];
                            break;
                        case 1:
                            VictoryData.name[i] = full[i * sizeG + j];
                            break;
                        case 2:
                            VictoryData.ochki[i] = byte.Parse(full[i * sizeG + j]);
                            break;
                        case 3:
                            VictoryData.time[i] = full[i * sizeG + j];
                            break;
                    }
                }
            }
            InitializeComponent();
            DataContext = new VictoryViewModel();
            TableGrid(sizeR);
        }
        public void TableGrid(int sizeR)
        {
            for (int i = 0; i < sizeR; i++)
            {
                Node node = new Node();
                node.nodeCategory = VictoryData.category[i].ToString();               
                node.nodeName = VictoryData.name[i].ToString();
                node.nodeOchki = VictoryData.ochki[i].ToString();
                node.nodeTime = VictoryData.time[i].ToString();
                dataGridOne.Items.Add(node);
            }    
        }
    } 
       public class Node
        {
            public string nodeCategory { get; set; }
            public string nodeName { get; set; }
            public string nodeOchki { get; set; }
            public string nodeTime { get; set; }
        }
}
