using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        internal abstract float CalcPowerPercentage();

        internal abstract void RefillEnergy(float i_ToAdd);

        internal abstract void SetCurrPower(float i_CurrPower);

        internal abstract StringBuilder GetDetails();
    }
}
