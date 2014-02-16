using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public abstract class Player
    {
        public char identity;

        public abstract CreatedMove MakeMove(char[,] boardState);

        public override bool Equals(object obj)
        {
            Player otherPlayer = (Player)obj;

            if (this.identity == otherPlayer.identity && this.GetType() == otherPlayer.GetType())
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
