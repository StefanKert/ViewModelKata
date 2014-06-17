using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using ViewModelKata.Contracts;
using ViewModelKata.Domain;
using ViewModelKata.WinForms;
using ViewModelKata.WPF;


namespace ViewModelKata.Host
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Trace.;
            IUI winformsUI = new Form1();
            IUI wpfUI = new MainWindow();
            IViewModel viewModel = new ViewModel();

            viewModel.ShowMessage += winformsUI.ShowMessage;
            viewModel.ShowMessage += wpfUI.ShowMessage;

            wpfUI.ClickButton += viewModel.OnShowMessage;
            winformsUI.ClickButton += viewModel.OnShowMessage;

            wpfUI.Show();
            winformsUI.Show();
        }
    }
}
