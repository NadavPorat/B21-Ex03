using System;


namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_IsHazardousMaterial;
        private float m_MaxCarryWeight;

        public Truck(bool i_IsHazard, float i_MaxWeight, string i_VehicleModel, string i_LicensePlate, float i_CurrEnergyPer, Engine i_EngineType) : base(i_VehicleModel, i_LicensePlate, i_CurrEnergyPer, i_EngineType)
        {
            m_IsHazardousMaterial = i_IsHazard;
            m_MaxCarryWeight = i_MaxWeight;
        }
    }
}
