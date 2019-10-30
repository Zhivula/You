using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using You.View;

namespace You.ViewModel
{
    internal class NeuralNetworkViewModel
    {
        public ObservableCollection<ChartEffect> DataWeek { get; set; }
        public ObservableCollection<ChartEffect> DataMonth { get; set; }
        public NeuralNetworkViewModel(string name,int valueWeek,int valueMonth)
        {
            DataWeek = new ObservableCollection<ChartEffect> { new ChartEffect {String= name, Porcent = valueWeek } };
            DataMonth = new ObservableCollection<ChartEffect> { new ChartEffect { String = name, Porcent = valueMonth } };
        }
    }
}
