// Created by Maxim Sarandev
// Jan 2018
// Custom Software for BEDE Gaming. All rights reserved

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SarandevBattleships
{
    public class GameBoard
    {
        // Defines the game board with all necessary properties and methods 
        
        // Variables definition
        private int grid_size = 10; // enables custom sizes (default 10)
        private int shots_taken;
        private List<int> shots_successful = new List<int>(); // stores id's of squares
        private int shots_unsuccessful = 0; // default to 0
        private int ships_count = 0; // default to 0
        private List<GameSquare> full_board = new List<GameSquare>();
        
        
        // Properties definition
        
        // Generates the initial board area
        public bool GenerateBoard()
        {
            int x; // define the horizontal counter
            int y; // define the vertical counter

            try
            {
                // Populates the board with 10x10 game square objects
                for (x = 1; x < grid_size + 1; x++)
                {
                    // Control for the columns
                    for (y = 1; y < grid_size + 1; y++)
                    {
                        // Control for the rows

                        // Create new game square
                        GameSquare gs1 = new GameSquare(x, y); // parse the current x,y

                        full_board.Add(gs1); // add the gamesquare to the board element
                    }

                    // reset y
                    y = 0;
                }

                // upon successful generation, return status
                
                return true;
            }
            catch (System.IndexOutOfRangeException e)
            {
                // print the exception text
                Console.WriteLine("Exception: {0}", e);

                return false; // return false to halt further execution
            }
        }

        // Populates the game board with 3 ships
        public bool PopulateBoard()
        {   
            Ship shp1 = new Ship(); // new ship object
            bool gen_ok = false; // control variable
            
            for (int ship_count = 0; ship_count < 3; ship_count++)
            {
                // Create a ship
                if (ship_count == 0)
                {
                    // Create the Battleship
                    shp1.SetSize(5);
                }
                else
                {
                    // Create the destroyer
                    shp1.SetSize(4);
                }

                // Randomise rotation
                Random rand = new Random();
                shp1.SetRotation(rand.Next(0, 1)); // rotate the ship randomly
                
                // Place ship based on type/rotation
                if (shp1.GetSize() == 5)
                {
                    // Battleship, restrict boundries
                    int x = 1; // init horizontal axis
                    int y = 1; // init vertical axis
                    
                    try
                    {
                        if (shp1.GetRotation() == 1)
                        {
                            // ship is rotated, limit on vertical (increase horizontal)
                            gen_ok = false; // reset var
                            
                            while (gen_ok == false)
                            {
                                // generate until all ships have been placed correctly
                                gen_ok = PlaceShip(y,x,shp1.GetSize());   
                            }
                        }
                        else
                        {
                            // ship is not rotated, limit on horizontal (increase vertical)
                            gen_ok = false; // reset var
                            
                            while (gen_ok == false)
                            {
                                // generate until all ships have been placed correctly
                                gen_ok = PlaceShip(x,y,shp1.GetSize());
                            }
                            
                        }
                    }catch(System.ArgumentOutOfRangeException e)
                    {
                        // print the exception text
                        Console.WriteLine("Exception: {0}", e);

                        return false; // return false to halt further execution
                    }
                }
                else
                {
                    // Repeat process for the Destroyers
                    
                    int x = 1; // init horizontal axis
                    int y = 1; // init vertical axis
                    
                    try
                    {
                        if (shp1.GetRotation() == 1)
                        {
                            // ship is rotated, limit on vertical (increase horizontal)
                            gen_ok = false; // reset var
                            
                            while (gen_ok == false)
                            {
                                // generate until all ships have been placed correctly
                                gen_ok = PlaceShip(y,x,shp1.GetSize());   
                            }
                        }
                        else
                        {
                            // ship is not rotated, limit on horizontal (increase vertical)
                            gen_ok = false; // reset var
                            
                            while (gen_ok == false)
                            {
                                // generate until all ships have been placed correctly
                                gen_ok = PlaceShip(x,y,shp1.GetSize());
                            }
                        }
                    }catch(System.ArgumentOutOfRangeException e)
                    {
                        // print the exception text
                        Console.WriteLine("Exception: {0}", e);

                        return false; // return false to halt further execution
                    }
                }
            }

            return true;
        }
        
        // Method for placing a ship on the board
        private bool PlaceShip(int a, int b, int ship_size)
        {
            Random rand = new Random(); // init
            int index_in_array; // init
            int health_checker = 0; // determines whether generation was successful
            
            a = rand.Next(1, 6); // pick a value for the vert. axis

            while(true)
            {
                b = rand.Next(1, 5); // get a value for the hor. axis

                if (b + 5 < 10 && b > 1) // if it fits in the grid bounds, exit loop
                {
                    break;
                }
            }
                            
            for (int count = 0; count < ship_size; count++)
            {
                // loop through the squares for 5 squares
                index_in_array = (b-1)*10 + a; // update index
                
                // check if the space is occupied
                if (full_board[index_in_array].GetSquareOccupied() == false)
                {
                    full_board[index_in_array].SetSquareOccupied(true); // set space to occupied

                    b++; // increment
                    health_checker++; // increment
                }
            }
            
            // Check if all requested squares have been occupied
            if (health_checker == ship_size)
            {
                return true; // all generated correctly
            }

            return false; // default return
        }

        // Method for showing the whole gameboard
        public void ShowGameBoard()
        {
            int count = 0; // init a counter
            int row_counter = 0; // init the counter
            string[] alpha_container = new string[10] {"A","B","C","D","E","F","G","H","I","J"}; // create/init
            
            // print the first denomination
            Console.Write(" 1  2  3  4  5  6  7  8  9  10");
            Console.WriteLine();
            
            foreach (GameSquare i in full_board)
            {   
                if (shots_successful.Contains(full_board.IndexOf(i)))
                {
                    Console.Write("[X]"); // print the shot square    
                }
                else
                {
                    Console.Write("[ ]"); // print the empty square   
                }
                
                count++; // increment
                
                if (count == 10) // check if at end of row (integer results only)
                {
                    Console.Write(" " + alpha_container[row_counter]);
                    Console.WriteLine(); // new row
                    
                    row_counter++; // increment
                    count = 0; // reset
                }
            }
        }
        
        // Method for taking a shot
        public int TakeAShot(string inp)
        {
            // check the input
            if (inp.Length == 2)
            {
                // check if user hit all ships
                if (shots_successful.Count < 13)
                {
                    inp = inp.ToUpper(); // resterise the string

                    int strike_on; // init
                    string[] alpha_list = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"}; // init

                    // filter out non-prefered letters
                    if (alpha_list.Contains(inp.Substring(0, 1)))
                    {
                        // get the index of the letter
                        int array_index = Array.IndexOf(alpha_list, inp.Substring(0, 1));

                        // generate the strike on ID
                        strike_on = (int.Parse(inp.Substring(1, 1)) + array_index * 10) - 1;

                        // check if the square is occupied
                        if (full_board[strike_on].GetSquareOccupied() == true)
                        {
                            // add the square to the hits list
                            shots_successful.Add(strike_on);

                            // increment the shot counter
                            shots_taken++;

                            if (shots_successful.Count == 13)
                            {
                                // signal game completion
                                return 1;
                            }
                        }
                        else
                        {
                            // increment the counters
                            shots_taken++;
                            shots_unsuccessful++;
                        }
                    }
                }
            }

            return 0; // static
        }
        
        // Method for calculating hit rating
        public string CalculateHitRating()
        {
            // control for empty values
            if (shots_successful.Count != 0 &
                shots_unsuccessful != 0 &
                shots_taken != 0)
            {
                // calculate the hit rating
                if (shots_successful.Count > shots_unsuccessful)
                {
                    // personalised message upon completion
                    return "Hit rating: POSITIVE" + "\n" + 
                           "On target: " + shots_successful.Count + "\n"+
                           "Missed: " + shots_unsuccessful;   
                }
                else
                {
                    // personalised message upon completion
                    return "Hit rating: Needs improvement" + "\n" + 
                           "On target: " + shots_successful.Count + "\n"+
                           "Missed: " + shots_unsuccessful;
                }
            }
            else
            {
                // passive error handling
                return "No shots taken";
            }
        }
        
        // -------------------
        // DEBUG Methods below
        
        // Method to print the board verbatim
        public void PrintWholeBoard()
        {
            int count = 0;
            
            foreach (GameSquare i in full_board) {
                if (i.GetSquareOccupied() == true)
                {
                    Console.Write("[*]");   
                }
                else
                {
                    Console.Write("[ ]");
                }

                count++;
                
                if (count == 11)
                {
                    Console.WriteLine(); // new row
                    count = 0; // reset
                }
            }
        }
        
        // Debug method to count actual elements in AL
        public void CheckBoardSize()
        {
            Console.WriteLine("Size: {0}", this.full_board.Count);
        }
    }
}