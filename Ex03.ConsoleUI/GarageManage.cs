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
                                insertVehicle();
                                break;
                            }
                        case 2:
                            {
                                displayLicensePlates();
                                break;
                            }
                        case 3:
                            {
                                changeVehicleStatus();
                                break;
                            }
                        case 4:
                            {
                                inflateWheelsToMaximum();
                                break;
                            }
                        case 5:
                            {
                                fillGasVehicle();
                                break;
                            }
                        case 6:
                            {
                                fillElectricVehicle();
                                break;
                            }
                        case 7:
                            {
                                displayVehicleInfo();
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

                if (actionChoise != 8)
                {
                    m_UI.AskUserPressSomethingToCont();
                    m_UI.Menu();
                    actionChoise = m_UI.GetUserActionChoise();
                }
            }
        }

        private void insertVehicle()
        {
            string licensePlate = m_UI.GetVehicleLicensePlate();

            if (m_Data.Contains(licensePlate))
            {
                m_UI.PrintMsg("The Vehicle Are Already Exists In The System");
                handleAlreadyExistSituation(licensePlate);
            }
            else
            {
                Vehicle v = Creator.Create(m_UI.GetVehicleType());
                v.LicensePlate = licensePlate;
                VehicleInfo vInfo = new VehicleInfo(v);
                insertVehicleDetails(vInfo);
                insertSpecificVehicleDetails(vInfo);
                insertEngineDetails(vInfo);
                m_Data.Insert(vInfo);
                m_UI.PrintMsg("\nThe Vehicle Insert Successfully \n");
            }
        }

        private void handleAlreadyExistSituation(string i_LicensePlate)
        {
            m_Data.FindVehicle(i_LicensePlate).SetInProccesStatus();
        }

        private void fillGasVehicle()
        {
            string vehicleLicensePlate = m_UI.GetVehicleLicensePlate();
            Gasoline.eGasType eVehicleGasTypeToFill = m_UI.GetGasTypeToFill();
            float amountToAdd = m_UI.GetEnergyAmountToAdd();
            m_Data.FillGas(vehicleLicensePlate, eVehicleGasTypeToFill, amountToAdd);
            m_UI.PrintMsg("\nFill Gas Successfully \n");
        }

        private void fillElectricVehicle()
        {
            string VehicleLicensePlate = m_UI.GetVehicleLicensePlate();
            float amountToAdd = m_UI.GetEnergyAmountToAdd();
            m_Data.FillElectric(VehicleLicensePlate, amountToAdd);
            m_UI.PrintMsg("\nFill Electric Successfully \n");
        }

        private void insertEngineDetails(VehicleInfo i_VehicleInfo)
        {
            bool goodInput = false;

            while (!goodInput)
            {
                try
                {
                    i_VehicleInfo.Vehicle.SetCurrPower(m_UI.GetLeftPower(i_VehicleInfo.Vehicle.GetEngineType()));
                    goodInput = true;
                }
                catch (Exception ex)
                {
                    m_UI.AnnounceError(ex);
                }
            }

        }

        private void insertVehicleDetails(VehicleInfo i_VehicleInfo)
        {
            foreach(eInfoType info in Enum.GetValues(typeof(eInfoType)))
            {
                validationLoop(info , i_VehicleInfo);
            }
        }

        private void changeVehicleStatus()
        {
            string licensePlate = m_UI.GetVehicleLicensePlate();
            VehicleInfo currVehicleInfo = m_Data.FindVehicle(licensePlate);
            currVehicleInfo.Status = m_UI.GetVehicleNewStatus();
            m_UI.PrintMsg("\nChange Status Successfully \n");
        }

        private void insertSpecificVehicleDetails(VehicleInfo i_VehicleInfo)
        {
            Type vType = i_VehicleInfo.Vehicle.GetType();

            foreach(FieldInfo info in vType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                object someInfo = null;
                m_UI.GetInfo(info, ref someInfo);
                i_VehicleInfo.Vehicle.SetInfo(info, someInfo);
            }
        }

        private void validationLoop(eInfoType i_InfoToAsk, VehicleInfo i_VehicleInfo)
        {
            bool goodInput = false;

            while (!goodInput)
            {
                try
                {
                    switch (i_InfoToAsk)
                    {
                        case eInfoType.ModelName:
                            {
                                i_VehicleInfo.SetVehicleModelName(m_UI.GetModelName());
                                break;
                            }

                        case eInfoType.WheelsManufactor:
                            {
                                i_VehicleInfo.SetWheelsManufacturer(m_UI.GetWheelsManufacturer());
                                break;
                            }

                        case eInfoType.CurrWheelsAirPressure :
                            {
                                i_VehicleInfo.SetWheelsCurrAirPressure(m_UI.GetAirPressure());
                                break;
                            }

                        case eInfoType.OwnerName:
                            {
                                i_VehicleInfo.VehicleOwnerName = m_UI.GetVehicleOwnerName();
                                break;
                            }

                        case eInfoType.OwnerPhone:
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

        private void inflateWheelsToMaximum()
        {
            m_Data.InflateWheelsToMax(m_UI.GetVehicleLicensePlate());
            m_UI.PrintMsg("\nInflate Wheels Successfully \n");
        }

        private void displayVehicleInfo()
        {
            StringBuilder allVehiclesString = m_Data.GetVehicleInfoString(m_UI.GetVehicleLicensePlate());
            m_UI.PrintMsg(allVehiclesString.ToString());
        }

        private void displayLicensePlates()
        {
            string outList = null;

            if (m_UI.AskUserFilterChoise())
            {
                VehicleInfo.eVehicleStatus userChoise = m_UI.GetStatus();
                outList += m_Data.GetListLicensePlateByStatus(userChoise);
            }
            else
            {
                outList += m_Data.GetListLicensePlate();
            }

            if(outList.Length==0)
            {
                outList = "No Vehicles In This Status";
            }
          
            m_UI.PrintMsg(outList);
        }

         public enum eInfoType
        {
            ModelName,
            WheelsManufactor,
            CurrWheelsAirPressure,
            OwnerName,
            OwnerPhone
        }
    }
}
