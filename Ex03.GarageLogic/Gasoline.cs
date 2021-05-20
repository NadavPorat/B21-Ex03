using System;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Gasoline: Engine
    {
        private EGasType m_GasType;
        private float m_CurrGasAmount;
        private float m_MaxGasAmount;

        public Gasoline(EGasType i_GasType, float i_MaxGasAmount)
        {
            m_GasType = i_GasType;
            m_MaxGasAmount = i_MaxGasAmount;
        }

        public Gasoline(EGasType i_GasType, float i_CurrGasAmount, float i_MaxGasAmount)
        {
            m_GasType = i_GasType;
            m_CurrGasAmount = i_CurrGasAmount;
            m_MaxGasAmount = i_MaxGasAmount;
        }

        public override void RefillEnergy(float i_GassToAdd)
        {
            //if (m_GasType == i_GasType)
            //{
            //    if (m_MaxGasAmount >= m_CurrGasAmount + i_GassToAdd)
            //    {
            //        m_CurrGasAmount = m_CurrGasAmount + i_GassToAdd;
            //    }
            //}
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
            if (i_CurrPower <= m_MaxGasAmount)
            {
                m_CurrGasAmount = i_CurrPower;
            }
            else
            {
                throw new ValueOutOfRangeException("Value is Out Of Range", 0, m_MaxGasAmount);
            }
        }

        public enum EGasType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }


    }
}
