using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaPacman
{
    public class TileMap
    {
        String spriteSheetName;
        Texture2D spriteSheet;
        List<Rectangle> allTiles;
        List<Dictionary<Point, int>> layers;
        int tileSize;
        Rectangle[] collisionLayer;
        
        public TileMap(String spriteSheetName, int numOfRows, int numOfColumns, Point frameSize, Point offset,int tileSize)
        {
            allTiles = new List<Rectangle>();
            layers = new List<Dictionary<Point, int>>();
            
            this.tileSize = tileSize;
            this.spriteSheetName = spriteSheetName;
            for (int i = 0; i < numOfColumns; i++)
            {
                for (int j = 0; j < numOfRows; j++)
                {
                    allTiles.Add(new Rectangle(
                        (int)(i * (frameSize.X + offset.X)), // Calculate based on column index
                        (int)(j * (frameSize.Y + offset.Y)), // Calculate based on row index
                        (int)frameSize.X,
                        (int)frameSize.Y));
                }
            }
        }
        public void AddLayer(String fileLocation)
        {
            

            Dictionary<Point, int> result = new Dictionary<Point, int>();
            StreamReader reader = new StreamReader(fileLocation);
            String line;
            int y = 0;
            while((line = reader.ReadLine()) != null)
            {
                String[] items = line.Split(',');
                for (int i = 0; i < items.Length; i++)
               {
                    result.Add(new Point(i, y), int.Parse(items[i]));
                }
                y++;
            }
            layers.Add(result);
        }
        public void AddCollisionLayer(String fileLocation,int emptySpaceID,int collidorSize)
        {


            List<Rectangle> result = new List<Rectangle>();
            StreamReader reader = new StreamReader(fileLocation);
            String line;
            int y = 0;
            int offset = (tileSize - collidorSize) / 2;
            while ((line = reader.ReadLine()) != null)
            {
                String[] items = line.Split(',');
                for (int i = 0; i < items.Length; i++)
                {
                    if (int.Parse(items[i]) != emptySpaceID)
                    result.Add(new Rectangle(i*tileSize + offset, y*tileSize + offset,collidorSize, collidorSize));
                }
                y++;
            }
            collisionLayer = result.ToArray();
        }
        public Rectangle[] getCollisionLayer()
        {
            return collisionLayer;
        }
        public bool isColliding(Rectangle rect)
        {
            bool temp = false;
            foreach(Rectangle collider in collisionLayer)
            {
                if(collider.Intersects(rect))
                {
                    temp = true;
                    break;
                }
            }
            return temp;
        }
        public Rectangle GetTileMapBounds()
        {
            // Initialize boundaries
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;

            // Iterate through all layers
            foreach (var layer in layers)
            {
                foreach (var tile in layer.Keys)
                {
                    // Update boundaries using the tile positions
                    if (tile.X < minX) minX = tile.X;
                    if (tile.Y < minY) minY = tile.Y;
                    if (tile.X > maxX) maxX = tile.X;
                    if (tile.Y > maxY) maxY = tile.Y;
                }
            }

            // Convert to pixel coordinates using the tileSize
            minX *= tileSize;
            minY *= tileSize;
            maxX = (maxX + 1) * tileSize; // Add 1 to include the last tile
            maxY = (maxY + 1) * tileSize; // Add 1 to include the last tile

            // Return the bounds as a rectangle
            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }
        public void Load(Game game)
        {
            spriteSheet = game.Content.Load<Texture2D>(spriteSheetName);
        }
        public void Update(GameTime gameTime)
        {
            
        }
        public void Draw(SpriteBatch batch)
        {
            foreach(Dictionary<Point,int> layer in layers)
            {
                foreach(var item in layer)
                {
                    int tileIndex = (int)item.Value;
                    if (tileIndex >= 0 && tileIndex < allTiles.Count)
                    {
                        batch.Draw(
                            spriteSheet,
                            new Rectangle((int)item.Key.X * tileSize, (int)item.Key.Y * tileSize, tileSize, tileSize),
                            allTiles[tileIndex],
                            Color.White);
                    }
                }
            }
            
        }
    }
}
