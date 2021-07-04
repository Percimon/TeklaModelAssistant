using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace TeklaModelAssistant.ViewModels
{
    class PolybeamGeometryViewModel
    {
        private PolyBeam polyBeam;

        public PolybeamGeometryViewModel(PolyBeam polyBeam)
        {
            this.polyBeam = polyBeam;
        }
    }
}
