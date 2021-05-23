using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasCar : Car
    {
        public GasCar() : base(new Gasoline(Gasoline.eGasType.Octan95, 45))
        {
        }
    }
}
