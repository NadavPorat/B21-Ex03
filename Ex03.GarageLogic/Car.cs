using System;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        protected EColor m_CarColor;
        protected EDoorsNum m_NumOfDoors;

        //public Car(string i_CarColor, int i_NumDoors, string i_VehicleModel, string i_VehicleLicensePlate, float i_CurrEnergyPercentage, Engine i_EngineType) :base(i_VehicleModel, i_VehicleLicensePlate, i_CurrEnergyPercentage, i_EngineType)
        //{
        //    m_CarColor = i_CarColor;
        //    m_NumOfDoors = i_NumDoors;
        //}

        public Car(Engine i_EngineType) : base(4, 32, i_EngineType)
        {

        }

        public override void SetInfo(FieldInfo i_FieldInfo, Object i_ValueToPut)
        {
            if(i_FieldInfo.FieldType.GetTypeInfo()==m_CarColor.GetType())
            {
                m_CarColor = (EColor)i_ValueToPut;
            }
            if(i_FieldInfo.FieldType.GetTypeInfo() == m_NumOfDoors.GetType())
            {
                m_NumOfDoors = (EDoorsNum)i_ValueToPut;
            }
        }

        public enum EColor
        {
            Red=1,
            Silver,
            White,
            Black
        }

        public enum EDoorsNum
        {
            Two=1,
            Three,
            Four,
            Five
        }
    }
}
