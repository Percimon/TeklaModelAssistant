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
    class BeamGeometryViewModel : PropertyChangedBase
    {
        private Beam beam;

        private TeklaPointWrapper _startPoint;
        public TeklaPointWrapper StartPoint
        {
            get => _startPoint;
            set
            {
                _startPoint = value;
                NotifyOfPropertyChange(() => StartPoint);
            }
        }

        private TeklaPointWrapper _endPoint;
        public TeklaPointWrapper EndPoint
        {
            get => _endPoint;
            set
            {
                _endPoint = value;
                NotifyOfPropertyChange(() => EndPoint);
            }
        }



        public BeamGeometryViewModel(Beam beam)
        {
            this.beam = beam;
            StartPoint = new TeklaPointWrapper(beam.StartPoint);
            EndPoint = new TeklaPointWrapper(beam.EndPoint);
        }

        public void UpdateCoordinates()
        {
            beam.StartPoint = new Tekla.Structures.Geometry3d.Point(StartPoint.X, StartPoint.Y, StartPoint.Z);
            beam.EndPoint = new Tekla.Structures.Geometry3d.Point(EndPoint.X, EndPoint.Y, EndPoint.Z);
            beam.Modify();
            new Model().CommitChanges();
        }

    }
}
