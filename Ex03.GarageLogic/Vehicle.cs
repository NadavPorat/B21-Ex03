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
        private Engine m_Engine;
        private List<Wheel> m_WheelsList;

        public Vehicle()
        {

        }

        public Vehicle(string i_VehicleModel, string i_VehicleLicensePlate, float i_CurrEnergyPercentage, Engine i_EngineType)
        {
            m_VehicleModel = i_VehicleModel;
            m_VehicleLicensePlate = i_VehicleLicensePlate;
            m_CurrEnergyPercentage = i_CurrEnergyPercentage;
            m_Engine = i_EngineType;
            m_WheelsList = new List<Wheel>();
        }

        public Vehicle(int i_NumOfWheels, float i_MaxWheelsPressure, Engine i_Engine)
        {
            m_WheelsList = new List<Wheel>();

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_WheelsList.Add(new Wheel(i_MaxWheelsPressure));
            }

            m_Engine = i_Engine;
        }

        public Type GetEngineType()
        {
            return m_Engine.GetType();
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
                return m_Engine;
            }
        }

 
        public void RefillElctricVehicle(float i_ToAdd)
        {
            if (m_Engine is Electric)
            {
                m_Engine.RefillEnergy(i_ToAdd);
            }
            else
            {
                throw (new ArgumentException("Wrong Type Of Vehicle"));
            }
        }

        public void RefillGasVehicle(float i_ToAdd,string i_GasType)
        {
            if (m_Engine is Gasoline)
            {
                Gasoline gasolineEngine = m_Engine as Gasoline;
                gasolineEngine.RefillGas(i_ToAdd, i_GasType);
            }
            else
            {
                throw (new ArgumentException("Wrong Type Of Vehicle"));
            }
        }

        public void SetCurrPower(float i_PowerToAdd)
        {
            m_Engine.SetCurrPower(i_PowerToAdd);
            updatePowerPercentage();
        }

        private void updatePowerPercentage()
        {
            m_CurrEnergyPercentage = m_Engine.calcPowerPercentage();
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

        public void InflateWheelsToMax()
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

            foreach(FieldInfo f in typeof(Vehicle).GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (f.FieldType == typeof(Engine))
                {
                    toDisplay.Append(m_Engine.GetDetails());
                }
                else if(f.FieldType==m_WheelsList.GetType())
                {
                    toDisplay.Append("\r\nWheels Information:");
                    int wheelNum = 1;
                    
                    foreach(Wheel wheel in m_WheelsList)
                    {
                        toDisplay.Append("\r\nWheel "+ wheelNum+" :");
                        toDisplay.Append(wheel.GetDetails());
                        wheelNum++;
                    }
                }
                else
                {
                    int idx = f.ToString().IndexOf("_");
                    string memberName = f.ToString().Substring(idx + 1);
                    toDisplay.Append("\r\n " + memberName + " = " + f.GetValue(this));
                }
            }

            foreach (FieldInfo f in vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                int idx = f.ToString().IndexOf("_");
                string memberName = f.ToString().Substring(idx + 1);
                toDisplay.Append("\r\n " + memberName + " = " + f.GetValue(this));
            }

            return toDisplay;
        }

        public abstract void SetInfo(FieldInfo i_FieldInfo, Object i_ValueToPut);
    }
}
