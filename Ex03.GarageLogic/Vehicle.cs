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
        private readonly List<Wheel> r_WheelsList;

        public Vehicle(int i_NumOfWheels, float i_MaxWheelsPressure, Engine i_Engine)
        {
            r_WheelsList = new List<Wheel>();

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                r_WheelsList.Add(new Wheel(i_MaxWheelsPressure));
            }

            m_Engine = i_Engine;
        }

        public Type GetEngineType()
        {
            return m_Engine.GetType();
        }

        public string VehicleModel 
        {
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
                foreach (Wheel wheel in r_WheelsList)
                {
                    wheel.AirPressure = value;
                }
            }
        }

        internal void RefillElctricVehicle(float i_ToAdd)
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

        internal void RefillGas(float i_ToAdd,Gasoline.eGasType i_GasType)
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
            m_CurrEnergyPercentage = m_Engine.CalcPowerPercentage();
        }

        internal string WheelsManufacturer
        {
            set
            {
                foreach (Wheel wheel in r_WheelsList)
                {
                    wheel.Manufaturer = value;
                }
            }
        }

        internal void InflateWheelsToMax()
        {
            foreach (Wheel wheel in r_WheelsList)
            {
                wheel.AirPressure = wheel.MaxAirPressure;
            }
        }

        internal StringBuilder GetDetails()
        {
            StringBuilder toDisplay= new StringBuilder();
            Type vehicleType = GetType();

            foreach(FieldInfo f in typeof(Vehicle).GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (f.FieldType == typeof(Engine))
                {
                    toDisplay.Append(m_Engine.GetDetails());
                }
                else if(f.FieldType==r_WheelsList.GetType())
                {
                    toDisplay.Append("\r\nWheels Information:");
                    int wheelNum = 1;
                    
                    foreach(Wheel wheel in r_WheelsList)
                    {
                        toDisplay.Append("\r\nWheel "+ wheelNum+" :");
                        toDisplay.Append(wheel.GetDetails());
                        wheelNum++;
                    }
                }
                else
                {
                    string memberName = GarageData.FixNameToPrint(f.ToString());
                    toDisplay.Append("\r\n " + memberName + " = " + f.GetValue(this));
                }
            }

            foreach (FieldInfo f in vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                string memberName = GarageData.FixNameToPrint(f.ToString());
                toDisplay.Append("\r\n " + memberName + " = " + f.GetValue(this));
            }

            return toDisplay;
        }

        public abstract void SetInfo(FieldInfo i_FieldInfo, Object i_ValueToPut);
    }
}
