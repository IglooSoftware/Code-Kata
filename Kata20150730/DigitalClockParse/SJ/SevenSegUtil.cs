using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockParse
{
    public class SevenSegUtil
    {
        public static int ConvertSevenSeg(char[,] number)
        {
            int numberOfBlanks = GetNumberOfBlanks(number);

            if (numberOfBlanks == 2)
            {
                return 8;
            }
            else if (numberOfBlanks == 6)
            {
                return 7;
            }
            else if (numberOfBlanks == 7)
            {
                return 1;
            }
            else if (numberOfBlanks == 5)
            {
                return 4;
            }
            else if (numberOfBlanks == 3)
            {
                return GetZeroNineSix(number);
            }
            else if (numberOfBlanks == 4)
            {
                return GetTwoThreeFive(number);
            }
            else
            {
                return -1;
            }
        }

        private static int GetNumberOfBlanks(char[,] number)
        {
            int count = 0;
            foreach (char segment in number)
            {
                if (segment == ' ')
                {
                    count++;
                }
            }

            return count;
        }

        private static int GetZeroNineSix(char[,] number)
        {
            if (number[1, 1] == ' ')
            {
                return 0;
            }
            else if (number[2, 0] == ' ')
            {
                return 9;
            }
            else
            {
                return 6;
            }
        }

        private static int GetTwoThreeFive(char[,] number)
        {
            if (number[2, 2] == ' ')
            {
                return 2;
            }
            else if (number[1, 0] == ' ' && number[2, 0] == ' ')
            {
                return 3;
            }
            else
            {
                return 5;
            }
        }
    }
}
