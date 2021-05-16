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

        public VehicleInfo(string i_OwnerName, string i_OwnerPhone)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_VehicleStatus = EVehicleStatus.InProcces;
        }

    }
}
