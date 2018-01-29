// Created by Maxim Sarandev
// Jan 2018
// Custom Software for BEDE Gaming. All rights reserved

using System;

namespace SarandevBattleships
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Main application method
            
            GameBoard gb1 = new GameBoard();

            bool control = gb1.GenerateBoard();
            Console.WriteLine(control);
            
            gb1.PopulateBoard();
            
            gb1.PrintWholeBoard();
        }
    }
}