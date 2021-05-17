using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Creator
    {
        public enum EVehicleType
        {
            ElectricMotor,
            GasMotor,
            ElectricCar,
            GasCar,
            Truck
        }

        public static Vehicle Create(EVehicleType i_VehicleType)
        {
            return new ElectricMotor();
        }

    }
}
