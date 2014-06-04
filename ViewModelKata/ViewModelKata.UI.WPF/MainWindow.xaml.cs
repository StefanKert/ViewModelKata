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
using ViewModelKata.Contracts;

namespace ViewModelKata.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl, IUI
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Show()
        {
            MessageBox.Show("Test");
        }

        public event Action ClickButton;

        public void ShowMessage()
        {
            MessageBox.Show("Neue Nachricht für WPF :)");
        }
    }
}
