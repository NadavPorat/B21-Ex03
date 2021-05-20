﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageData
    {
        private Dictionary<string, VehicleInfo> m_VehicleList;

        public GarageData()
        {
            m_VehicleList = new Dictionary<string, VehicleInfo>();
        }

        public Dictionary<string, VehicleInfo> GetListOfVeihcleInTheGarage()
        {
            return m_VehicleList;
        }

        public bool Contains(string i_LicenseNumber)
        {
            return m_VehicleList.ContainsKey(i_LicenseNumber);
        }

        public VehicleInfo FindVehicle(string i_LicenseNumber)
        {
            VehicleInfo VehicleInfo = null;

            if (m_VehicleList.TryGetValue(i_LicenseNumber, out VehicleInfo))
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
            m_VehicleList.Add(i_VehicleInfo.vehicle.LicensePlate, i_VehicleInfo);
        }

        public StringBuilder GetVehicleInfoString(string i_LicensePlate)
        {
           return FindVehicle(i_LicensePlate).GetCard();
        }

        //internal List<VehicleInfo> GetListVehiclesByStatus(EVehicleStatus i_EVehicleStatus)
        //{
        //    List<VehicleInfo> listOfVehicles = new List<VehicleInfo>();

        //    foreach (VehicleInfo currVale in m_VehicleList.Values)
        //    {
        //        if (currVale.Status.Equals( i_EVehicleStatus))
        //        {
        //            listOfVehicles.Add(currVale);
        //        }

        //    }
        //    return listOfVehicles;
        //}
        public string GetListLicensePlateVehiclesByStatus(VehicleInfo.EVehicleStatus i_EVehicleStatus)
        {
            string s = "";
            int countVehicle = 1;
                foreach (VehicleInfo currVale in m_VehicleList.Values)
                {
                    if (currVale.Status.Equals(i_EVehicleStatus))
                    {
                        s += string.Format("{0}. {1}\n", countVehicle, currVale.vehicle.LicensePlate);
                        countVehicle++;
                    }

                }
            
            return s;
        }

        public void InflateWheelsToMax(string i_LicensePlate)
        {
            VehicleInfo v = FindVehicle(i_LicensePlate);
            v.vehicle.InflateWheels();
        }
    }
}
