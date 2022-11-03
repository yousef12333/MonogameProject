﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameProject.Tiles
{
    internal class Map
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();
        public List<CollisionTiles> CollisionTiles { get { return collisionTiles; } }

        private int width, height, number;
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public int Number { get { return number; } }

        public Map() { }
        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    number = map[y, x];
                    if (number > 0) collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));
                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in collisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
