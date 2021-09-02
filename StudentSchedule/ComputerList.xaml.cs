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

namespace Comp
{
    /// <summary>
    /// Логика взаимодействия для ComputerList.xaml
    /// </summary>
    public partial class ComputerList : Page, IPage
    {
        public ComputerList()
        {
            InitializeComponent();
        }
        public void SetVM(IPageVM vm)
        {
            DataContext = vm;
        }
    }
}
