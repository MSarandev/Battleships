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
            GameBoard gb1 = new GameBoard(); // create new gameboard

            bool control = gb1.GenerateBoard(); // generate the gameboard
            Console.WriteLine("OK - {0}",control); // print generation variable

            if (control == true)
            {
                // generation complete, proceed
                control = gb1.PopulateBoard(); // populate the board with ships

                if (control == true)
                {
                    // population complete, proceed

                    int res = 0; // init
                    
                    // Main game logic 
                    while (true)
                    {
                        // loop until user exits
                        Console.Clear(); // clear the console of output
                        gb1.MenuGraphic(); // print the graphic
                        
                        gb1.ShowGameBoard(); // print the gameboard
                        gb1.ShowHits(gb1.previous_hit);
                        
                        Console.WriteLine("\n EE to exit"); // display 1.
                        
                        Console.WriteLine("Enter square id (A1, B2..) >> ");
                        string inp = Console.ReadLine(); // accept input

                        if (inp == "EE" || inp == "ee")
                        {
                            break; // exit
                        }
                        else
                        {
                            res = gb1.TakeAShot(inp); // call the function

                            if (res == 1)
                            {
                                // game complete, clear the screen
                                Console.Clear();
                                // show info
                                gb1.ScoreGraphic(); // show the graphic
                                string info = gb1.CalculateHitRating(); // calc the rating
                                Console.WriteLine(info); // display
                                
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // faulty execution
                    
                    Console.WriteLine("Initialisation Failed. Halting!"); // print error
                }
            }
            else
            {
                // faulty execution
                
                Console.WriteLine("Initialisation Failed. Halting!"); // print error
            }
        }
    }
}