using System;


namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private string m_LicenseType;
        private int m_EngineCapacity;

        //public Motorcycle(string i_LicenseType, int i_EngineCapacity, string i_VehicleModel, string i_LicensePlate, float i_CurrEnergyPer, Engine i_EngineType, ) : base(i_VehicleModel, i_LicensePlate, i_CurrEnergyPer, i_EngineType)
        //{
        //    m_LicenseType = i_LicenseType;
        //    m_EngineCapacity = i_EngineCapacity;
        //}

        public Motorcycle(Engine i_EngineType) : base(2, 30, i_EngineType)
        {
        }
    }
}
