using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void InsertVehicle()
        {
            Vehicle v = Creator.Create(m_UI.GetVehicleType());
            VehicleInfo vInfo = new VehicleInfo(v);
            ValidationLoop(EInfoType.ModelName, v);
            ValidationLoop(EInfoType.OwnerName, v);
            ValidationLoop(EInfoType.OwnerPhone, v);
            ValidationLoop(EInfoType.PlateNumber, v);

            

        }

        public void ValidationLoop(EInfoType i_InfoToAsk, Vehicle v)
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
                                v.VehicleModel = m_UI.GetModelName();
                                break;
                            }

                        case EInfoType.CurrWheelsAirPressure :
                            {
                                v.SetCurrWheelsAirPressure(m_UI.GetAirPressure());
                                break;
                            }

                        case EInfoType.LeftPowerAmount:
                            {
                                v.SetCurrEnergyAmount(m_UI.GetLeftPowerAmount());
                                break;
                            }

                        case EInfoType.OwnerName:
                            {
                                break;
                            }

                        case EInfoType.OwnerPhone:
                            {
                                break;
                            }

                        case EInfoType.PlateNumber:
                            {
                                break;
                            }

                        case EInfoType.WheelsManufactor:
                            {
                                break;
                            }

                    }
                }
                catch (Exception ex)
                {
                    goodInput = false;
                }
            }
        }
    
        
         public enum EInfoType
        {
            ModelName,
            PlateNumber,
            LeftPowerAmount,
            WheelsManufactor,
            CurrWheelsAirPressure,
            OwnerName,
            OwnerPhone
        }
    }
}
