namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
           GarageManage Garage = new GarageManage(new InputOutput());
           Garage.Open();
        }
    }
}
