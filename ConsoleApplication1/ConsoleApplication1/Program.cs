﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTT_ClassLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            PresentationManager presenter = new PresentationManager();
            presenter.Send("Welcome to Tic Tac Toe");
            Console.ReadLine();
            presenter.Send("Would you like to play against a computer, or another human?");
            presenter.Send("(enter either \"computer\" or \"human\")");
            string answer = Console.ReadLine();
            Player playerOne;
            Player playerTwo;
            ComputerAI AI = new ComputerAI('\0', '\0');
            if (answer.ToLower() == "computer")
            {
                presenter.Send("Would you like to go first or second?");
                presenter.Send("(enter either \"first\" or \"second\")");
                answer = Console.ReadLine();
                if (answer.ToLower() == "first")
                {
                    playerOne = new HumanPlayer('X');
                    playerTwo = new ComputerPlayer('O');
                    AI.enemyIdentity = 'X';
                    AI.myIdentity = 'Y';
                }
                else
                {
                    playerOne = new ComputerPlayer('X');
                    playerTwo = new HumanPlayer('O');
                    AI.enemyIdentity = 'Y';
                    AI.myIdentity = 'X';
                }
            }
            else
            {
                playerOne = new HumanPlayer('X');
                playerTwo = new HumanPlayer('O');
            }

            GameManager game = new GameManager(playerOne, playerTwo, 3);
            bool gameIsPlaying = true;
            presenter.Send("The board currently looks like this:");
            presenter.PrintBoard(game.board.boardArray);
            Console.ReadLine();

            while (gameIsPlaying)
            {
                if (playerOne.GetType() == typeof(ComputerPlayer))
                {
                    game.board.LogMove(AI.GetRandomMove(game.board.boardArray));

                    presenter.Send("After the computer's move, the board now looks like this:");
                    presenter.PrintBoard(game.board.boardArray);
                    Console.ReadLine();
                }
                else
                {
                    int xAxisChoice;
                    int yAxisChoice;
                    presenter.Send("It is now Player One's turn (X's)");
                    presenter.Send("First enter the X axis value of where you want to go:");
                    xAxisChoice = Convert.ToInt32(Console.ReadLine());
                    while (xAxisChoice > 2 || xAxisChoice < 0)
                    {
                        presenter.Send("Only values between 0 and 2 (inclusive) are allowed");
                        xAxisChoice = Convert.ToInt32(Console.ReadLine());
                    }

                    presenter.Send("Now enter the Y axis value of where you want to go:");
                    yAxisChoice = Convert.ToInt32(Console.ReadLine());
                    while (yAxisChoice > 2 || yAxisChoice < 0)
                    {
                        presenter.Send("Only values between 0 and 2 (inclusive) are allowed");
                        yAxisChoice = Convert.ToInt32(Console.ReadLine());
                    }

                    while (game.board.LogMove(playerOne.MakeMove(xAxisChoice, yAxisChoice)).plyrIdentity == 'I')
                    {
                        presenter.Send("That square has already been taken");
                        presenter.Send("Please choose another X axis value");
                        
                        xAxisChoice = Convert.ToInt32(Console.ReadLine());
                        while (xAxisChoice > 2 || xAxisChoice < 0)
                        {
                            presenter.Send("Only values between 0 and 2 (inclusive) are allowed");
                            xAxisChoice = Convert.ToInt32(Console.ReadLine());
                        }

                        presenter.Send("Please enter a new Y axis value");

                        yAxisChoice = Convert.ToInt32(Console.ReadLine());
                        while (yAxisChoice > 2 || yAxisChoice < 0)
                        {
                            presenter.Send("Only values between 0 and 2 (inclusive) are allowed");
                            yAxisChoice = Convert.ToInt32(Console.ReadLine());
                        }
                    }

                    presenter.Send("After player one's move, the board now looks like this:");
                    presenter.PrintBoard(game.board.boardArray);
                    Console.ReadLine();
                }

                if (game.checker.CheckForWin(game.board.boardArray) == true || game.checker.CheckForTie(game.board.boardArray))
                {
                    gameIsPlaying = false;
                    break;
                }

                if (playerTwo.GetType() == typeof(ComputerPlayer))
                {
                    game.board.LogMove(AI.GetRandomMove(game.board.boardArray));

                    presenter.Send("After the computer's move, the board now looks like this:");
                    presenter.PrintBoard(game.board.boardArray);
                    Console.ReadLine();
                }
                else
                {
                    int xAxisChoice;
                    int yAxisChoice;
                    presenter.Send("It is now Player Two's turn (O's)");
                    presenter.Send("First Enter the X axis of where you want to go:");
                    xAxisChoice = Convert.ToInt32(Console.ReadLine());
                    while (xAxisChoice > 2 || xAxisChoice < 0)
                    {
                        presenter.Send("Only values between 0 and 2 (inclusive) are allowed");
                        xAxisChoice = Convert.ToInt32(Console.ReadLine());
                    }

                    presenter.Send("Now enter the Y axis of where you want to go:");
                    yAxisChoice = Convert.ToInt32(Console.ReadLine());
                    while (yAxisChoice > 2 || yAxisChoice < 0)
                    {
                        presenter.Send("Only values between 0 and 2 (inclusive) are allowed");
                        yAxisChoice = Convert.ToInt32(Console.ReadLine());
                    }

                    while (game.board.LogMove(playerTwo.MakeMove(xAxisChoice, yAxisChoice)).plyrIdentity == 'I')
                    {
                        presenter.Send("That square has already been taken");
                        presenter.Send("Please choose another X axis value");

                        xAxisChoice = Convert.ToInt32(Console.ReadLine());
                        while (xAxisChoice > 2 || xAxisChoice < 0)
                        {
                            presenter.Send("Only values between 0 and 2 (inclusive) are allowed");
                            xAxisChoice = Convert.ToInt32(Console.ReadLine());
                        }

                        presenter.Send("Please enter a new Y axis value");

                        yAxisChoice = Convert.ToInt32(Console.ReadLine());
                        while (yAxisChoice > 2 || yAxisChoice < 0)
                        {
                            presenter.Send("Only values between 0 and 2 (inclusive) are allowed");
                            yAxisChoice = Convert.ToInt32(Console.ReadLine());
                        }
                    }


                    presenter.Send("After player two's move, the board now looks like this:");
                    presenter.PrintBoard(game.board.boardArray);
                    Console.ReadLine();
                }

                if (game.checker.CheckForWin(game.board.boardArray) == true || game.checker.CheckForTie(game.board.boardArray))
                {
                    gameIsPlaying = false;
                    break;
                }
            }

            if (game.checker.CheckForWin(game.board.boardArray))
            {
                presenter.Send("Congratulations! One of you won!");
            }

            if (game.checker.CheckForTie(game.board.boardArray))
            {
                presenter.Send("There has been a tie");
            }

            Console.ReadLine();
        }
    }
}
