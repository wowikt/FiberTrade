using FifteenGameIoc.Wpf.Views;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FifteenGameClientIoC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IKernel _kernel;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            _kernel = new StandardKernel(new FifteenGameModule());
        }

        private void ComposeObjects()
        {
            Current.MainWindow = _kernel.Get<MainWindow>();
        }
    }
}
