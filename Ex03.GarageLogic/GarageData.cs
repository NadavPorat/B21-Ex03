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
       
        public void Insert(VehicleInfo i_VehicleInfo)
        {
            m_VehicleList.Add(i_VehicleInfo.vehicle.LicensePlate, i_VehicleInfo);
        }
    }
}
