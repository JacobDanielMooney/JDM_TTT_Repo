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

        public abstract string AnnounceWinner();
    }
}
