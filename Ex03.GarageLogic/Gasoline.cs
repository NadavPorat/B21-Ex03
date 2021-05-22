using System;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Gasoline: Engine
    {
        private readonly eGasType r_GasType;
        private float m_CurrGasAmount;
        private readonly float r_MaxGasAmount;

        public Gasoline(eGasType i_GasType, float i_MaxGasAmount)
        {
            r_GasType = i_GasType;
            r_MaxGasAmount = i_MaxGasAmount;
        }

        internal override float CalcPowerPercentage()
        {
            return m_CurrGasAmount / r_MaxGasAmount;
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

        internal override void RefillEnergy(float i_ToAdd)
        {
            if (r_MaxGasAmount >= m_CurrGasAmount + i_ToAdd)
            {
                    m_CurrGasAmount = m_CurrGasAmount + i_ToAdd;
            }
            else
            {
                throw (new ValueOutOfRangeException("Value is Out Of Range", 0, r_MaxGasAmount));
            }
        }

        internal void RefillGas(float i_ToAdd, Gasoline.eGasType i_GasType)
        {
            if (i_GasType.Equals(r_GasType))
            {
                RefillEnergy(i_ToAdd);
            }
            else
            {
                throw (new ArgumentException("Wrong Gas Type"));
            }
        }

        internal override void SetCurrPower(float i_CurrPower)
        {
            if (i_CurrPower>=0 && i_CurrPower <= r_MaxGasAmount)
            {
                m_CurrGasAmount = i_CurrPower;
            }
            else
            {
                throw new ValueOutOfRangeException("Value is Out Of Range", 0, r_MaxGasAmount);
            }
        }

        public enum eGasType
        {
            Octan98=1,
            Octan96,
            Octan95,
            Soler
        }
    }
}
