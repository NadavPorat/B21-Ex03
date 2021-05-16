using System;


namespace Ex03.GarageLogic
{
    internal class Electric : Engine
    {
        private float m_LeftBatteryTime; //inHours
        private float m_MaxBatteryTime; //inHours

        public Electric(float i_MaxBatteryTime,float i_LeftBatteryTime)
        {
            m_LeftBatteryTime = i_LeftBatteryTime;
            m_MaxBatteryTime = i_MaxBatteryTime;
        }

        internal void Charge(float i_HoursToAdd)
        {
            if(m_MaxBatteryTime>= m_LeftBatteryTime+i_HoursToAdd)
            {
                m_LeftBatteryTime = m_LeftBatteryTime + i_HoursToAdd;
            }
        }

    }
}
