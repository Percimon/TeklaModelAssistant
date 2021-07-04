using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using TeklaModelAssistant.Infrastructure;

namespace TeklaModelAssistant.ViewModels
{
    class ObjectDataViewModel
    {
        private IEventAggregator eventAggregator;
        public ObjectIdentificationViewModel ObjectIdentificationViewModel { get; set; }
        public ObjectAttributesViewModel ObjectAttributesViewModel { get; set; }
        public ObjectGeometryViewModel ObjectGeometryViewModel { get; set; }

        public ObjectDataViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            ObjectIdentificationViewModel = new ObjectIdentificationViewModel(eventAggregator);
            ObjectAttributesViewModel = new ObjectAttributesViewModel(eventAggregator);
            ObjectGeometryViewModel = new ObjectGeometryViewModel(eventAggregator);
        }
    }
}
