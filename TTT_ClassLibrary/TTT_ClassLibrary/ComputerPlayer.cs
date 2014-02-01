using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer()
        {
            identity = 'X';
            name = "cpuPlayer";
        }

        public ComputerPlayer(string plyrName)
        {
            identity = 'X';
            name = plyrName;
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
            name = "cpuPlayer";
        }

        public ComputerPlayer(char playerIdentity, string plyrName)
        {
            if (playerIdentity.ToString().ToUpper() == "O")
            {
                identity = 'O';
            }
            else
            {
                identity = 'X';
            }
            name = plyrName;
        }

        public override CreatedMove MakeMove(int xValue, int yValue)
        {
            return new CreatedMove(xValue, yValue, identity);
        }

        public override string AnnounceWinner()
        {
            string result = String.Format("{0} the Computer won!", name);
            return result;
        }
    }
}
