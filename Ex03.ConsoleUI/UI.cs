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
            string strOut = "";
            int choiseNum = 0;
   

            Console.WriteLine("Hi! Choose Which Vehicle You Want To See: ");
            Console.Write("\n 0. List Of All Vehcles");
            PrintStatus();
            Console.WriteLine(strOut);
            choice = Console.ReadLine();
            choiseNum = int.Parse(choice);

            if(choiseNum == 0)
            {
              
                int numToPrint = 1;
                foreach (string key in i_Data.GetListOfVeihcleInTheGarage().Keys)
                {
                    strOut += string.Format("\n {0}. {1} ", numToPrint, key);
                    numToPrint++;
                }
                Console.WriteLine(strOut);
            }
            else
            {
                PrintListVehcleByStatus(choiseNum, i_Data);
            }

        }
        
       public void PrintListVehcleByStatus(int i_ChoiseNum, GarageData i_Data)
        {
            EVehicleStatus eChoiseSatatus = (EVehicleStatus)i_ChoiseNum;
            string strOut =FixNameToPrint( eChoiseSatatus.ToString());
            strOut += " Vehicles: ";


            string listVehcle = i_Data.GetListLicensePlateVehiclesByStatus((GarageLogic.EVehicleStatus)(eChoiseSatatus));

           
            if (listVehcle.Length == 0)
            {
                Console.WriteLine("No Vehcles In This Status\n");
            }
            else
            {
                Console.WriteLine(strOut);
                Console.WriteLine(listVehcle);

            }

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
                string fixName;
                fixName = FixNameToPrint(vType);
                s += string.Format("\n {0}. {1} " , numToPrint, fixName);
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
            string fixName;
            fixName=FixNameToPrint(i_info.Name);
            string toAskUser = string.Format(@"Please Enter {0} :", fixName);

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

        public void PrintStatus()
        {
            string FixEnumName;
            string strOut = "";
            int numToPrint = 1;

            foreach (string vType in Enum.GetNames(typeof(EVehicleStatus)))
            {
                FixEnumName = FixNameToPrint(vType);
                strOut += string.Format("\n {0}. {1} ", numToPrint, FixEnumName);
                numToPrint++;
            }
            Console.WriteLine(strOut);
        }
        public int  GetVehicleNewStatus()
        {
            string strNewStatus;

            Console.WriteLine("Please Enter The New Vehcle Status: ");
            PrintStatus();
            strNewStatus = Console.ReadLine();
            int numChoose = int.Parse(strNewStatus);
            //if(valdin (asdasd)
            {
               // throw///
            }
            return numChoose;
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
        public string FixNameToPrint(string i_Name)
        { 
           string fixStr = "";
            int i = 0;
            if (i_Name[1]=='_')
            {
                fixStr += i_Name[2];
                i = 3;
            }
            else
            {
                fixStr += i_Name[0];
                i = 1;
            }
            while (i< i_Name.Length)
            {
                if (Char.IsUpper(i_Name[i]))
                {
                    fixStr += " ";
                }
                fixStr += i_Name[i];
                 i++;
            }
           
            return fixStr;

        }

    }

}


