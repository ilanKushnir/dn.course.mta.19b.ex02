﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B19_Ex02_Othelo
{
    class Display
    {
        public static void printUI(string message, Player currentPlayer, Player player1, Player player2, Board gameBoard)
        {
            printTitle();
            printDivider(gameBoard.Size);
            printMessage(message);
            printDivider(gameBoard.Size);
            printStats(currentPlayer, player1, player2);
            printDivider(gameBoard.Size);
            printBoard(gameBoard);
            printDivider(0);
            // input goes here
        }
        public static void printDivider(int boardSize = 0)
        {
            if (boardSize != 0)
            {
                Console.Write("--");
                for (int i = 0; i < boardSize; i++)
                {
                    Console.Write("----");
                }
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine();
            }
        }
        public static void printTitle()
        {
            Console.WriteLine("Welcome to Othelo game! - by Ofir & Ilan");
        }
        public static void printMessage(string message)
        {
            Console.WriteLine("Message: {0}", message);
        }
        public static void printStats(Player currentPlayer, Player player1, Player player2)
        {
            Console.WriteLine("Turn: {0}, Player 1: {1}, Player 2: {2}", currentPlayer.Name, player1.Points, player2.Points);
        }
        public static void printBoard(Board i_Board)
        {
            int i, j, k, boardSize = i_Board.Size;
            char charToPrint = 'A';

            // Top line (Char coordinates)
            Console.Write("   ");
            for (i = 0; i < boardSize; i++)
            {
                Console.Write(" {0}  ", charToPrint++);
            }
            Console.WriteLine();
            Console.Write("  =");
            for (i = 0; i < boardSize; i++)
            {
                Console.Write("====");
            }
            Console.WriteLine();

            // Counted lines section
            for (i = 0; i < boardSize; i++)
            {
                Console.Write("{0} ", i);
                for (j = 0; j < boardSize; j++)
                {
                    Console.Write("|   ");
                }
                Console.WriteLine("|");

                Console.Write("  ");
                for (k = 0; k < boardSize; k++)
                {
                    Console.Write("====");
                }
                Console.WriteLine("=");
            }

        }
        public static void updateUI(string message, Player currentPlayer, Player player1, Player player2, Board gameBoard)
        {
            // Delay if bot's turn
            Ex02.ConsoleUtils.Screen.Clear();                   // Clear screen
            printUI(message, currentPlayer, player1, player2, gameBoard);
        }

        public static void initGame(out string i_player1, out string i_player2, out int i_BoardSize, out bool i_isMultiplayer)
        {
            Console.WriteLine("Choose board size:");
            Console.WriteLine("1) 6x6");
            Console.WriteLine("2) 8x8");
            i_BoardSize = int.Parse(Console.ReadLine());
            while(i_BoardSize != 1 && i_BoardSize != 2)
            {
                Console.WriteLine("Please choose 1 or 2");
                i_BoardSize = int.Parse(Console.ReadLine());
            }

            Display.printDivider(i_BoardSize);

            Console.WriteLine("Choose game mode:");
            Console.WriteLine("1) Single player");
            Console.WriteLine("2) Multiplayer");
            int isMultiplayerInput = int.Parse(Console.ReadLine());
            while (isMultiplayerInput != 1 && isMultiplayerInput != 2)
            {
                Console.WriteLine("Please choose 1 or 2");
                isMultiplayerInput = int.Parse(Console.ReadLine());
            }
            i_isMultiplayer = isMultiplayerInput == 1 ? false : true;

            Display.printDivider(i_BoardSize);

            Console.WriteLine("Please enter first player's name:");
            i_player1 = Console.ReadLine();
            if(i_isMultiplayer == true)
            {
                Console.WriteLine("Please enter second player's name:");
                i_player2 = Console.ReadLine();
            }
            else
            {
                i_player2 = "Computer";
                Console.WriteLine("{0}, you will play against the computer", i_player1);
            }
        }
    }
} 
