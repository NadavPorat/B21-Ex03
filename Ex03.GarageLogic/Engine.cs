using System;


namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public abstract void RefillEnergy(float i_ToAdd);
       // public abstract Gasoline.EGasType GetGasType();
        public abstract void SetCurrPower(float i_CurrPower);
    }
}
