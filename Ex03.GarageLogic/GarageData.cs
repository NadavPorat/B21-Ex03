using System;
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



        public bool Contains(string i_LicenseNumber)
        {
            return m_VehicleList.ContainsKey(i_LicenseNumber);
        }

        public VehicleInfo FindVehicle(string i_LicenseNumber)
        {
            VehicleInfo VehicleInfo = null;

            bool isVehicle = m_VehicleList.TryGetValue(i_LicenseNumber, out  VehicleInfo);

            return VehicleInfo;

        }
       
        public void Insert(string i_OwnerName, string i_OwnerPhone, Vehicle i_VehicleToInsert)
        {
            VehicleInfo vehicleInfo = new VehicleInfo(i_OwnerName, i_OwnerPhone, i_VehicleToInsert);
            m_VehicleList.Add(i_VehicleToInsert.VehicleLicensePlate, vehicleInfo);
        }

        public void UpdateModelName(string i_ModelName)
        {
       //   m_VehicleList.Add("72-402-76",new VehicleInfo(( i_OwnerName,  i_OwnerPhone, i_Vehicle))
        }

    }
}
