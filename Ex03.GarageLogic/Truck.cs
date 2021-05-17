using System;


namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsHazardousMaterial;
        private float m_MaxCarryWeight;

        public Truck() : base(16, 26, new Gasoline(Gasoline.EGasType.Soler, 120))
        {

        }

        public void SetMaxCarryWeight(float i_MaxWeight)
        {
            m_MaxCarryWeight = i_MaxWeight;
        }

        public void SetIsHazardMaterial(bool i_IsHazardMaterial)
        {
            m_IsHazardousMaterial = i_IsHazardMaterial;
        }
    }
}
