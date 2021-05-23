using System;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric : Engine
    {
        private readonly float r_MaxBatteryTime; ////inHours
        private float m_LeftBatteryTime; ////inHours

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
            float newBatteryTime = m_LeftBatteryTime + hoursToAdd;

            if ((hoursToAdd >= 0) && (r_MaxBatteryTime >= newBatteryTime))
            {
                m_LeftBatteryTime = newBatteryTime;
            }
            else
            {
                throw new ValueOutOfRangeException("Value is Out Of Range.", 0, r_MaxBatteryTime);
            }
        }

        internal override StringBuilder GetDetails()
        {
            StringBuilder toDisplay = new StringBuilder();
            Type vehicleType = GetType();

            foreach (FieldInfo member in vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                string memberName = GarageData.FixNameToPrint(member.Name);
                toDisplay.Append("\r\n " + memberName + " : " + member.GetValue(this));
            }

            return toDisplay;
        }

        internal override void SetCurrPower(float i_CurrPower)
        {
            if (i_CurrPower >= 0 && i_CurrPower <= r_MaxBatteryTime)
            {
                m_LeftBatteryTime = i_CurrPower;
            }
            else
            {
                throw new ValueOutOfRangeException("Value is Out Of Range.", 0, r_MaxBatteryTime);
            }
        }
    }
}
