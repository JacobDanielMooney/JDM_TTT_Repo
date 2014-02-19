using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class HumanPlayer : Player
    {
        public HumanPlayer()
        {
            identity = 'X';
        }

        public HumanPlayer(char playerIdentity)
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
            return null;
        }

        public Tuple<int, int> ForceMove(char[,] boardState)
        {
            List<Tuple<int, int>> remainingOpenSpaces = new List<Tuple<int, int>>();
            for (int yAxis = 0; yAxis < 3; yAxis++)
            {
                for (int xAxis = 0; xAxis < 3; xAxis++)
                {
                    if (boardState[yAxis, xAxis] == '\0')
                    {
                        remainingOpenSpaces.Add(new Tuple<int, int>(xAxis, yAxis));
                    }
                }
            }
            Random rand = new Random();
            int randomIndex = rand.Next(remainingOpenSpaces.Count);
            Tuple<int, int> randomMove = remainingOpenSpaces[randomIndex];
            return randomMove;
        }
    }
}
