using System;


namespace Ex03.GarageLogic
{
    internal class VehicleInfo
    {
        internal enum EVehicleStatus
        {
            InProcces=1,
            Fixed,
            Paid
        }


        private string m_OwnerName;
        private string m_OwnerPhone;
        private EVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public VehicleInfo(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_VehicleStatus = EVehicleStatus.InProcces;
            m_Vehicle = i_Vehicle;
        }

    }
}
