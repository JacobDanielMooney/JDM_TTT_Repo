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

        public override CreatedMove MakeMove(char[,] boardState)
        {
            List<CreatedMove> remainingOpenSpaces = new List<CreatedMove>();
            for (int yAxis = 0; yAxis < 3; yAxis++)
            {
                for (int xAxis = 0; xAxis < 3; xAxis++)
                {
                    if (boardState[yAxis, xAxis] == '\0')
                    {
                        remainingOpenSpaces.Add(new CreatedMove(xAxis, yAxis, identity));
                    }
                }
            }
            Random rand = new Random();
            int randomIndex = rand.Next(remainingOpenSpaces.Count);
            CreatedMove randomMove = remainingOpenSpaces[randomIndex];
            return randomMove;
        }
    }
}
