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

        public ComputerAI(char[,] board, char enemyID)
        {
            currentBoardState = board;
            enemyIdentity = enemyID;
        }

        public CreatedMove GetNextMove(char[,] boardState, int lastEnemyMoveX, int lastEnemyMoveY)
        {
            currentBoardState = boardState;

            return new CreatedMove(0, 0, 'O');
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
    }
}
