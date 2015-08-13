using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTime
{
    public class TimeChar
    {
        public TimeCharSlice this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return _first;
                    case 1:
                        return _second;
                    case 2:
                        return _third;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        private TimeCharSlice _first;
        private TimeCharSlice _second;
        private TimeCharSlice _third;

        public char Value { get; private set; }

        public TimeChar(string first, string second, string third, char value)
        {
            _first = new TimeCharSlice(first);
            _second = new TimeCharSlice(second);
            _third = new TimeCharSlice(third);
            Value = value;
        }

        public class TimeCharSlice
        {
            public char this[int index]
            {
                get
                {
                    switch(index)
                    {
                        case 0:
                            return _first;
                        case 1:
                            return _second;
                        case 2:
                            return _third;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                }
            }

            private char _first;
            private char _second;
            private char _third;

            public TimeCharSlice(string slice)
            {
                _first = slice[0];
                _second = slice[1];
                _third = slice[2];
            }

            public override bool Equals(object obj)
            {
                if (obj is string)
                {
                    string val = string.Concat(_first, _second, _third);
                    return val == (string)obj;
                }
                else if (obj is TimeCharSlice)
                {
                    TimeCharSlice val = obj as TimeCharSlice;
                    return _first == val[0]
                        && _second == val[1]
                        && _third == val[2];
                }

                return base.Equals(obj);
            }
        }
    }


}
