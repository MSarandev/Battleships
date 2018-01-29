// Created by Maxim Sarandev
// Jan 2018
// Custom Software for BEED Gaming. All rights reserved

using System;

namespace SarandevBattleships
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Main application method
            
            var ship1 = new Ship("alpha",4,90,0,0);
            
            ship1.print_me();
            
            ship1.Deconstruct(ship1);
        }
    }
}