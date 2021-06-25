using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using TeklaModelAssistant.Infrastructure;

namespace TeklaModelAssistant.Services
{
    class TeklaEventHandler
    {
        private IEventAggregator eventAggregator;
        private Events teklaEvents = new Events();
        private object selectionChangeEventLock = new object();

        public TeklaEventHandler(IEventAggregator events)
        {
            eventAggregator = events;
        }

        public void RegisterEvents()
        {
            teklaEvents.SelectionChange += OnTeklaSelectionChange;
            teklaEvents.Register();
        }

        private void OnTeklaSelectionChange()
        {
            lock(selectionChangeEventLock)
            {
                var modelObjectSelector = new Tekla.Structures.Model.UI.ModelObjectSelector();
                var modelObjectEnumerator = modelObjectSelector.GetSelectedObjects();
                if(modelObjectEnumerator.GetSize() > 0)
                {
                    modelObjectEnumerator.MoveNext();
                    eventAggregator.PublishOnUIThreadAsync(new TeklaModelObjectProvider
                    {
                        TeklaModelObject = modelObjectEnumerator.Current
                    }); ;
                }
                else
                {
                    eventAggregator.PublishOnUIThreadAsync(new TeklaModelObjectProvider()); ;
                }
            }
        }
    }
}
