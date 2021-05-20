using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
        }

        public ValueOutOfRangeException(string i_Msg, float i_MinValue, float i_MaxValue) : base(string.Format("{0} . Minimum value: {1} Maximum value: {2}", i_Msg, i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MaxVal
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinVal
        {
            get
            {
                return m_MinValue;
            }
        }

    }
}
