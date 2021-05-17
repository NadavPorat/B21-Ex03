using System;


namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_MaManufacturerName, float i_CurrAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_MaManufacturerName;
            m_CurrAirPressure = i_CurrAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public float AirPressure
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
                    throw new Exception ();
                }
            }
        }

        internal void inflate(float i_AirToAdd)
        {
            if(m_MaxAirPressure<=(m_CurrAirPressure+i_AirToAdd))
            {
                m_CurrAirPressure = m_CurrAirPressure + i_AirToAdd;
            }
        }

    }
}
