using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class GameState
    {
        public char[,] boardState;
        public char playerID;
        public int depthLevel;
        public int rank;
        List<GameState> childBoardStates = new List<GameState>();

        public GameState(char id, int depth, char[,] board)
        {
            playerID = id;
            depthLevel = depth;
            boardState = board;

            if (CheckForWin() != '\0' || CheckForTie())
            {
                SetRank();
            }
            else
            {
                CreateChildStates();
                SetRank();
            }
        }

        public void SetFinalStateRank()
        {
            if (CheckForTie())
            {
                rank = 0;
            }
            else if (CheckForWin() != '\0')
            {
                if (CheckForWin() == playerID)
                {
                    rank = 1;
                }
                else
                {
                    rank = -1;
                }
            }
        }

        public void CreateChildStates()
        {
            for (int y = 0; y < boardState.GetLength(0); y++)
            {
                for (int x = 0; x < boardState.GetLength(0); x++)
                {
                    char[,] nextBoardState = NewBoardState(boardState);
                    if (nextBoardState[y, x] == '\0')
                    {
                        if (depthLevel == 6)
                        {
                            int debug = 0;
                        }
                        nextBoardState[y, x] = playerID;
                        char nextID;
                        if (playerID == 'X')
                        {
                            nextID = 'O';
                        }
                        else
                        {
                            nextID = 'X';
                        }
                        childBoardStates.Add(new GameState(nextID, depthLevel + 1, nextBoardState));
                    }
                }
            }
        }

        public char[,] NewBoardState(char[,] oldBoard)
        {
            char[,] newBoard = new char[3,3];
            for(int y = 0; y < oldBoard.GetLength(0); y++)
            {
                for(int x = 0; x < oldBoard.GetLength(0); x++)
                {
                    newBoard[y, x] = oldBoard[y, x];
                }
            }
            return newBoard;
        }

        public void SetIntermediateStateRank()
        {
            int[] childRanks = new int[childBoardStates.Count];
            for (int i = 0; i < childBoardStates.Count; i++)
            {
                childRanks[i] = childBoardStates[i].rank;
            }

            if (depthLevel % 2 == 0)
            {
                rank = childRanks.Max();
            }
            else
            {
                rank = childRanks.Min();
            }
        }

        public void SetRank()
        {
            if (CheckForTie())
            {
                rank = 0;
            }
            else if (CheckForWin() != '\0')
            {
                if (depthLevel % 2 == 1)
                {
                    rank = 1;
                }
                else
                {
                    rank = -1;
                }
            }
            else
            {
                int[] childRanks = new int[childBoardStates.Count];
                for (int i = 0; i < childBoardStates.Count; i++)
                {
                    childRanks[i] = childBoardStates[i].rank;
                }

                if (depthLevel % 2 == 0)
                {
                    rank = childRanks.Max();
                }
                else
                {
                    rank = childRanks.Min();
                }
            }
        }

        public bool CheckForTie()
        {
            if (CheckForWin() != '\0')
            {
                return false;
            }

            foreach (char c in boardState)
            {
                if (c == '\0')
                {
                    return false;
                }
            }

            return true;
        }

        public char CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (CheckRowForWin(i, 'X') >= 3 ||
                    CheckColumnForWin(i, 'X') >= 3)
                {
                    return 'X';
                }

                if (CheckRowForWin(i, 'O') >= 3 ||
                    CheckColumnForWin(i, 'O') >= 3)
                {
                    return 'O';
                }
            }
            if (CheckSlashForWin('X') >= 3 ||
                CheckBackSlashForWin('X') >= 3)
            {
                return 'X';
            }
            if (CheckSlashForWin('O') >= 3 ||
                CheckBackSlashForWin('O') >= 3)
            {
                return 'O';
            }
            return '\0';
        }

        private int CheckRowForWin(int row, char checkFor)
        {
            int tally = 0;
            for (int xAxisCounter = 0; xAxisCounter < 3; xAxisCounter++)
            {
                if (boardState[row, xAxisCounter] == checkFor)
                {
                    tally++;
                }
            }
            return tally;
        }

        private int CheckColumnForWin(int column, char checkFor)
        {
            int tally = 0;
            for (int yAxisCounter = 0; yAxisCounter < 3; yAxisCounter++)
            {
                if (boardState[yAxisCounter, column] == checkFor)
                {
                    tally++;
                }
            }
            return tally;
        }

        private int CheckSlashForWin(char checkFor)
        {
            int tally = 0;
            int xAxisIndex = 0;
            int yAxisIndex = 2;
            while (xAxisIndex < 3)
            {
                if (boardState[yAxisIndex, xAxisIndex] == checkFor)
                {
                    tally++;
                }
                xAxisIndex++;
                yAxisIndex--;
            }
            return tally;
        }

        private int CheckBackSlashForWin(char checkFor)
        {
            int tally = 0;
            int xAxisIndex = 0;
            int yAxisIndex = 0;
            while (xAxisIndex < 3)
            {
                if (boardState[yAxisIndex, xAxisIndex] == checkFor)
                {
                    tally++;
                }
                xAxisIndex++;
                yAxisIndex++;
            }
            return tally;
        }
    }
}
