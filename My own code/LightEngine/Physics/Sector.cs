using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightEngine.Physics
{
    public class Sector
    {
        public readonly Area[,,] areas = new Area[10, 10, 10];
    }
}
