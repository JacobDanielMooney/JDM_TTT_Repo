using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class CreatedMove
    {
        public int xAxis;
        public int yAxis;
        public char plyrIdentity;

        public CreatedMove(int x, int y, char i)
        {
            xAxis = x;
            yAxis = y;
            plyrIdentity = i;
        }

        public override bool Equals(Object obj)
        {
            CreatedMove otherObj = (CreatedMove)obj;
            return (this.xAxis == otherObj.xAxis && this.yAxis == otherObj.yAxis && this.plyrIdentity == otherObj.plyrIdentity);
        }
    }
}
