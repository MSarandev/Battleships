// Created by Maxim Sarandev
// Jan 2018
// Custom Software for BEDE Gaming. All rights reserved

using System;
using System.Collections.Generic;

namespace SarandevBattleships
{
    public class GameBoard
    {
        // Defines the game board with all necessary properties and methods 
        
        // Variables definition
        private int size_x;
        private int size_y;
        private int shots_taken;
        private int shots_successful;
        private int shots_unsuccessful;
        private int ships_count;
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
                for (x = 1; x < 11; x++)
                {
                    // Control for the columns
                    for (y = 1; y < 11; y++)
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

            // 
        }

        // Populates the game board with 3 ships
        public bool PopulateBoard()
        {   
            Ship shp1 = new Ship(); // new ship object
            
            for (int ship_count = 0; ship_count < 2; ship_count++)
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
                //shp1.SetRotation(rand.Next(0, 1)); // rotate the ship randomly
                shp1.SetRotation(1);
                
                // Place ship based on type/rotation
                if (shp1.GetSize() == 5)
                {
                    // Battleship, restrict boundries
                    int x = 1; // init horizontal axis
                    int y = 1; // init vertical axis
                    int index_in_array = (x + y) - 1; // game square index in AL

                    try
                    {
                        if (shp1.GetRotation() == 1)
                        {
                            // ship is rotated, limit on vertical
                            
                            //y = rand.Next(1, 100); // get new random number
                            //x = rand.Next(1, 6); // get new random number
                            
                            // DEBUG
                            y = 1;
                            x = 1;
                            // DEBUG
                            
                            // Rotation requires a re-worked index function
                            // index_in_array = ((x + y) - 3) * (11 - y) + (y - 1);

                            for (int count = 0; count < 5; count++)
                            {
                                // for each block in the ship, change the square occ.
                                index_in_array = (x + y) - 1; // update the index
                                GameSquare gs1 = new GameSquare();

                                gs1 = full_board[index_in_array]; // push the properties to the object
                                gs1.SetSquareOccupied(true); // change property

                                full_board[index_in_array] = gs1; // update in the list

                                y++; // increment in the vertical axis
                            }

                        }
                        else
                        {
                            // ship is not rotated, limit on horizontal
                            
                            y = rand.Next(1, 6); // get new random number
                            x = rand.Next(1, 100); // get new random number

                            for (int count = 0; count < 5; count++)
                            {
                                // for each block in the ship, change the square occ.
                                index_in_array = (x + y) - 1; // update the index
                                GameSquare gs1 = new GameSquare();

                                gs1 = full_board[index_in_array]; // push the properties to the object
                                gs1.SetSquareOccupied(true); // change property

                                full_board[index_in_array] = gs1; // update in the list

                                x++; // increment in the vertical axis
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

        // Method to print the board verbatim
        public void PrintWholeBoard()
        {   
            foreach (GameSquare i in full_board) {
                Console.WriteLine(i.PrintMe());
            }
        }
        
        // Debug method to count actual elements in AL
        public void CheckBoardSize()
        {
            Console.WriteLine("Size: {0}", this.full_board.Count);
        }
    }
}