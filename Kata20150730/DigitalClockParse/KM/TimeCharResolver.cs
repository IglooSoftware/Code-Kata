using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTime
{
    public class TimeCharResolver
    {
        private TimeChar.TimeCharSlice _first;
        private TimeChar.TimeCharSlice _second;
        private TimeChar.TimeCharSlice _third;
        private IEnumerable<TimeChar> _possibilities;

        public void AddSlice(string slice)
        {
            if (_third != null)
            {
                throw new Exception("Too many slices");
            }
            else if (_second != null)
            {
                _third = new TimeChar.TimeCharSlice(slice);
                _possibilities = _possibilities.Where(o => o[2].Equals(_third));
            }
            else if (_first != null)
            {
                _second = new TimeChar.TimeCharSlice(slice);
                _possibilities = _possibilities.Where(o => o[1].Equals(_second));
            }
            else
            {
                _first = new TimeChar.TimeCharSlice(slice);
                _possibilities = Knowledgebase.FindInitialPossibilities(_first);
            }
        }

        public char GetTimeChar()
        {
            return _possibilities.Single().Value;
        }

        public TimeCharResolver(string slice)
        {
            _first = new TimeChar.TimeCharSlice(slice);
            _possibilities = Knowledgebase.FindInitialPossibilities(_first);
        }
    }
}
