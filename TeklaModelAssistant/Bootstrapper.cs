using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tekla.Structures.Model;
using TeklaModelAssistant.ViewModels;

namespace TeklaModelAssistant
{
    class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer simpleContainer = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            simpleContainer.Singleton<IEventAggregator, EventAggregator>();
            simpleContainer.Singleton<IWindowManager, WindowManager>();
            simpleContainer.Singleton<ShellViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            Model model = new Model();
            if(!model.GetConnectionStatus())
            {
                MessageBox.Show("Tekla model is not active. Application will be closed");
                Application.Current.Shutdown();
            }
            DisplayRootViewFor<ShellViewModel>();
        }

    }
}
