// Created by Maxim Sarandev
// Jan 2018
// Custom Software for BEDE Gaming. All rights reserved

using System;

namespace SarandevBattleships
{
    public class Ship
    {
        // Defines the battleship class, with all necesary properties and methods
        
        
        // Variables Declaration
        private string id; // unique ship id
        private string type; // defines the type of ship
        private int size; // ship size
        private int rotation; // ship rotation (0 - upright, 1 - horizontal)
        private int pos_x; // position on grid (X coordinate)
        private int pos_y; // position on grid (Y coordinate)
        
        // Properties definition (some are omitted as they're obsolete
        public void SetPosX (int inp)
        {
            pos_x = inp;
        }
        
        public int GetPosX()
        {
            return pos_x;
        }
        
        public void SetPosY (int inp)
        {
            pos_y = inp;
        }
        
        public int GetPosY()
        {
            return pos_y;
        }

        public void SetRotation(int inp)
        {
            rotation = inp;
        }

        public int GetRotation()
        {
            return rotation;
        }

        public void SetSize(int inp)
        {
            if (inp <= 5 & inp >= 4) // error control
            { 
                size = inp;   
                ChangeShipType(); // update the ship type
            }
        }

        public int GetSize()
        {
            return size;
        }
        
        // Constructor definition
        public Ship(string id, int size)
        {
            this.id = id;
            this.size = size;
            // Set the type of ship based on the size
            switch (size)
            {
                case 4:
                    type = "Destroyer";
                    break;
                case 5:
                    type = "Battleship";
                    break;
                default: type = "Undefined";
                    break;
            }

            // The properties are defaulted to no rotation, x=0, y=0
            rotation = 0; // set to no rotation (0 default/horizontal)
            pos_x = 0;
            pos_y = 0;
        }

        // Empty constructor
        public Ship()
        {
            
        }
        
        // Custom methods

        public void ChangeShipType()
        {
            switch (size)
            {
                case 4:
                    type = "Destroyer";
                    break;
                case 5:
                    type = "Battleship";
                    break;
                default: type = "Undefined";
                    break;
            }
        }
        
        // Prints the object properties (Debug)
        public void print_me()
        {
            Console.WriteLine(id + ", " +
                              size + ", " +
                              type + ", " +
                              rotation + ", " +
                              pos_x + ", " +
                              pos_y);
        }
    }
}