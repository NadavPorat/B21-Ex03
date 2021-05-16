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
            //m_UI.GetVehicleType();





           // m_Data.InsertVehicle();

        }
    
        

    }
}
