using System;


namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private string m_LicenseType;
        private int m_EngineCapacity;

        //public Motorcycle(string i_LicenseType, int i_EngineCapacity, string i_VehicleModel, string i_LicensePlate, float i_CurrEnergyPer, Engine i_EngineType, ) : base(i_VehicleModel, i_LicensePlate, i_CurrEnergyPer, i_EngineType)
        //{
        //    m_LicenseType = i_LicenseType;
        //    m_EngineCapacity = i_EngineCapacity;
        //}

        public Motorcycle(int i_NumOfWheels, int i_MaxWheelsPressure, Engine i_EngineType) : base(i_NumOfWheels, i_MaxWheelsPressure, i_EngineType)
        {
        }
    }
}
