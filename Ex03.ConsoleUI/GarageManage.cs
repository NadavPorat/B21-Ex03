using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManage
    {
        private UI m_UI;
        private GarageData m_Data;

        public GarageManage(UI i_Ui)
        {
            m_UI = i_Ui;
            m_Data = new GarageData();
        }

        public void Open()
        {
            m_UI.Menu();
            int actionChoise = m_UI.GetUserActionChoise();
            bool garageOpen = true;

            while (garageOpen)
            {
                try
                {
                    switch (actionChoise)
                    {
                        case 1:
                            {
                                InsertVehicle();
                                break;
                            }
                        case 2:
                            {
                                m_UI.DisplayLicensePlates(m_Data);

                                break;
                            }
                        case 3:
                            {
                                ChangeVehicleStatus();
                                break;
                            }
                        case 4:
                            {
                                InflateWheelsToMaximum();
                                break;
                            }
                        case 5:
                            {
                                break;
                            }
                        case 6:
                            {
                                break;
                            }
                        case 7:
                            {
                                DisplayVehicleInfo();
                                break;
                            }
                        case 8:
                            {
                                garageOpen = false;
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    m_UI.AnnounceError(ex);
                    
                }

                m_UI.Menu();
                actionChoise = m_UI.GetUserActionChoise();
            }
        }

        public void InsertVehicle()
        {
            string licensePlate = m_UI.GetVehicleLicensePlate();

            if (m_Data.Contains(licensePlate))
            {
                handleAlreadyExistSituation(licensePlate);
            }
            else
            {
                Vehicle v = Creator.Create(m_UI.GetVehicleType());
                v.LicensePlate = licensePlate;
                VehicleInfo vInfo = new VehicleInfo(v);
                InsertVehicleDetails(vInfo);
                InsertSpecificTypeOfVehicleDetails(vInfo);
                insertEngineDetails(vInfo);
                m_Data.Insert(vInfo);
            }
        }

        private void handleAlreadyExistSituation(string i_LicensePlate)
        {
            m_Data.FindVehicle(i_LicensePlate).SetInProccesStatus();
        }

        private void insertEngineDetails(VehicleInfo i_VehicleInfo)
        {
            bool goodInput = false;

            while (!goodInput)
            {
                try
                {
                    i_VehicleInfo.vehicle.Engine.SetCurrPower(m_UI.GetLeftPower(i_VehicleInfo.vehicle.Engine));
                    goodInput = true;
                }
                catch (Exception ex)
                {
                    m_UI.AnnounceError(ex);
                }
            }

        }

        public void InsertVehicleDetails(VehicleInfo i_VehicleInfo)
        {
            foreach(EInfoType info in Enum.GetValues(typeof(EInfoType)))
            {
                ValidationLoop(info , i_VehicleInfo);
            }
        }

        public void ChangeVehicleStatus()
        {
            string licensePlate = m_UI.GetVehicleLicensePlate();
         
            if (m_Data.Contains(licensePlate))
            {
                int newStatus = m_UI.GetVehicleNewStatus();
                VehicleInfo.EVehicleStatus vehicleNewStatus = (Ex03.GarageLogic.VehicleInfo.EVehicleStatus)(newStatus);
                m_Data.FindVehicle(licensePlate).Status = vehicleNewStatus;                
            }
            else
            {
                throw (new ArgumentException("The Vehcle Not Exist"));
            }
        }

        public void InsertSpecificTypeOfVehicleDetails(VehicleInfo i_VehicleInfo)
        {
            Type vType = i_VehicleInfo.vehicle.GetType();

            foreach(FieldInfo info in vType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                object someInfo = null;
                m_UI.GetInfo(info, ref someInfo);
                i_VehicleInfo.vehicle.SetInfo(info, someInfo);
            }
        }

        public void ValidationLoop(EInfoType i_InfoToAsk, VehicleInfo i_VehicleInfo)
        {
            bool goodInput = false;

            while (!goodInput)
            {
                try
                {
                    switch (i_InfoToAsk)
                    {
                        case EInfoType.ModelName:
                            {
                                i_VehicleInfo.SetVehicleModelName(m_UI.GetModelName());
                                break;
                            }

                        case EInfoType.WheelsManufactor:
                            {
                                i_VehicleInfo.SetWheelsManufacturer(m_UI.GetWheelsManufacturer());
                                break;
                            }

                        case EInfoType.CurrWheelsAirPressure :
                            {
                                i_VehicleInfo.SetWheelsCurrAirPressure(m_UI.GetAirPressure());
                                break;
                            }

                        case EInfoType.OwnerName:
                            {
                                i_VehicleInfo.VehicleOwnerName = m_UI.GetVehicleOwnerName();
                                break;
                            }

                        case EInfoType.OwnerPhone:
                            {
                                i_VehicleInfo.VehicleOwnerPhone = m_UI.GetVehicleOwnerPhone();
                                break;
                            }
                    }

                    goodInput = true;
                }
                catch (Exception ex)
                {
                    m_UI.AnnounceError(ex);
                    goodInput = false;
                }
            }
        }

        public void InflateWheelsToMaximum()
        {
            m_Data.InflateWheelsToMax(m_UI.GetVehicleLicensePlate());
        }

        public void DisplayVehicleInfo()
        {
            StringBuilder allVehiclesString = m_Data.GetVehicleInfoString(m_UI.GetVehicleLicensePlate());
            Console.WriteLine(allVehiclesString);
        }

         public enum EInfoType
        {
            ModelName,
            WheelsManufactor,
            CurrWheelsAirPressure,
            OwnerName,
            OwnerPhone
        }
    }
}
