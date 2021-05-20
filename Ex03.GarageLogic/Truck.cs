using System;
using System.Reflection;


namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsCarryHazardMaterials;
        private float? m_MaxCarryWeight;

        public Truck() : base(16, 26, new Gasoline(Gasoline.EGasType.Soler, 120))
        {

        }

        public void SetMaxCarryWeight(float i_MaxWeight)
        {
            m_MaxCarryWeight = i_MaxWeight;
        }

        public void SetIsHazardMaterial(bool i_IsHazardMaterial)
        {
            m_IsCarryHazardMaterials = i_IsHazardMaterial;
        }

        public override void SetInfo(FieldInfo i_FieldInfo, Object i_ValueToPut)
        {
            if (i_FieldInfo.FieldType.GetTypeInfo() == m_IsCarryHazardMaterials.GetType())
            {
                m_IsCarryHazardMaterials = (int)i_ValueToPut == 1 ?  true : false;
            }
            else if (i_FieldInfo.FieldType == typeof(float?))
            {
                m_MaxCarryWeight = float.Parse((string)i_ValueToPut);
            }
        }
    }
}
