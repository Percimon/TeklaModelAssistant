using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using TeklaModelAssistant.Models;

namespace TeklaModelAssistant.ViewModels
{
    class ContourPlateGeometryViewModel : PropertyChangedBase
    {

        private BindableCollection<TeklaPointWrapper> _points = new BindableCollection<TeklaPointWrapper>();
        public BindableCollection<TeklaPointWrapper> Points
        {
            get => _points;
            set
            {
                _points = value;
                NotifyOfPropertyChange(() => Points);
            }
        }

        private ContourPlate cPlate;
        public ContourPlateGeometryViewModel(ContourPlate cPlate)
        {
            this.cPlate = cPlate;
            Contour contour = cPlate.Contour;
            foreach (ContourPoint cp in contour.ContourPoints)
            {
                Points.Add(new TeklaPointWrapper(cp));
            }
        }


        public void UpdateCoordinates()
        {
            Contour newContour = new Contour();
            foreach(var cp in Points)
            {
                newContour.AddContourPoint(new ContourPoint(new Tekla.Structures.Geometry3d.Point(cp.X, cp.Y, cp.Z), null));
            }
            cPlate.Contour = newContour;
            cPlate.Modify();
            new Model().CommitChanges();
        }

    }
}
