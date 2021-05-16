using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
    public class GasMotor:Motorcycle
    {
        public GasMotor(): base(new Gasoline(Gasoline.EGasType.Octan98, 6))
        {

        }
    }
}
