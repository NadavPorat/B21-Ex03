using System;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        protected string m_ManufacturerName;
        protected float? m_CurrAirPressure;
        protected float m_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
            m_ManufacturerName = null;
            m_CurrAirPressure = null;
        }

        public float? AirPressure
        {
            get { return m_CurrAirPressure; }
            set 
            {
                if (value <= m_MaxAirPressure)
                {
                    m_CurrAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("Value is Over The MAX", 0, m_MaxAirPressure);
                }
            }
        }

        internal float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
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

        public StringBuilder GetDetails()
        {
            StringBuilder toDisplay = new StringBuilder();

            foreach(FieldInfo field in GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                string memberName = field.Name;
                int idx = memberName.IndexOf('_');
                memberName=memberName.Substring(idx+1);
                toDisplay.Append("\r\n " + memberName + " = " + field.GetValue(this));
            }

            return toDisplay;
        }
    }
}
