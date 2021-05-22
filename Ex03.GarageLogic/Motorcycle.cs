using System;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLisenceType m_LicenseType;
        protected int? m_EngineCapacity;

        public Motorcycle(Engine i_EngineType) : base(2, 30, i_EngineType)
        {
            m_EngineCapacity = null;
        }

        public override void SetInfo(FieldInfo i_FieldInfo, Object i_ValueToPut)
        {
            if (i_FieldInfo.FieldType == m_LicenseType.GetType())
            {
                m_LicenseType = (eLisenceType)i_ValueToPut;
            }
            else if (i_FieldInfo.FieldType == typeof(int?))
            {
                m_EngineCapacity = (int)(i_ValueToPut as float?);
            }
        }

        public enum eLisenceType
        {
            BB=1,
            AA,
            B1,
            A
        }
    }
}
