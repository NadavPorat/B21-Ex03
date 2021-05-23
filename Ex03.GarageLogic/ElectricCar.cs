namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        public ElectricCar() : base(new Electric(3.2f))
        {
        }
    }
}
