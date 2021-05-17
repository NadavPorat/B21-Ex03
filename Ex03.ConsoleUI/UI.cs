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

        public static void Menu()
        {
            Console.WriteLine("What would you like to do? Write the given number and press enter:");
            Console.WriteLine("1. Add a new vehicle");
            Console.WriteLine("2. Display a list of license numbers in the garage");
            Console.WriteLine("3. Change a vehicle's status");
            Console.WriteLine("4. Inflate a vehicle's tires to maximum");
            Console.WriteLine("5. Refuel a fuel-based vehicle");
            Console.WriteLine("6. Charge an electric-based vehicle");
            Console.WriteLine("7. Display vehicle information");
            Console.WriteLine("8. Exit");
        }

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



        public string GetModelName()
        {
            string modelNmae;

            Console.WriteLine("Plase Enter Modle Nmaee: ");
            Console.WriteLine();
            modelNmae = Console.ReadLine();

            return modelNmae;
        }

        public float GetAirPressure()
        {

            string currAir;
            
            Console.WriteLine("Plase Enter Current Air Pressure: ");
            Console.WriteLine();

            currAir = Console.ReadLine();
            float FcurrAir=float.Parse(currAir);

            return FcurrAir;
        }

        public float GetLeftPowerAmount()
        {

            string LeftPowerAmount;

            Console.WriteLine("Plase Enter Current Air Pressure: ");
            Console.WriteLine();

            LeftPowerAmount = Console.ReadLine();
            float FLeftPower = float.Parse(LeftPowerAmount);

            return FLeftPower;
        }


        public string GetVehicleLicensePlate()
        {
            string VehicleLicensePlate;

            Console.WriteLine("Plase Enter Vehicle License Plate: ");
            Console.WriteLine();
            VehicleLicensePlate = Console.ReadLine();

            return VehicleLicensePlate;
        }

        ////////////////////////// Car Info//////////////////////////////////////////


        public string GetVehicleOwnerName()
        {
            string ownerName;

            Console.WriteLine("Plase Enter Onwer Name: ");
            Console.WriteLine();
            ownerName = Console.ReadLine();

            return ownerName;
        }

        public string GetVehicleOwnerPhone()
        {
            string ownerPhone;

            Console.WriteLine("Plase Enter Onwer Phone: ");
            Console.WriteLine();
            ownerPhone = Console.ReadLine();

            return ownerPhone;
        }

    }
}


