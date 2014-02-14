using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class ComputerAI
    {
        public char[,] currentBoardState;
        public char enemyIdentity;
        public char myIdentity;

        public ComputerAI(char enemyID, char myID)
        {
            enemyIdentity = enemyID;
            myIdentity = myID;
        }

        public CreatedMove GetNextMove(char[,] boardState, int lastEnemyMoveX, int lastEnemyMoveY)
        {
            currentBoardState = boardState;

            return new CreatedMove(0, 0, 'I');
        }

        public CreatedMove GetRandomMove(char[,] boardState)
        {
            List<CreatedMove> remainingOpenSpaces = new List<CreatedMove>();
            for (int yAxis = 0; yAxis < 3; yAxis++)
            {
                for (int xAxis = 0; xAxis < 3; xAxis++)
                {
                    if (boardState[yAxis, xAxis] == '\0')
                    {
                        remainingOpenSpaces.Add(new CreatedMove(xAxis, yAxis, myIdentity));
                    }
                }
            }
            Random rand = new Random();
            int randomIndex = rand.Next(remainingOpenSpaces.Count);
            CreatedMove randomMove = remainingOpenSpaces[randomIndex];
            return randomMove;
        }

        public int WeighOpponentPresence(char[,] boardState, int enemyX, int enemyY)
        {
            currentBoardState = boardState;
            for (int yAxisIndex = 0; yAxisIndex < 3; yAxisIndex++)
            {
                for (int xAxisIndex = 0; xAxisIndex < 3; xAxisIndex++)
                {
                    if (currentBoardState[yAxisIndex, xAxisIndex] == enemyIdentity)
                    {
                        //CheckNeighborsOf(xAxisIndex, yAxisIndex);
                    }
                }
            }
            return 0;
        }

        public override bool Equals(object obj)
        {
            ComputerAI otherAI = (ComputerAI)obj;
            if (this.currentBoardState == otherAI.currentBoardState && this.enemyIdentity == otherAI.enemyIdentity && this.myIdentity == otherAI.myIdentity)
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
