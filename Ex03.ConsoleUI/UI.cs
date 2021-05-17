using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        public Creator.EVehicleType GetVehicleType()
        {
            return Creator.EVehicleType.ElectricMotor;
        }

        public string GetModelName()
        {
            return "mazda";
        }

        public float GetAirPressure()
        {
            return 2.3f;
        }
    }
}
