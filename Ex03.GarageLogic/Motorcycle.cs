using System;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        protected ELisenceType m_LicenseType;
        protected int? m_EngineCapacity;

        //public Motorcycle(string i_LicenseType, int i_EngineCapacity, string i_VehicleModel, string i_LicensePlate, float i_CurrEnergyPer, Engine i_EngineType, ) : base(i_VehicleModel, i_LicensePlate, i_CurrEnergyPer, i_EngineType)
        //{
        //    m_LicenseType = i_LicenseType;
        //    m_EngineCapacity = i_EngineCapacity;
        //}

        public Motorcycle(Engine i_EngineType) : base(2, 30, i_EngineType)
        {
        }

        public override void SetInfo(FieldInfo i_FieldInfo, Object i_ValueToPut)
        {
            if (i_FieldInfo.FieldType == m_LicenseType.GetType())
            {
                m_LicenseType = (ELisenceType)i_ValueToPut;
            }
            else if (i_FieldInfo.FieldType == typeof(int?))
            {
                m_EngineCapacity = int.Parse((string)i_ValueToPut) as int?;
            }
        }

        public enum ELisenceType
        {
            BB=1,
            AA,
            B1,
            A
        }
    }
}
