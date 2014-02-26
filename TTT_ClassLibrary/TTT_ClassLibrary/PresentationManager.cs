using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TTT_ClassLibrary
{
    public interface IPresentationIO
    {
        void OutputLn(string message);

        void Output(string message);

        string Input();
    }

    public class ConsoleIO : IPresentationIO
    {
        public void OutputLn(string message)
        {
            Console.WriteLine(message);
        }

        public void Output(string message)
        {
            Console.Write(message);
        }

        public string Input()
        {
            return Console.ReadLine();
        }
    }

    public class TestIO : IPresentationIO
    {
        public string lastOutString;
        public string desiredInString;

        public void OutputLn(string message)
        {
            lastOutString = message;
        }

        public void Output(string message)
        {
            lastOutString = message;
        }

        public string Input()
        {
            return desiredInString;
        }
    }

    public class PresentationManager
    {
        int boardBoundaries;
        public IPresentationIO IO;

        public PresentationManager()
        {
            boardBoundaries = 2;
            IO = new ConsoleIO();
        }

        public PresentationManager(IPresentationIO _IO)
        {
            IO = _IO;
        }

        public void Send(string message)
        {
            IO.OutputLn(message);
        }

        public void Recieve()
        {
            IO.Input();
        }

        public string WelcomeAndAskForGameParams()
        {
            Send("Hello, and welcome to Tic Tac Toe.\n" +
                "Would you like to play against a Human, or a Computer?\n" +
                "Or Would you like to watch a match between computers?\n\n" +
                "Enter either \"Human\", \"Computer\", or \"Computers\".");
            //string answer = Console.ReadLine();
            string answer = IO.Input();
            if (answer == null)
                answer = "";
            int loopCounter = 0;
            int loopLimit = 3; 
            while (answer.ToLower() != "human" && answer.ToLower() != "computer" && answer.ToLower() != "computers")
            {
                loopCounter++;
                if (loopCounter >= loopLimit)
                {
                    answer = "computers";
                }
                else
                {
                    Send("That was not a valid option. Please try again.\n" +
                    "Enter either \"Human\", \"Computer\", or \"Computers\".");
                    //answer = Console.ReadLine();
                    answer = IO.Input();
                    if (answer == null)
                        answer = "";
                }
            }
            return answer.ToLower();
        }

        public bool HumanGoesFirst()
        {
            Send("Would you like to go first, or second? (Enter either \"First\" or \"Second\")");
            //string answer = Console.ReadLine();
            string answer = IO.Input();
            if (answer == null)
                answer = "";
            int loopCounter = 0;
            int loopLimit = 3;
            while (answer.ToLower() != "first" && answer.ToLower() != "second")
            {
                loopCounter++;
                if (loopCounter >= loopLimit)
                {
                    answer = "first";
                }
                else
                {
                    Send("Please enter either \"First\" or \"Second.\"");
                    //answer = Console.ReadLine();
                    answer = IO.Input();
                    if (answer == null)
                        answer = "";
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

        public bool PlayAgain()
        {
            Send("Would you like to play again? (Type either \"Yes\" or \"No\")");
            //string answer = Console.ReadLine();
            string answer = IO.Input();
            if (answer == null)
                answer = "";
            int loopCounter = 0;
            int loopLimit = 2;
            while (answer.ToLower() != "yes" && answer.ToLower() != "no")
            {
                loopCounter++;
                if (loopCounter >= loopLimit)
                {
                    answer = "no";
                }
                else
                {
                    Send("Please enter either \"yes\" or \"no.\"");
                    //answer = Console.ReadLine();
                    answer = IO.Input();
                    if (answer == null)
                        answer = "";
                }
            }
            if (answer.ToLower() == "yes")
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
            //string answer = Console.ReadLine();
            string answer = IO.Input();
            if (int.TryParse(answer, out xCoordinate) == false)
                xCoordinate = -100;
            int loopCounter = 0;
            int loopLimit = 3;
            while (xCoordinate > boardBoundaries || xCoordinate < 0)
            {
                loopCounter++;
                if (loopCounter >= loopLimit)
                {
                    xCoordinate = 0;
                }
                else
                {
                    Send("That was not a valid X coordinate. Please try again.\n" +
                    "Valid coordinates are between 0 and " + boardBoundaries + " (inclusive).");
                    //answer = Console.ReadLine();
                    answer = IO.Input();
                    if (int.TryParse(answer, out xCoordinate) == false)
                        xCoordinate = -100;
                }
            }
            Send("Enter a Y coordinate between 0 and " + boardBoundaries + " (inclusive).");
            //answer = Console.ReadLine();
            answer = IO.Input();
            int yCoordinate;
            if (int.TryParse(answer, out yCoordinate) == false)
                yCoordinate = -100;
            loopCounter = 0;
            loopLimit = 3;
            while (yCoordinate > boardBoundaries || yCoordinate < 0)
            {
                loopCounter++;
                if (loopCounter >= loopLimit)
                {
                    yCoordinate = 0;
                }
                else
                {
                    Send("That was not a valid Y coordinate. Please try again.\n" +
                    "Valid coordinates are between 0 and " + boardBoundaries + " (inclusive).");
                    //answer = Console.ReadLine();
                    answer = IO.Input();
                    if (int.TryParse(answer, out yCoordinate) == false)
                        yCoordinate = -100;
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
                        IO.Output("[ ]");
                    }
                    else
                    {
                        IO.Output(String.Format("[{0}]", boardToPrint[yAxis, xAxis]));
                    }
                }
                IO.OutputLn("");
            }
            IO.Input();
        }
    }
}
