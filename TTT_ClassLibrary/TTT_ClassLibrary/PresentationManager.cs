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
                if (loopCounter >= loopLimit)
                {
                    answer = "computers";
                }
            }
            return answer.ToLower();
        }

        public bool HumanGoesFirst()
        {
            Send("Would you like to go first, or second? (Enter either \"First\" or \"Second\")");
            string answer = Console.ReadLine();
            if (answer == null)
                answer = "";
            answer = answer.ToLower();
            int loopCounter = 0;
            int loopLimit = 3;
            while (answer != "first" && answer != "second")
            {
                loopCounter++;
                Send("Please enter either \"First\" or \"Second\".");
                answer = Console.ReadLine();
                if (answer == null)
                    answer = "";
                answer = answer.ToLower();
                if(loopCounter >= loopLimit)
                {
                    answer = "first";
                }
            }
            if (answer == "first")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Tuple<int, int> PromptCoordinates()
        {
            Send("Enter an X coordinate between 0 and " + boardBoundaries + " (inclusive).");
            int xCoordinate;
            string answer = Console.ReadLine();
            if (int.TryParse(answer, out xCoordinate) == false)
                xCoordinate = -100;
            int loopCounter = 0;
            int loopLimit = 3;
            while (xCoordinate > boardBoundaries || xCoordinate < 0)
            {
                loopCounter++;
                Send("That was not a valid X coordinate. Please try again.\n"+
                    "Valid coordinates are between 0 and " + boardBoundaries + " (inclusive).");
                answer = Console.ReadLine();
                if (int.TryParse(answer, out xCoordinate) == false)
                    xCoordinate = -100;
                if (loopCounter >= loopLimit)
                {
                    xCoordinate = 0;
                }
            }
            Send("Enter a Y coordinate between 0 and " + boardBoundaries + " (inclusive).");
            answer = Console.ReadLine();
            int yCoordinate;
            if (int.TryParse(answer, out yCoordinate) == false)
                yCoordinate = -100;
            loopCounter = 0;
            loopLimit = 3;
            while (yCoordinate > boardBoundaries || yCoordinate < 0)
            {
                loopCounter++;
                Send("That was not a valid Y coordinate. Please try again.\n" +
                    "Valid coordinates are between 0 and " + boardBoundaries + " (inclusive).");
                answer = Console.ReadLine();
                if (int.TryParse(answer, out yCoordinate) == false)
                    yCoordinate = -100;
                if (loopCounter >= loopLimit)
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
            Console.ReadLine();
        }
    }
}
