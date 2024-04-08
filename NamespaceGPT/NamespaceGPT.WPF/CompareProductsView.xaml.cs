using NamespaceGPT.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace NamespaceGPT.WPF
{
    public partial class CompareProductsView : Window, INotifyPropertyChanged
    {
        public IDictionary<string, string> CommonAttributes1 { get; set; }
        public IDictionary<string, string> CommonAttributes2 { get; set; }

        public CompareProductsView(Product product1, Product product2)
        {
            InitializeComponent();
            DataContext = this;

            var commonKeys = product1.Attributes.Keys.Intersect(product2.Attributes.Keys).Take(5).ToList();
            CommonAttributes1 = commonKeys.ToDictionary(key => key, key => product1.Attributes[key]);
            CommonAttributes2 = commonKeys.ToDictionary(key => key, key => product2.Attributes[key]);

            OnPropertyChanged(nameof(CommonAttributes1));
            OnPropertyChanged(nameof(CommonAttributes2));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
