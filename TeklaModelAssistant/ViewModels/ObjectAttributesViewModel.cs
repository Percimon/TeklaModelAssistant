using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklaModelAssistant.ViewModels
{
    class ObjectAttributesViewModel
    {
        private IEventAggregator eventAggregator;

        public ObjectAttributesViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }
    }
}
