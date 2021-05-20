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
            GasCar = 1,
            ElectricCar,
            GasMotor,
            ElectricMotor,
            Truck
        }

        public static Vehicle Create(EVehicleType i_VehicleType)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case EVehicleType.GasCar:
                    newVehicle = new GasCar();
                    break;
                case EVehicleType.ElectricCar:
                    newVehicle = new ElectricCar();
                    break;
                case EVehicleType.GasMotor:
                    newVehicle = new GasMotor();
                    break;
                case EVehicleType.ElectricMotor:
                    newVehicle = new ElectricMotor();
                    break;
                case EVehicleType.Truck:
                    newVehicle = new Truck();
                    break;
            }

            return newVehicle;
        }

    }
}
