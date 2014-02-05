using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public abstract class Player
    {
        public char identity;

        public string name;

        public abstract CreatedMove MakeMove(int xValue, int yValue);

        public override bool Equals(object obj)
        {
            Player comparePlayer = (Player)obj;
            if (identity == comparePlayer.identity && this.GetType() == comparePlayer.GetType())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
