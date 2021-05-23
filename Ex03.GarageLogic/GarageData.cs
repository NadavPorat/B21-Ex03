using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageData
    {
        private readonly Dictionary<string, VehicleInfo> r_VehicleList;

        public GarageData()
        {
            r_VehicleList = new Dictionary<string, VehicleInfo>();
        }

        public static string FixNameToPrint(string i_Name)
        {
            string fixStr = null;
            int i = 1;

            int idx = i_Name.ToString().IndexOf("_");
            i_Name = i_Name.ToString().Substring(idx + 1);
            fixStr += i_Name[0];

            while (i < i_Name.Length)
            {
                if (char.IsUpper(i_Name[i]) && char.IsLower(i_Name[i - 1]))
                {
                    fixStr += " ";
                }

                fixStr += i_Name[i];
                i++;
            }

            return fixStr;
        }

        public bool Contains(string i_LicenseNumber)
        {
            return r_VehicleList.ContainsKey(i_LicenseNumber);
        }

        public VehicleInfo FindVehicle(string i_LicenseNumber)
        {
            VehicleInfo VehicleInfo = null;

            if (r_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInfo))
            {
                return VehicleInfo;
            }
            else
            {
                throw new ArgumentException("Vehicle NOT Exist");
            }
        }

        public void Insert(VehicleInfo i_VehicleInfo)
        {
            r_VehicleList.Add(i_VehicleInfo.Vehicle.LicensePlate, i_VehicleInfo);
        }

        public StringBuilder GetVehicleInfoString(string i_LicensePlate)
        {
           return FindVehicle(i_LicensePlate).GetCard();
        }

        public string GetListLicensePlate()
        {
            string listVehicles = null;
            int countVehicle = 0;

            foreach (VehicleInfo currVale in r_VehicleList.Values)
            {
                if(countVehicle == 0)
                {
                    listVehicles += "All Vehicles List: \n";
                }

                countVehicle++;
                listVehicles += string.Format("{0}. {1}\n", countVehicle, currVale.Vehicle.LicensePlate);
            }

            return listVehicles;
        }

        public string GetListLicensePlateByStatus(VehicleInfo.eVehicleStatus i_EVehicleStatus)
        {
            string listByStatus = null;
            int countVehicle = 0;

                foreach (VehicleInfo currVale in r_VehicleList.Values)
                {
                    if (currVale.Status.Equals(i_EVehicleStatus))
                    {
                    if (countVehicle == 0)
                    {
                        string fixName = GarageData.FixNameToPrint(i_EVehicleStatus.ToString());
                        listByStatus += string.Format("{0} Vehicles List: \n", fixName);
                    }

                    countVehicle++;
                    listByStatus += string.Format("{0}. {1}\n", countVehicle, currVale.Vehicle.LicensePlate);
                    }
                }

            return listByStatus;
        }

        public void InflateWheelsToMax(string i_LicensePlate)
        {
            VehicleInfo v = FindVehicle(i_LicensePlate);
            v.Vehicle.InflateWheelsToMax();
        }

        public void FillGas(string i_VehicleLicensePlate, Gasoline.eGasType i_GasType, float i_ToAdd)
        {
            VehicleInfo currVehicleInfo = FindVehicle(i_VehicleLicensePlate);
            currVehicleInfo.Vehicle.RefillGas(i_ToAdd, i_GasType);
            currVehicleInfo.Vehicle.UpdatePowerPercentage();
        }

        public void FillElectric(string i_VehicleLicensePlate, float i_ToAdd)
        {
            Vehicle currVehicle = FindVehicle(i_VehicleLicensePlate).Vehicle;
           currVehicle.RefillElctricVehicle(i_ToAdd);
            currVehicle.UpdatePowerPercentage();
        }
    }
}
