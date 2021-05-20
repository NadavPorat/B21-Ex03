using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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

        public string LicensePlate
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
        
        public float CurrWheelsAirPressure
        {
            set
            {
                foreach (Wheel wheel in m_WheelsList)
                {
                    wheel.AirPressure = value;
                }
            }
        }

        public Engine Engine
        {
            get
            {
                return m_EngineType;
            }
        }

        public string WheelsManufacturer
        {
            set
            {
                foreach (Wheel wheel in m_WheelsList)
                {
                    wheel.Manufaturer = value;
                }
            }
        }

        public void InflateWheels()
        {
            foreach (Wheel wheel in m_WheelsList)
            {
                wheel.AirPressure = wheel.MaxAirPressure;
            }
        }

        public StringBuilder GetDetails()
        {
            StringBuilder toDisplay= new StringBuilder();
            Type vehicleType = GetType();

            foreach (FieldInfo f in vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (f.FieldType == typeof(Engine))
                {
                    toDisplay.Append(m_EngineType.GetDetails());
                }
                else
                {
                    int idx = f.ToString().IndexOf("_");
                    string memberName = f.ToString().Substring(idx + 1);
                    toDisplay.Append("\r\n " + memberName + " = " + f.GetValue(this));
                }
            }


            foreach(FieldInfo f in typeof(Vehicle).GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (f.FieldType == typeof(Engine))
                {
                    toDisplay.Append(m_EngineType.GetDetails());
                }
                else
                {
                    int idx = f.ToString().IndexOf("_");
                    string memberName = f.ToString().Substring(idx + 1);
                    toDisplay.Append("\r\n " + memberName + " = " + f.GetValue(this));
                }
            }

            return toDisplay;
        }

        public abstract void SetInfo(FieldInfo i_FieldInfo, Object i_ValueToPut);
    }
}
