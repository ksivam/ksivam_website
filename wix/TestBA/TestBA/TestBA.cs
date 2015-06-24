using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace Examples.Bootstrapper
{
    public class TestBA : BootstrapperApplication
    {
        // global dispatcher
        static public Dispatcher BootstrapperDispatcher { get; private set; }

        // entry point for our custom UI
        protected override void Run()
        {
            this.Engine.Log(LogLevel.Verbose, "Launching custom TestBA UX");
            BootstrapperDispatcher = Dispatcher.CurrentDispatcher;

            Thread.Sleep(10*1000);

            MainViewModel viewModel = new MainViewModel(this);
            viewModel.Bootstrapper.Engine.Detect();

            MainView view = new MainView();
            view.DataContext = viewModel;
            view.Closed += (sender, e) =>
            {
                BootstrapperDispatcher.InvokeShutdown();
            };
            view.Show();            

            Dispatcher.Run();

            this.Engine.Quit(0);
        }
    }
}
