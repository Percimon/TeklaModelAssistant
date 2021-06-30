using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using TeklaModelAssistant.Models;

namespace TeklaModelAssistant.ViewModels
{
    class PartAttributesViewModel : PartWrapper
    {
        public PartAttributesViewModel(Part part) : base(part)
        {
        }
    }
}
