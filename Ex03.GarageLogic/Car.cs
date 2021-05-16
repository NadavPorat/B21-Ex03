using System;


namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private string m_CarColor;
        private int m_NumOfDoors;

        public Car(string i_CarColor, int i_NumDoors, string i_VehicleModel, string i_VehicleLicensePlate, float i_CurrEnergyPercentage, Engine i_EngineType) :base(i_VehicleModel, i_VehicleLicensePlate, i_CurrEnergyPercentage, i_EngineType)
        {
            m_CarColor = i_CarColor;
            m_NumOfDoors = i_NumDoors;
        }
    }
}
