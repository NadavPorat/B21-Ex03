using System;
using System.Reflection;
using System.Text;

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
        public override StringBuilder GetDetails()
        {
            StringBuilder toDisplay = new StringBuilder();
            Type vehicleType = GetType();

            foreach (FieldInfo f in vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                int idx = f.ToString().IndexOf("_");
                string memberName = f.ToString().Substring(idx + 1);
                toDisplay.Append("\r\n " + memberName + " = " + f.GetValue(this));
            }

            return toDisplay;
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
