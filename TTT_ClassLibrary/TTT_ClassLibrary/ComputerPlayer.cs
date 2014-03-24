using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class ComputerPlayer : Player
    {
        MiniMax minimax = new MiniMax();

        public ComputerPlayer()
        {
            identity = 'X';
        }

        public ComputerPlayer(char playerIdentity)
        {
            if (playerIdentity.ToString().ToUpper() == "O")
            {
                identity = 'O';
            }
            else
            {
                identity = 'X';
            }
        }

        public override Tuple<int,int> MakeMove(char[,] boardState)
        {
            return minimax.GetMove(boardState, identity);
        }
    }
}
