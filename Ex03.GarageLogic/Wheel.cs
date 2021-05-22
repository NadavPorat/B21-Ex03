using System;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        protected string m_ManufacturerName;
        protected float? m_CurrAirPressure;
        protected readonly float r_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
            m_ManufacturerName = null;
            m_CurrAirPressure = null;
        }

        public float? AirPressure
        {
            get { return m_CurrAirPressure; }
            set 
            {
                if (value>=0 && value <= r_MaxAirPressure)
                {
                    m_CurrAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("Value is Out Of Range", 0, r_MaxAirPressure);
                }
            }
        }

        internal float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        internal string Manufaturer
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }    

        internal StringBuilder GetDetails()
        {
            StringBuilder toDisplay = new StringBuilder();

            foreach(FieldInfo field in GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                string memberName = field.Name;
               memberName = GarageData.FixNameToPrint(memberName.ToString());
                toDisplay.Append("\r\n " + memberName + " = " + field.GetValue(this));
            }

            return toDisplay;
        }
    }
}
