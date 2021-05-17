using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{

    public class UI
    {

        public Creator.EVehicleType GetVehicleType()
        {
            string choice;
            Console.WriteLine("Plase Choes Vehicle Type: ");
            Console.WriteLine();
            Console.WriteLine("1. Gas Car");
            Console.WriteLine("2. Electric Car");
            Console.WriteLine("3. Gas Motorcycle");
            Console.WriteLine("4. Electric Motorcycle");
            Console.WriteLine("5. Truk");
            choice = Console.ReadLine();
            int Numchoice = Int32.Parse(choice);

            while (Numchoice < 1 || Numchoice > 5)
            {
                Console.WriteLine("Eror,Plase Enter Agine: ");
                choice = Console.ReadLine();
                Numchoice = Int32.Parse(choice);
            }


            Creator.EVehicleType eCarType = 0;

            switch (Numchoice)
            {
                case 1:
                    eCarType = Creator.EVehicleType.GasCar;
                    break;
                case 2:
                    eCarType = Creator.EVehicleType.ElectricCar;
                    break;
                case 3:
                    eCarType = Creator.EVehicleType.GasMotor;
                    break;
                case 4:
                    eCarType = Creator.EVehicleType.ElectricMotor;
                    break;
                case 5:
                    eCarType = Creator.EVehicleType.Truck;
                    break;
            }
            return eCarType;

        }

        public void GetVehicleDetailes()
        {

        }


        public string GetModelName()
        {
            return "mazda";
        }

        public float GetAirPressure()
        {
            return 2.3f;
        }
    }
}


