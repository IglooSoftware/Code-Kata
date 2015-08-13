using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockParse.MB
{
    public class Runner
    {
        private struct SevenSegmentDisplay
        {
            public bool Top { get; set; }
            public bool Middle { get; set; }
            public bool Bottom { get; set; }
            public bool UpperLeft { get; set; }
            public bool UpperRight { get; set; }
            public bool LowerLeft { get; set; }
            public bool LowerRight { get; set; }
        }

        public static void GetTime(string filePath)
        {
            try
            {
                List<SevenSegmentDisplay> digits = ParseFile(filePath);

                var parsedDigits = digits.Select(ssd => ReadSevenSegmentDisplay(ssd));

                foreach (int digit in parsedDigits)
                {
                    //Console.Write(digit);
                }
                //Console.WriteLine();
            }
            catch
            {
                Console.Write("Bad user input!");
            }
        }

        private static List<SevenSegmentDisplay> ParseFile(string filePath)
        {
            const char VERTICAL = '|';
            const char HORIZONTAL = '_';

            //Regex validChars = new Regex(@"^[_|\s]+$");

            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length != 3)
            {
                throw new InvalidDataException();
            }

            string topLine = lines[0];
            string middleLine = lines[1];
            string bottomLine = lines[2];

            //if (topLine.Length != middleLine.Length || topLine.Length != bottomLine.Length ||
            //    !validChars.IsMatch(topLine) || !validChars.IsMatch(middleLine) || !validChars.IsMatch(bottomLine))
            //{
            //    throw new InvalidDataException();
            //}

            var display = new List<SevenSegmentDisplay>();

            for (int i = 0; i < topLine.Length; i += 3)
            {
                var digit = new SevenSegmentDisplay()
                {
                    Top = topLine[i + 1] == HORIZONTAL,
                    Middle = middleLine[i + 1] == HORIZONTAL,
                    Bottom = bottomLine[i + 1] == HORIZONTAL,
                    UpperLeft = middleLine[i] == VERTICAL,
                    UpperRight = middleLine[i + 2] == VERTICAL,
                    LowerLeft = bottomLine[i] == VERTICAL,
                    LowerRight = bottomLine[i + 2] == VERTICAL
                };
                display.Add(digit);
            }

            return display;
        }

        private static int ReadSevenSegmentDisplay(SevenSegmentDisplay ssd)
        {
            if (ssd.Top && !ssd.Middle && ssd.Bottom && ssd.UpperLeft && ssd.UpperRight && ssd.LowerLeft && ssd.LowerRight)
            {
                return 0;
            }
            else if (!ssd.Top && !ssd.Middle && !ssd.Bottom && !ssd.UpperLeft && ssd.UpperRight && !ssd.LowerLeft && ssd.LowerRight)
            {
                return 1;
            }
            else if (ssd.Top && ssd.Middle && ssd.Bottom && !ssd.UpperLeft && ssd.UpperRight && ssd.LowerLeft && !ssd.LowerRight)
            {
                return 2;
            }
            else if (ssd.Top && ssd.Middle && ssd.Bottom && !ssd.UpperLeft && ssd.UpperRight && !ssd.LowerLeft && ssd.LowerRight)
            {
                return 3;
            }
            else if (!ssd.Top && ssd.Middle && !ssd.Bottom && ssd.UpperLeft && ssd.UpperRight && !ssd.LowerLeft && ssd.LowerRight)
            {
                return 4;
            }
            else if (ssd.Top && ssd.Middle && ssd.Bottom && ssd.UpperLeft && !ssd.UpperRight && !ssd.LowerLeft && ssd.LowerRight)
            {
                return 5;
            }
            else if (ssd.Top && ssd.Middle && ssd.Bottom && ssd.UpperLeft && !ssd.UpperRight && ssd.LowerLeft && ssd.LowerRight)
            {
                return 6;
            }
            else if (ssd.Top && !ssd.Middle && !ssd.Bottom && !ssd.UpperLeft && ssd.UpperRight && !ssd.LowerLeft && ssd.LowerRight)
            {
                return 7;
            }
            else if (ssd.Top && ssd.Middle && ssd.Bottom && ssd.UpperLeft && ssd.UpperRight && ssd.LowerLeft && ssd.LowerRight)
            {
                return 8;
            }
            else if (ssd.Top && ssd.Middle && ssd.Bottom && ssd.UpperLeft && ssd.UpperRight && !ssd.LowerLeft && ssd.LowerRight)
            {
                return 9;
            }
            else
            {
                throw new InvalidDataException();
            }
        }
    }
}
