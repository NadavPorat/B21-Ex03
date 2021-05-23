using System;
using System.Reflection;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class InputOutput
    {
        internal void Menu()
        {
            Console.Clear();

            Console.WriteLine(
@"Please Choose :
1. Add a new Vehicle
2. Display license plates
3. Change a Vehicle's status
4. Inflate a Vehicle's tires to maximum
5. Refuel a fuel-based Vehicle
6. Charge an electric-based Vehicle
7. Display Vehicle information
8. Exit");
        }

        internal void PrintMsg(string i_ToPrint)
        {
            Console.WriteLine(i_ToPrint);
        }

        internal bool AskUserFilterChoise()
        {
            bool isWithFilter = false;
            string strOut = "Do You Want A List Of Vehicles By Specific Status ?";

            object choise = getBoolInfo(strOut);

            if((int)choise == 1)
            {
                isWithFilter = true;
            }

            return isWithFilter;
        }

        internal VehicleInfo.eVehicleStatus GetStatus()
        {
           string strOut = "Which Vehicles You Want To See: ";

           return (VehicleInfo.eVehicleStatus)getEnumInfo(strOut, Enum.GetNames(typeof(VehicleInfo.eVehicleStatus)));
        }

        internal void AskUserPressSomethingToCont()
        {
            Console.WriteLine("Please Enter Any Key To Continue...");
            Console.ReadLine();
        }

        internal int GetUserActionChoise()
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
                catch (Exception ex)
                {
                    AnnounceError(ex);
                    choise = Console.ReadLine();
                }
            }

            Console.Clear();
            return userChoise;
        }

        internal Creator.eVehicleType GetVehicleType()
        {
            return (Creator.eVehicleType)getEnumInfo("Please Choose a Vehicle Type ", Enum.GetNames(typeof(Creator.eVehicleType)));
        }

        internal string GetModelName()
        {
            return getLettesAndDigitsString("Please Enter Your Vehicle Model Name:");
        }

        internal float GetAirPressure()
        {
            Console.WriteLine(@"Please Enter Your Wheels Current Air Pressure:
");
            return getFloatNumber();
        }

        private float getFloatNumber()
        {
            float choise;
            string userInput = Console.ReadLine();

            while (!float.TryParse(userInput, out choise))
            {
                Console.WriteLine(@"Please Enter Again:
");
                userInput = Console.ReadLine();
            }

            return choise;
        }

        private string getOnlyDigitsString()
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

        internal string GetWheelsManufacturer()
        {
            return getLettesAndDigitsString("Please Enter Your Vehicle Wheels Manufaturer:");
        }

        internal void GetInfo(FieldInfo i_Info, ref object io_ChoiseToReturn)
        {
            string fixName;
            fixName = GarageData.FixNameToPrint(i_Info.Name);

            string toAskUser = string.Format(@"Please Enter {0} :", fixName);

            if (i_Info.FieldType.IsEnum)
            {
                io_ChoiseToReturn = getEnumInfo(toAskUser, i_Info.FieldType.GetEnumNames());
            }
            else if (i_Info.FieldType == typeof(float?) || i_Info.FieldType == typeof(int?))
            {
                io_ChoiseToReturn = getNumericInfo(toAskUser);
            }
            else if (i_Info.FieldType == typeof(bool?))
            {
                io_ChoiseToReturn = getBoolInfo(toAskUser);
            }
            else
            {
                ////Gets Any Info From User-the object class wil handle validation. To support futer members typs.
                io_ChoiseToReturn = Console.ReadLine();
            }
        }

        private object getBoolInfo(string i_toAskUser)
        {
            bool goodInput = false;
            int choise = 0;
            string userChoise;
            i_toAskUser += string.Format("\n Choose :\n 1. YES \n 2. No");
            Console.WriteLine(i_toAskUser);

            while(!goodInput)
            {
                userChoise = getOnlyDigitsString();
                choise = int.Parse(userChoise);

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

        private float getNumericInfo(string i_toAskUser)
        {
            Console.WriteLine(i_toAskUser);
            return getFloatNumber();
        }

        private object getEnumInfo(string i_toAskUser, string[] i_EnumString)
        {
            int numOfOption = 1, choise = 0;
            bool goodInput = false;
            string userChoise;

            i_toAskUser += string.Format("\n The Options Are: ");

            foreach (string enumName in i_EnumString)
            {
               string fixedName = GarageData.FixNameToPrint(enumName);
                i_toAskUser += string.Format("\n {0}. {1} ", numOfOption, fixedName);
                numOfOption++;
            }

            Console.WriteLine(i_toAskUser);

            while (!goodInput)
            {
                try
                {
                    userChoise = getOnlyDigitsString();
                    choise = int.Parse(userChoise);
                    Validation.IsInRange(choise, 1, numOfOption - 1);
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

        internal Gasoline.eGasType GetGasTypeToFill()
        { 
            object gasType = getEnumInfo("Please Enter The Gasoline Type: ", Enum.GetNames(typeof(Gasoline.eGasType)));
            return (Gasoline.eGasType)Enum.Parse(typeof(Gasoline.eGasType), gasType.ToString());
        }

        internal float GetEnergyAmountToAdd()
        {
            Console.WriteLine("Please Enter The Energy Amount To Add: ");
            float powerToAdd = getFloatNumber();
            if(powerToAdd < 0)
            {
                throw new ArgumentException("Amount To Add Must Be Positive.");
            }

            return powerToAdd;
        }

        internal float GetLeftPower(Type i_EngineType)
        {
            string askUserStr = string.Format("Please Enter The ");

            if(i_EngineType == typeof(Gasoline))
            {
                askUserStr += string.Format("Curr Gasoline Amount: ");
            }
            else if (i_EngineType == typeof(Electric))
            {
                askUserStr += string.Format("Power Left Time: ");
            }

            Console.WriteLine(askUserStr);
            return getFloatNumber();
        }

        private string getLettesAndDigitsString(string i_MsgToUser)
        {
            Console.WriteLine(
@"{0}", i_MsgToUser);

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

        internal VehicleInfo.eVehicleStatus GetVehicleNewStatus()
        { 
            object newStatus = getEnumInfo("Please Enter The New Status :", Enum.GetNames(typeof(VehicleInfo.eVehicleStatus)));
            return (VehicleInfo.eVehicleStatus)Enum.Parse(typeof(VehicleInfo.eVehicleStatus), newStatus.ToString());
        }

        internal string GetVehicleLicensePlate()
        {
            return getLettesAndDigitsString("Please Enter Your Vehicle License Plate:");
        }

        internal void AnnounceError(Exception ex)
        {
            Console.WriteLine(@"Error: {0}.", ex.Message);
        }

        internal string GetVehicleOwnerName()
        {
            return getLettesAndDigitsString("Please Enter The Vehicle Owner Name: ");
        }

        internal string GetVehicleOwnerPhone()
        {
            Console.WriteLine("Please Enter The Vehicle Owner Phone: ");
            return getOnlyDigitsString();
        }
    }
}
