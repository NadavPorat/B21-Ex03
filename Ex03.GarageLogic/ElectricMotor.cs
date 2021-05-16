using System;

namespace Ex03.GarageLogic
{
    class ElectricMotor: Motorcycle
    {
        //public ElectricMotor(string i_LicenseType, int i_EngineCapacity, string i_VehicleModel, string i_LicensePlate, float i_LeftEngeryTime) : base( i_LicenseType,  i_EngineCapacity,  i_VehicleModel,i_LicensePlate, i_LeftEngeryTime, new Electric(1.8f, i_LeftEngeryTime))
        //{

        //}
        public ElectricMotor(int i_LeftEngeryTime) : base(2, 30, new Electric(1.8f, i_LeftEngeryTime))
        {

        }
    }
}
