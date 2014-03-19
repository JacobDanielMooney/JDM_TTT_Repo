using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class Move : IComparable<Move>
    {
        public int score;
        public Tuple<int, int> coordinates;

        public Move(int _value, int xCoord, int yCoord)
        {
            score = _value;
            coordinates = new Tuple<int, int>(xCoord, yCoord);
        }

        int IComparable<Move>.CompareTo(Move other)
        {
            if (Math.Abs(this.score) > Math.Abs(other.score))
            {
                return 1;
            }
            else if (Math.Abs(this.score) == Math.Abs(other.score))
            {
                if (this.score > other.score)
                {
                    return 1;
                }
                else if (this.score == other.score)
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
