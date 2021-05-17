using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
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

        public Vehicle(int i_NumOfWheels, float i_MaxWheelsPressure, Engine i_Engine)
        {
            m_WheelsList = new List<Wheel>();

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_WheelsList.Add(new Wheel(i_MaxWheelsPressure));
            }

            m_EngineType = i_Engine;
        }

        public string VehicleModel 
        {
            get
            {
                return m_VehicleModel;
            }
            set
            {
                m_VehicleModel = value;
            }
        }

        public string VehicleLicensePlate
        {
            get
            {
                return m_VehicleLicensePlate;
            }
            set
            {
                m_VehicleLicensePlate = value;
            }
        }

        public void SetCurrWheelsAirPressure(float i_CurrAirPressure)
        {
            foreach (Wheel wheel in m_WheelsList)
            {
                wheel.AirPressure = i_CurrAirPressure;
            }
        }

        public void SetCurrEnergyAmount(float i_CurrEnragy)
        {
            m_CurrEnergyPercentage = i_CurrEnragy;
        }

        public void SetmVehicleLicensePlate(string i_LicensePlate)
        {
            m_VehicleLicensePlate = i_LicensePlate;
        }

        public void Refuel(float i_amountOfFuel)
        {
            if (m_EngineType is Electric)
            {
               
             // m_EngineType
            }
            else
            {
             // Fuel
            }
        }
    }
}
