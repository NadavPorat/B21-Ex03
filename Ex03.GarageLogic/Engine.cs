using System;


namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
       public virtual void fillEnergy(float i_HoursToAdd)
        {

        }

        public abstract void SetCurrPower(float i_CurrPower);
    }
}
