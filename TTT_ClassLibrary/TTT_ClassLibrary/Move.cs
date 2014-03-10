using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class Move : IComparable<Move>
    {
        public int depth;
        public int value;

        public Move(int _depth, int _value)
        {
            depth = _depth;
            value = _value;
        }

        int IComparable<Move>.CompareTo(Move other)
        {
            if (this.value > other.value)
            {
                return 1;
            }
            else if (this.value == other.value)
            {
                if (this.depth < other.depth)
                {
                    return 1;
                }
                else if (this.depth == other.depth)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
