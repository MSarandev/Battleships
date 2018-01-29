// Created by Maxim Sarandev
// Jan 2018
// Custom Software for BEED Gaming. All rights reserved

using System;

namespace SarandevBattleships
{
    public class Ship
    {
        // Variables Declaration
        public string id; // unique ship id
        public string type; // defines the type of ship
        public int size; // ship size
        public int rotation; // ship rotation
        public int pos_x; // position on grid (X coordinate)
        public int pos_y; // position on grid (Y coordinate)
        
        // Constructor definition
        public Ship(string id, int size, int rotation, int posX, int posY)
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

            this.rotation = rotation;
            pos_x = posX;
            pos_y = posY;
        }
        
        
        // De-constructor definition
        public void Deconstruct(Ship shp1)
        {
            // Deconstruct the object based on the ship parsed
            id = shp1.id;
            type = shp1.type;
            size = shp1.size;
            rotation = shp1.rotation;
            pos_x = shp1.pos_x;
            pos_y = shp1.pos_y;
        }
        
        // Custom methods
        public void print_me()
        {
            Console.WriteLine(id);
            Console.WriteLine(type);
        }
    }
}