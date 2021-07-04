using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace TeklaModelAssistant.ViewModels
{
    class BeamGeometryViewModel
    {
        private Beam beam;

        public BeamGeometryViewModel(Beam beam)
        {
            this.beam = beam;
        }
    }
}
