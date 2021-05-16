using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private string m_VehicleModel;
        private string m_VehicleLicensePlate;
        private float m_CurrEnergyPercentage;
        private List<Wheel> m_WheelsList;
        private Engine m_EngineType;

        public Vehicle()
        {

        }

        public Vehicle(string i_VehicleModel, string i_VehicleLicensePlate, float i_CurrEnergyPercentage, Engine i_EngineType)
        {
            m_VehicleModel = i_VehicleModel;
            m_VehicleLicensePlate = i_VehicleLicensePlate;
            m_CurrEnergyPercentage = i_CurrEnergyPercentage;
            m_EngineType = i_EngineType;
            m_WheelsList = new List<Wheel>();
        }

        public Vehicle(int i_NumOfWheels, int i_MaxWheelsPressure, Engine i_Engine)
        {
            m_WheelsList = new List<Wheel>(i_NumOfWheels);
            
        }
    }
}
