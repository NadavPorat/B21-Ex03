using System;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool? m_IsCarryHazardMaterials;
        private float? m_MaxCarryWeight;

        public Truck() : base(16, 26, new Gasoline(Gasoline.eGasType.Soler, 120))
        {
            m_MaxCarryWeight = null;
            m_IsCarryHazardMaterials = null;
        }

        public override void SetInfo(FieldInfo i_FieldInfo, object i_ValueToPut)
        {
            if (i_FieldInfo.FieldType == typeof(bool?))
            {
                m_IsCarryHazardMaterials = (int)i_ValueToPut == 1 ? true : false;
            }
            else if (i_FieldInfo.FieldType == typeof(float?))
            {
                m_MaxCarryWeight = (float)i_ValueToPut;
            }
        }
    }
}
