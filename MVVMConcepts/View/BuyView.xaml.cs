using MVVMConcepts.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMConcepts.View
{
    /// <summary>
    /// Interaction logic for BuyView.xaml
    /// </summary>
    public partial class BuyView : UserControl
    {
        public BuyView()
        {
            InitializeComponent();
            DataContext = new BuyViewModel();
        }
    }
}
