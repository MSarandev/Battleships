// Created by Maxim Sarandev
// Jan 2018
// Custom Software for BEDE Gaming. All rights reserved

using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

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
            this.pos_x = inp;
        }
        
        public int GetPosX()
        {
            return this.pos_x;
        }
        
        public void SetPosY (int inp)
        {
            this.pos_y = inp;
        }
        
        public int GetPosY()
        {
            return this.pos_y;
        }

        public void SetRotation(int inp)
        {
            this.rotation = inp;
        }

        public int GetRotation()
        {
            return this.rotation;
        }

        public void SetSize(int inp)
        {
            if (inp <= 5 & inp >= 4) // error control
            { 
                this.size = inp;   
                this.ChangeShipType(); // update the ship type
            }
        }

        public int GetSize()
        {
            return this.size;
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
                    this.type = "Destroyer";
                    break;
                case 5:
                    this.type = "Battleship";
                    break;
                default: this.type = "Undefined";
                    break;
            }

            // The properties are defaulted to no rotation, x=0, y=0
            this.rotation = 0; // 1 is rotated
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
                    this.type = "Destroyer";
                    break;
                case 5:
                    this.type = "Battleship";
                    break;
                default: this.type = "Undefined";
                    break;
            }
        }
        
        // Prints the object properties (Debug)
        public void print_me()
        {
            Console.WriteLine(id.ToString() + ", " +
                              size.ToString() + ", " +
                              type + ", " +
                              rotation.ToString() + ", " +
                              pos_x.ToString() + ", " +
                              pos_y.ToString());
        }
    }
}