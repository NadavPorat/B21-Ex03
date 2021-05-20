using  Ex03.GarageLogic;
using System.Collections.Generic;
using System;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {

           GarageManage Garage = new GarageManage(new UI());
            Garage.Open();
           

        }
    }
}
