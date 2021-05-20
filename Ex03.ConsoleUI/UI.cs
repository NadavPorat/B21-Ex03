using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Ex03.GarageLogic;

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

        public int GetUserActionChoise()
        {
            bool goodInput = false;
            string choise = Console.ReadLine();
            int userChoise = 0;

            while (!goodInput)
            {
                try
                {
                    userChoise = int.Parse(choise);
                    Validation.IsInRange(userChoise, 1, 8);
                    goodInput = true;
                }
                catch(Exception ex)
                {
                    AnnounceError(ex);
                    choise = Console.ReadLine();
                }
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
            return GetLettesAndDigitsString("Please Enter Your Vehicle Model Name:");
        }

        public float GetAirPressure()
        {
            Console.WriteLine(@"Please Enter Your Wheels Current Air Pressure:
");
            return GetFloatNumber();
        }

        private float GetFloatNumber()
        {
            float choise;
            string userInput = Console.ReadLine();

            while (!float.TryParse(userInput,out choise))
            {
                    Console.WriteLine(@"Please Enter Again:
");
                  userInput = Console.ReadLine();
 
            }

            return choise;
        }

        private string GetOnlyDigitsString()
        {
            bool goodInput = false;
            string userInput = Console.ReadLine();

            while (!goodInput)
            {
                try
                {
                    Validation.IsOnlyDigits(userInput);
                    goodInput = true;
                }
                catch (Exception ex)
                {
                    AnnounceError(ex);
                    Console.WriteLine(@"Please Enter Again:
");
                    userInput = Console.ReadLine();
                }
            }

            return userInput;
        }

        public string GetWheelsManufacturer()
        {
            return GetLettesAndDigitsString("Please Enter Your Vehicle Wheels Manufaturer:");
        }

        public void GetInfo(FieldInfo i_info, ref object io_ChoiseToReturn)
        {
            string toAskUser = string.Format(@"Please Enter {0} :", i_info.Name);

            if (i_info.FieldType.IsEnum)
            {
                io_ChoiseToReturn = GetEnumInfo(toAskUser, i_info);
            }
            else if (i_info.FieldType == typeof(float?) || i_info.FieldType == typeof(int?))
            {
                io_ChoiseToReturn = GetNumericInfo(toAskUser);
            }
            else if (i_info.FieldType== typeof(System.Boolean))
            {
                io_ChoiseToReturn = GetBoolInfo(toAskUser);
            }
            else ////Gets Any Info From User-the object class wil handle validation. To support futer members typs.
            {
                io_ChoiseToReturn = Console.ReadLine();
            }
        }

        public object GetBoolInfo(string i_toAskUser)
        {
            bool goodInput = false;
            int choise = 0;
            string userChoise;
            i_toAskUser += String.Format("\n Choose :\n 1. YES \n 2. no");
            Console.WriteLine(i_toAskUser);

            while(!goodInput)
            { 
               userChoise = GetOnlyDigitsString();
                choise= int.Parse(userChoise);

                try
                {
                    Validation.IsInRange(choise, 1, 2);
                    goodInput = true;
                }
                catch (Exception ex)
                {
                    AnnounceError(ex);
                    Console.WriteLine(@"Please Enter Again:
");
                }
            }

            return choise;
        }

        public string GetNumericInfo(string i_toAskUser)
        {
            Console.WriteLine(i_toAskUser);
            return GetOnlyDigitsString();
        }

        public object GetEnumInfo(string i_toAskUser, FieldInfo i_Info)
        {
            int numOfOption = 1, choise = 0;
            bool goodInput = false;
            string userChoise;

            i_toAskUser += string.Format("\n The Options Are: ");

            foreach (string Type in i_Info.FieldType.GetEnumNames())
            {
                i_toAskUser += string.Format("\n {0}. {1} ", numOfOption, Type);
                numOfOption++;
            }

            Console.WriteLine(i_toAskUser);

            while (!goodInput)
            {
                try
                {
                    userChoise = GetOnlyDigitsString();
                    choise = int.Parse(userChoise);
                    Validation.IsInRange(choise, 0, numOfOption - 1);
                    goodInput = true;
                }
                catch (Exception ex)
                {
                    AnnounceError(ex);
                    Console.WriteLine(@"Please Enter Again:
");
                }
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

            Console.WriteLine(askUserStr);
            return GetFloatNumber();
        }

        private string GetLettesAndDigitsString(string i_MsgToUser)
        {
            Console.WriteLine(@"{0}
", i_MsgToUser);

            bool goodInput = false;
            string userInput = Console.ReadLine();

            while (!goodInput)
            {
                try
                {
                    Validation.IsOnlyDigitsAndLetters(userInput);
                    goodInput = true;
                }
                catch (Exception ex)
                {
                    AnnounceError(ex);
                    Console.WriteLine(@"Please Enter Again:
");
                    userInput = Console.ReadLine();
                }

            }

            return userInput;
        }

        public string GetVehicleLicensePlate()
        {
            return GetLettesAndDigitsString("Please Enter Your Vehicle License Plate:");
        }

       public void AnnounceError(Exception ex)
        {
            Console.WriteLine(@"Error: {0} .", ex.Message);
        }

        public string GetVehicleOwnerName()
        {
            return GetLettesAndDigitsString("Please Enter The Vehicle Owner Name: ");
        }

        public string GetVehicleOwnerPhone()
        {
            Console.WriteLine("Please Enter The Vehicle Owner Phone: ");
            return GetOnlyDigitsString();
        }

    }
}


