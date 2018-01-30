// Created by Maxim Sarandev
// Jan 2018
// Custom Software for BEDE Gaming. All rights reserved

namespace SarandevBattleships
{
    public class GameSquare
    {
        // Custom class to define a square on the game board
        
        // Variables Declaration
        private int square_x;
        private int square_y;
        private bool square_occupied;
        
        // Properties definition
        public void SetSquareX(int inp)
        {
            square_x = inp;
        }

        public int GetSquareX()
        {
            return square_x;
        }
        
        public void SetSquareY(int inp)
        {
            square_y = inp;
        }

        public int GetSquareY()
        {
            return square_y;
        }
        
        public void SetSquareOccupied(bool inp)
        {
            square_occupied = inp;
        }

        public bool GetSquareOccupied()
        {
            return square_occupied;
        }
        
        // Constructor definition
        public GameSquare(int squareX, int squareY)
        {
            square_x = squareX;
            square_y = squareY;
            square_occupied = false; // default to empty square
        }
        
        // Empty constructor
        public GameSquare()
        {
            
        }
        
        // Custom methods
        public string PrintMe()
        {
            return square_x + "(X), " + 
                   square_y + "(Y), " + 
                   square_occupied;
        }
    }
}