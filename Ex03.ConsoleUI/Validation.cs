using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class Validation
    {
        public static void IsOnlyDigitsAndLetters(string i_UserInput)
        {
            if(!i_UserInput.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Input Muse Be ONLY Letters And Digits.");
            }
        }

        public static void IsOnlyDigits(string i_UserInput)
        {
            if(!i_UserInput.All(char.IsDigit))
            {
                throw new FormatException("Input Must Be ONLY Digits.");
            }
        }

        public static void IsInRange(float i_UserInput, float i_From, float i_To)
        {
            if(i_UserInput < i_From||i_UserInput> i_To)
            {
                throw new ValueOutOfRangeException("Value Is Not In Options. " ,i_From, i_To);
            }
        }
    }
}
