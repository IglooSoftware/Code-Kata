using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTime
{
    public static class Knowledgebase
    {
        private static IEnumerable<TimeChar> _chars = new TimeChar[] 
        {
            new TimeChar(" _ ", "| |", "|_|", '0'),
            new TimeChar("   ", "  |", "  |", '1'),
            new TimeChar(" _ ", " _|", "|_ ", '2'),
            new TimeChar(" _ ", " _|", " _|", '3'),
            new TimeChar("   ", "|_|", "  |", '4'),
            new TimeChar(" _ ", "|_ ", " _|", '5'),
            new TimeChar(" _ ", "|_ ", "|_|", '6'),
            new TimeChar("   ", "|_ ", "|_|", '6'),
            new TimeChar(" _ ", "  |", "  |", '7'),
            new TimeChar(" _ ", "|_|", "|_|", '8'),
            new TimeChar(" _ ", "|_|", " _|", '9'),
            new TimeChar(" _ ", "|_|", "  |", '9')
        };

        public static IEnumerable<TimeChar> FindInitialPossibilities(TimeChar.TimeCharSlice slice)
        {
            return _chars.Where(o => o[0].Equals(slice));
        }
    }
}
