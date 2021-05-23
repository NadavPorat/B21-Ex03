using System;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public abstract class Validation
    {
        internal static void IsOnlyDigitsAndLetters(string i_UserInput)
        {
            if(!i_UserInput.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Input Muse Be ONLY Letters And Digits.");
            }
        }

        internal static void IsOnlyDigits(string i_UserInput)
        {
            if(!i_UserInput.All(char.IsDigit))
            {
                throw new FormatException("Input Must Be ONLY Digits.");
            }
        }

        internal static void IsInRange(float i_UserInput, float i_From, float i_To)
        {
            if (i_UserInput < i_From || i_UserInput > i_To)
            {
                throw new ValueOutOfRangeException("Value Is Not In Options. ", i_From, i_To);
            }
        }
    }
}
