using System;


namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsHazardousMaterial;
        private float m_MaxCarryWeight;

        public Truck() :base(16, 26, new Gasoline(Gasoline.EGasType.Soler,120))
        { 

        }
    }
}
