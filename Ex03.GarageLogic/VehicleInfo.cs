using System;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInfo
    {
        public enum EVehicleStatus
        {
            InProcces=1,
            Fixed,
            Paid
        }

        private string m_OwnerName;
        private string m_OwnerPhone;
        private EVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public VehicleInfo(Vehicle i_Vehicle)
        {
            m_Vehicle = i_Vehicle;
            m_VehicleStatus = EVehicleStatus.InProcces;
            m_OwnerName = null;
            m_OwnerPhone = null;
        }

        public VehicleInfo(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_VehicleStatus = EVehicleStatus.InProcces;
            m_Vehicle = i_Vehicle;
        }

        public EVehicleStatus Status
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

        public void SetInProccesStatus()
        {
            m_VehicleStatus = EVehicleStatus.InProcces;
        }

        public Vehicle vehicle
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
            m_Vehicle.CurrWheelsAirPressure=i_CurrAirPressure;
        }

        internal StringBuilder GetCard()
        {
            StringBuilder toDisplay = new StringBuilder();
            Type type = GetType();
            toDisplay.Append(type.Name + " :\r\n\r\n");

            foreach (FieldInfo f in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if(f.FieldType == typeof(Vehicle))
                {
                    toDisplay.Append(m_Vehicle.GetDetails());
                }
                else
                {
                    int idx = f.ToString().IndexOf("_");
                    string memberName = f.ToString().Substring(idx+1);
                    toDisplay.Append("\r\n " + memberName + " = " + f.GetValue(this));
                }
            }

           return toDisplay;
        }



    }
}
