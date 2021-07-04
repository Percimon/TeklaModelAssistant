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
    class ObjectGeometryViewModel : Conductor<object>, IHandle<TeklaModelObjectProvider>
    {
        private IEventAggregator eventAggregator;
        public ObjectGeometryViewModel(IEventAggregator events)
        {
            eventAggregator = events;
            eventAggregator.SubscribeOnUIThread(this);
        }

        public System.Threading.Tasks.Task HandleAsync(TeklaModelObjectProvider message, CancellationToken cancellationToken)
        {
            switch(message.TeklaModelObject)
            {
                case Beam beam:
                    {
                        ActivateItemAsync(new BeamGeometryViewModel(beam));
                        break;
                    }
                case PolyBeam polyBeam:
                    {
                        ActivateItemAsync(new PolybeamGeometryViewModel(polyBeam));
                        break;
                    }
                case ContourPlate cPlate:
                    {
                        ActivateItemAsync(new ContourPlateGeometryViewModel(cPlate));
                        break;
                    }
            }
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
