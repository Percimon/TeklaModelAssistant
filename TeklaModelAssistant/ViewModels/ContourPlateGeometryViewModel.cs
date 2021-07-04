using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace TeklaModelAssistant.ViewModels
{
    class ContourPlateGeometryViewModel
    {
        private ContourPlate cPlate;

        public ContourPlateGeometryViewModel(ContourPlate cPlate)
        {
            this.cPlate = cPlate;
        }
    }
}
