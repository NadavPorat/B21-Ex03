using System;


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

        public override void RefillEnergy(float i_ToAdd)
        {

                if (m_MaxGasAmount >= m_CurrGasAmount + i_ToAdd)
                {
                    m_CurrGasAmount = m_CurrGasAmount + i_ToAdd;
                }
            else
            {
                throw (new ValueOutOfRangeException("More Then Max Gas Amoubt", 0, m_MaxGasAmount));
            }
            
        }
        public void RefillGas(float i_ToAdd,string i_GasType)
        {
            Gasoline.EGasType gasType = (Gasoline.EGasType)Enum.Parse(typeof(Gasoline.EGasType), i_GasType);

            if (gasType.Equals(gasType))
            {
                RefillEnergy(i_ToAdd);
            }
            else
            {
                throw (new ArgumentException("Wrong Gas Type"));
            }
        }

        public EGasType GetGasType()
        {
            return m_GasType;
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
            Octan98=1,
            Octan96,
            Octan95,
            Soler
        }


    }
}
