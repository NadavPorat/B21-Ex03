using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public abstract void RefillEnergy(float i_HoursToAdd);

        public abstract void SetCurrPower(float i_CurrPower);

        public abstract StringBuilder GetDetails();
    }
}
