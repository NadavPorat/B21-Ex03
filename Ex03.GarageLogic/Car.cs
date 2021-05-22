using System;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected EColor m_CarColor;
        protected EDoorsNum m_NumOfDoors;

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
