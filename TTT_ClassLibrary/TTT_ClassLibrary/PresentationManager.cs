using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class PresentationManager
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintBoard(char[,] boardToPrint)
        {
            for (int yAxis = 0; yAxis < 3; yAxis++)
            {
                for (int xAxis = 0; xAxis < 3; xAxis++)
                {
                    if (boardToPrint[yAxis, xAxis] == '\0')
                    {
                        Console.Write("[ ]");
                    }
                    else
                    {
                        Console.Write("[{0}]", boardToPrint[yAxis, xAxis]);
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
