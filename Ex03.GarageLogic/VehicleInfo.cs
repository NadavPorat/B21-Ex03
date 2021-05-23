using System;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInfo
    {
        public enum eVehicleStatus
        {
            InProcces = 1,
            Fixed,
            Paid
        }

        private string m_OwnerName;
        private string m_OwnerPhone;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public VehicleInfo(Vehicle i_Vehicle)
        {
            m_Vehicle = i_Vehicle;
            m_VehicleStatus = eVehicleStatus.InProcces;
            m_OwnerName = null;
            m_OwnerPhone = null;
        }

        public eVehicleStatus Status
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public string VehicleOwnerName
        {
            set
            {
                m_OwnerName = value;
            }
        }
        
        public string VehicleOwnerPhone
        {
            set
            {
                m_OwnerPhone = value;
            }
        }

        public void SetVehicleModelName(string i_VehicleModel)
        {
            m_Vehicle.VehicleModel = i_VehicleModel;
        }
        
        public void SetWheelsManufacturer(string i_WheelsManu)
        {
            m_Vehicle.WheelsManufacturer = i_WheelsManu;
        }
        
        public void SetWheelsCurrAirPressure(float i_CurrAirPressure)
        {
            m_Vehicle.CurrWheelsAirPressure = i_CurrAirPressure;
        }

        internal StringBuilder GetCard()
        {
            StringBuilder toDisplay = new StringBuilder();
            Type type = GetType();
            toDisplay.Append(type.Name + " :\r\n");

            foreach (FieldInfo member in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if(member.FieldType == typeof(Vehicle))
                {
                    toDisplay.Append(m_Vehicle.GetDetails());
                }
                else
                {
                    string memberName = GarageData.FixNameToPrint(member.Name);
                    toDisplay.Append("\r\n " + memberName + " = " + member.GetValue(this));
                }
            }

           return toDisplay;
        }
    }
}
