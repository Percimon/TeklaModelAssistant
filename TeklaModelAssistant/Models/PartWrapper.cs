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
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value; 
                NotifyOfPropertyChange(() => Name);
                _part.Name = _name;
                CommitChanges();
            }
        }

        #endregion

        #region Class

        private int _class;

        public int Class
        {
            get { return _class; }
            set
            {
                _class = value; 
                NotifyOfPropertyChange(() => Class); 
                _part.Class = $"{Class}";
                CommitChanges();
            }
        }


        #endregion

        #region Profile

        private string _profile;

        public string Profile
        {
            get { return _profile; }
            set 
            { 
                _profile = value; 
                NotifyOfPropertyChange(() => Profile);
                _part.Profile.ProfileString = Profile; 
                CommitChanges(); 
            }
        }


        #endregion

        #region Material

        private string _material;

        public string Material
        {
            get { return _material; }
            set 
            { 
                _material = value; 
                NotifyOfPropertyChange(() => Material);
                _part.Material.MaterialString = Material; 
                CommitChanges(); 
            }
        }


        #endregion

      
        private Part _part;
        public PartWrapper(Part part)
        {
            _part = part;
            Name = part.Name;
            Class = Int32.Parse(part.Class);
            Profile = part.Profile.ProfileString;
            Material = part.Material.MaterialString;
        }

        private void CommitChanges()
        {
            _part.Modify();
            new Model().CommitChanges();
        }

    }
}
