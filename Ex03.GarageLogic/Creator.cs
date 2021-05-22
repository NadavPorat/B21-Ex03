using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Creator
    {
        public enum eVehicleType
        {
            GasCar = 1,
            ElectricCar,
            GasMotor,
            ElectricMotor,
            Truck
        }

        public static Vehicle Create(eVehicleType i_VehicleType)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.GasCar:
                    newVehicle = new GasCar();
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new ElectricCar();
                    break;
                case eVehicleType.GasMotor:
                    newVehicle = new GasMotor();
                    break;
                case eVehicleType.ElectricMotor:
                    newVehicle = new ElectricMotor();
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck();
                    break;
            }

            return newVehicle;
        }
    }
}
