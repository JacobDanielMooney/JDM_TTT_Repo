using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class PresentationManager
    {
        int boardBoundaries;

        public PresentationManager()
        {
            boardBoundaries = 2;
        }

        public void Send(string message)
        {
            Console.WriteLine(message);
        }

        public string WelcomeAndAskForGameParams()
        {
            Send("Hello, and welcome to Tic Tac Toe.\n" +
                "Would you like to play against a Human, or a Computer?\n" +
                "Or Would you like to watch a match between computers?\n\n" +
                "Enter either \"Human\", \"Computer\", or \"Computers\".");
            string answer = Console.ReadLine();
            if (answer != null)
            {
                answer = answer.ToLower();
            }
            int loopCounter = 0;
            int loopLimit = 3; 
            while (answer != "human" && answer != "computer" && answer != "computers")
            {
                loopCounter++;
                Send("That was not a valid option. Please try again.\n" +
                    "Enter either \"Human\", \"Computer\", or \"Computers\".");
                answer = Console.ReadLine();
                if (answer != null)
                {
                    answer = answer.ToLower();
                }
                if (loopCounter >= 3)
                {
                    answer = "computers";
                }
            }
            return answer.ToLower();
        }

        public Tuple<int, int> AskForNextMove()
        {
            Send("Enter an X coordinate between 0 and " + boardBoundaries + " (inclusive).");
            int xCoordinate = Convert.ToInt32(Console.ReadLine());
            int loopCounter = 0;
            int loopLimit = 3;
            while (xCoordinate > boardBoundaries || xCoordinate < 0)
            {
                loopCounter++;
                Send("That was not a valid X coordinate. Please try again.\n"+
                    "Valid coordinates are between 0 and " + boardBoundaries + " (inclusive).");
                xCoordinate = Convert.ToInt32(Console.ReadLine());
                if (loopCounter >= 3)
                {
                    xCoordinate = 0;
                }
            }
            Send("Enter a Y coordinate between 0 and " + boardBoundaries + " (inclusive).");
            int yCoordinate = Convert.ToInt32(Console.ReadLine());
            loopCounter = 0;
            loopLimit = 3;
            while (yCoordinate > boardBoundaries || yCoordinate < 0)
            {
                loopCounter++;
                Send("That was not a valid Y coordinate. Please try again.\n" +
                    "Valid coordinates are between 0 and " + boardBoundaries + " (inclusive).");
                yCoordinate = Convert.ToInt32(Console.ReadLine());
                if (loopCounter >= 3)
                {
                    yCoordinate = 0;
                }
            }
            return new Tuple<int, int>(xCoordinate, yCoordinate);
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
