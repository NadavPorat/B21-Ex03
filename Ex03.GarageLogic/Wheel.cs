﻿using System;


namespace Ex03.GarageLogic
{
    public class Wheel
    {
        protected string m_ManufacturerName;
        protected float m_CurrAirPressure;
        protected float m_MaxAirPressure;

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
                    throw new ValueOutOfRangeException("Value is Over The MAX", 0, m_MaxAirPressure);
                }
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
        
        internal float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            set
            {
                m_MaxAirPressure = value;
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
