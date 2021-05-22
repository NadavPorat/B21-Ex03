using System;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric : Engine
    {
        private float m_LeftBatteryTime; //inHours
        private readonly float r_MaxBatteryTime; //inHours

        public Electric(float i_MaxBatteryTime)
        {
            r_MaxBatteryTime = i_MaxBatteryTime;
        }

        internal override float CalcPowerPercentage()
        {
            return m_LeftBatteryTime / r_MaxBatteryTime;
        }

        internal override void RefillEnergy(float i_MinutesToAdd) 
        {
            float hoursToAdd = i_MinutesToAdd / 60f;

            if (r_MaxBatteryTime >= m_LeftBatteryTime + hoursToAdd)
            {
                m_LeftBatteryTime = m_LeftBatteryTime + hoursToAdd;
            }
            else
            {
                throw (new ValueOutOfRangeException("Value is Out Of Range", 0, r_MaxBatteryTime));
            }
        }

        internal override StringBuilder GetDetails()
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


        internal override void SetCurrPower(float i_CurrPower)
        {
            if (i_CurrPower>=0 && i_CurrPower<= r_MaxBatteryTime)
            {
                m_LeftBatteryTime = i_CurrPower;
            }
            else
            {
                throw new ValueOutOfRangeException("Value is Out Of Range", 0, r_MaxBatteryTime);
            }
        }

    }
}
