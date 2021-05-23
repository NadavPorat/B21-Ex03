using System;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eColor m_CarColor;
        protected eDoorsNum m_NumOfDoors;

        public Car(Engine i_EngineType) : base(4, 32, i_EngineType)
        {
        }

        public override void SetInfo(FieldInfo i_FieldInfo, object i_ValueToPut)
        {
            if (i_FieldInfo.FieldType.GetTypeInfo() == m_CarColor.GetType())
            {
                m_CarColor = (eColor)i_ValueToPut;
            }
            else if(i_FieldInfo.FieldType.GetTypeInfo() == m_NumOfDoors.GetType())
            {
                m_NumOfDoors = (eDoorsNum)i_ValueToPut;
            }
        }

        public enum eColor
        {
            Red = 1,
            Silver,
            White,
            Black
        }

        public enum eDoorsNum
        {
            Two = 1,
            Three,
            Four,
            Five
        }
    }
}
