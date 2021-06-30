using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace TeklaModelAssistant.Models
{
    class PartWrapper : PropertyChangedBase
    {
        #region Name
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; NotifyOfPropertyChange(()=>Name); _part.Name = name; CommitChanges(); }
        }

        #endregion

        private Part _part;
        public PartWrapper(Part part)
        {
            _part = part;
            Name = part.Name;
        }

        private void CommitChanges()
        {
            _part.Modify();
            new Model().CommitChanges();
        }

    }
}
