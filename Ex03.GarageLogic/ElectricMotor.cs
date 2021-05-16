using System;


namespace Ex03.GarageLogic
{
    public class ElectricMotor: Motorcycle
    {
        public ElectricMotor() : base(new Electric(1.8f))
        {

        }
    }
}
