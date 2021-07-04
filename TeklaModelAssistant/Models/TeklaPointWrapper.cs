using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Geometry3d;

namespace TeklaModelAssistant.Models
{
    class TeklaPointWrapper
    {

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public TeklaPointWrapper(Point tPoint)
        {
            this.X = tPoint.X;
            this.Y = tPoint.Y;
            this.Z = tPoint.Z;
        }

    }
}
