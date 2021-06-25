using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklaModelAssistant.Services;

namespace TeklaModelAssistant.ViewModels
{
    class ShellViewModel : Conductor<object>
    {

        private ObjectDataViewModel objectDataViewModel;

        public ShellViewModel()
        {
            IEventAggregator eventAggregator = new EventAggregator();
            objectDataViewModel = new ObjectDataViewModel(eventAggregator);
            new TeklaEventHandler(eventAggregator).RegisterEvents();
        }

        public void SetObjectDataView()
        {
            ActivateItemAsync(objectDataViewModel);
        }

    }
}
