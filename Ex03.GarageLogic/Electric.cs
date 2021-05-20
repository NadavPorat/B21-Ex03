using System;


namespace Ex03.GarageLogic
{
    public class Electric : Engine
    {
        private float m_LeftBatteryTime; //inHours
        private float m_MaxBatteryTime; //inHours

        public Electric(float i_MaxBatteryTime)
        {
            m_MaxBatteryTime = i_MaxBatteryTime;
        }

        public override void RefillEnergy(float i_ToAdd) 
        {
            if (m_MaxBatteryTime >= m_LeftBatteryTime + i_ToAdd)
            {
                m_LeftBatteryTime = m_LeftBatteryTime + i_ToAdd;
            }
            else
            {
                throw (new ValueOutOfRangeException("More Then Max Gas Amoubt", 0, m_MaxBatteryTime));

            }
        }


        public override void SetCurrPower(float i_CurrPower)
        {
            if (i_CurrPower <= m_MaxBatteryTime)
            {
                m_LeftBatteryTime = i_CurrPower;
            }
            else
            {
                throw new ValueOutOfRangeException("Value is Out Of Range", 0, m_MaxBatteryTime);
            }
        }

    }
}
