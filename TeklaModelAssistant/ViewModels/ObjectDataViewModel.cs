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
    class ObjectDataViewModel : PropertyChangedBase, IHandle<TeklaModelObjectProvider>
    {
        private IEventAggregator eventAggregator;

        private string guid;
        public string GUID
        {
            get { return guid; }
            set { guid = value; NotifyOfPropertyChange(() => GUID); }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; NotifyOfPropertyChange(() => Type); }
        }


        public ObjectDataViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.SubscribeOnUIThread(this);
        }

        public System.Threading.Tasks.Task HandleAsync(TeklaModelObjectProvider message, CancellationToken cancellationToken)
        {
            ModelObject mObject = message.TeklaModelObject;
            if(mObject != null)
            {
                GUID = $"{mObject.Identifier.GUID}";
                Type = $"{mObject.GetType()}".Replace("Tekla.Structures.Model.","");
            }
            else
            {
                GUID = Type = "Empty";
            }
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
