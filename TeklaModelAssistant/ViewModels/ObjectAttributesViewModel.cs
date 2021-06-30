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
    class ObjectAttributesViewModel : Conductor<object>, IHandle<TeklaModelObjectProvider>
    {
        private IEventAggregator eventAggregator;

        public ObjectAttributesViewModel(IEventAggregator events)
        {
            this.eventAggregator = events;
            eventAggregator.SubscribeOnUIThread(this);
        }

        public System.Threading.Tasks.Task HandleAsync(TeklaModelObjectProvider message, CancellationToken cancellationToken)
        {
            switch(message.TeklaModelObject)
            {
                case Part part:
                {
                    ActivateItemAsync(new PartAttributesViewModel(part));
                    break;
                }
                default:
                    ActiveItem = null;
                    break;
            }
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
