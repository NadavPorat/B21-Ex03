using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.ConsoleUI
{

    public class UI
    {

        public  void Menu()
        {
            Console.WriteLine(
@"Please Choose :
1. Add a new vehicle
2. Display license plates
3. Change a vehicle's status
4. Inflate a vehicle's tires to maximum
5. Refuel a fuel-based vehicle
6. Charge an electric-based vehicle
7. Display vehicle information
8. Exit");

        }
        public enum EVehicleStatus
        {
            InProcces = 1,
            Fixed,
            Paid
        }
        public void DisplayLicensePlates(GarageData i_Data)
        {
            string choice;
            int choiseNum = 0;
            int numToPrint = 1;

            Console.WriteLine("Hi! Here is The List Of Vehicles In The Garage: ");
            foreach (string key in i_Data.GetListOfVeihcleInTheGarage().Keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine();
            String s = string.Format("{0}", "You Can Filtering By Current Satatus Or Continue: ");

            foreach (string vType in Enum.GetNames(typeof(EVehicleStatus)))
            {
                s += string.Format("\n {0}. {1} ", numToPrint, vType);
                numToPrint++;
            }
            s += string.Format("\n {0}. {1} ", numToPrint, "Continue");

            choice = Console.ReadLine();
            choiseNum = int.Parse(choice);

            if (choiseNum >=  1 || choiseNum <= 3)
            {
                PrintListVehcleBySatatus(choiseNum, i_Data);
            }
            
           

        }

       public void PrintListVehcleBySatatus(int i_ChoiseNum, GarageData i_Data)
        {
            StringBuilder fillterSatatusVehicles = new StringBuilder();
            List<VehicleInfo> ListVehiclesBySatatus = new List<VehicleInfo>();
           int numToPrint = 1;

            switch (i_ChoiseNum)
            {
                case 1:
                    {

                        fillterSatatusVehicles.AppendLine("Vehicles in Procces : ");
                        ListVehiclesBySatatus = i_Data.GetListVehiclesBySatatus((GarageLogic.EVehicleStatus)EVehicleStatus.InProcces);
                        break;
                    }
                case 2:
                    {
                        fillterSatatusVehicles.AppendLine("Fixed Vehicles: ");
                        ListVehiclesBySatatus = i_Data.GetListVehiclesBySatatus((GarageLogic.EVehicleStatus)EVehicleStatus.Fixed);
                        break;
                    }
                case 3:
                    {

                        fillterSatatusVehicles.AppendLine("Paid Vehicles : ");
                        ListVehiclesBySatatus = i_Data.GetListVehiclesBySatatus((GarageLogic.EVehicleStatus)EVehicleStatus.Paid);
                        break;
                    }

            }
            foreach (VehicleInfo info in ListVehiclesBySatatus)
            {
                fillterSatatusVehicles.AppendFormat("{0}. {1}.", numToPrint.ToString(), info.vehicle.LicensePlate);
                fillterSatatusVehicles.AppendLine();
                numToPrint++;
            }
            Console.WriteLine(fillterSatatusVehicles);

        }

        public int GetUserActionChoise()
        {
            string choise = Console.ReadLine();
            int userChoise;

           while( !int.TryParse(choise,out userChoise) || userChoise<1 || userChoise>8 )
            {
                choise = Console.ReadLine();
            }

            return userChoise;
        }

        public Creator.EVehicleType GetVehicleType()
        {
            string choice;
            string s = string.Format("{0}", "Please Choose a Vehicle Type: ");
            int numToPrint = 1;

            foreach(string vType in Enum.GetNames(typeof(Creator.EVehicleType)))
            {
                s += string.Format("\n {0}. {1} " , numToPrint, vType);
                numToPrint++;
            }

            Console.WriteLine(s);
       
            choice = Console.ReadLine();
            int choiseNum = int.Parse(choice);
         
            while (!Enum.IsDefined(typeof(Creator.EVehicleType), choiseNum))
            {
                Console.WriteLine("Error,Please Enter Again: ");
                choice = Console.ReadLine();
                choiseNum = int.Parse(choice);
            }

           object carType = Enum.Parse(typeof(Creator.EVehicleType), choice);

            return (Creator.EVehicleType)carType;
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
            
            Console.WriteLine("Please Enter Current Air Pressure: ");

            currAir = Console.ReadLine();
            float FcurrAir=float.Parse(currAir);

            return FcurrAir;
        }

        public string GetWheelsManufacturer()
        {
            string manufacturer;

            Console.WriteLine("Please Enter The Wheels Manufacturer Name: ");
            manufacturer = Console.ReadLine();

            return manufacturer;
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

        public void GetInfo(FieldInfo i_info, ref object io_ChoiseToReturn)
        {
            string toAskUser = string.Format(@"Please Enter {0} :", i_info.Name);

            if (i_info.FieldType.IsEnum)
            {
                io_ChoiseToReturn = GetEnumInfo(toAskUser, i_info);
            }
            else if (i_info.FieldType.Equals(typeof(float))||i_info.FieldType.Equals(typeof(int)))
            {
                io_ChoiseToReturn = GetNumericInfo(toAskUser);
            }
            else if (i_info.FieldType.Equals(typeof(System.Boolean)))
            {
                io_ChoiseToReturn = GetBoolInfo(toAskUser);
            }
        }

        public object GetBoolInfo(string i_toAskUser)
        {
            int choise;
            i_toAskUser += String.Format("\n Choose :\n 1. YES \n 2. no");

            Console.WriteLine(i_toAskUser);
            string userChoise = Console.ReadLine();

            while (!int.TryParse(userChoise, out choise) || (choise!=1 && choise !=2))
            {
                Console.WriteLine("Error! Please Enter Again: ");
                userChoise = Console.ReadLine();
            }

            return choise;
        }

        public object GetNumericInfo(string i_toAskUser)
        {
            Console.WriteLine(i_toAskUser);

            string userChoise = Console.ReadLine();
            float choise;

            while (!float.TryParse(userChoise, out choise))
            {
                Console.WriteLine("Error! Please Enter Again: ");
                userChoise = Console.ReadLine();
            }

            return choise;
        }

        public object GetEnumInfo(string i_toAskUser, FieldInfo i_Info)
        {
            int numOfOption = 1;
            i_toAskUser += string.Format("\n The Options Are: ");

            foreach (string Type in i_Info.FieldType.GetEnumNames())
            {
                i_toAskUser += string.Format("\n {0}. {1} ", numOfOption, Type);
                numOfOption++;
            }


            Console.WriteLine(i_toAskUser);

            string userChoise = Console.ReadLine();
            int choise;

            while (!int.TryParse(userChoise, out choise) || choise < 0 || choise > numOfOption - 1)
            {
                Console.WriteLine("Error! Please Enter Again: ");
                userChoise = Console.ReadLine();
            }

            return choise;
        }

        public float GetLeftPower(Engine i_EngineType)
        {
            string askUserStr = string.Format("Please Enter The ");

            if(i_EngineType.GetType()== typeof(Gasoline))
            {
                askUserStr+=string.Format("Curr Gasoline Amount: ");
            }
            else if (i_EngineType.GetType()==typeof(Electric))
            {
                askUserStr += string.Format("Power Left Time: ");
            }

            return (float)GetNumericInfo(askUserStr);
        }

        public string GetVehicleLicensePlate()
        {
            string VehicleLicensePlate;

            Console.WriteLine("Please Enter Vehicle License Plate: ");
            Console.WriteLine();
            VehicleLicensePlate = Console.ReadLine();

            return VehicleLicensePlate;
        }

       public void AnnounceError(Exception ex)
        {
            Console.WriteLine(ex);
        }

        ////////////////////////// Vehicle Info//////////////////////////////////////////


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


