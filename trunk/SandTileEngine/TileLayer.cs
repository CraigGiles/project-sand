#region File Description
//-----------------------------------------------------------------------------
// TileGrid.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace SandTileEngine
{
    /// <summary>
    /// EDUCATIONAL: Class used to align tiles to a regular grid.
    /// This represents a tiling "layer" in this sample
    /// </summary>
    public class TileLayer
    {
        #region Constants

        const int cMinTileSize = 20;
        const int cMaxTileSize = 100;

        #endregion

        #region Tile Information

        static int tileWidth = 32;
        static int tileHeight = 32;

        /// <summary>
        /// Width of an individual tile
        /// </summary>
        public static int TileWidth
        {
            get { return tileWidth; }
            set
            {
                tileWidth = (int)MathHelper.Clamp(value, cMinTileSize, cMaxTileSize);
            }
        }

        /// <summary>
        /// Height of an individual tile
        /// </summary>
        public static int TileHeight
        {
            get { return tileHeight; }
            set
            {
                tileHeight = (int)MathHelper.Clamp(value, cMinTileSize, cMaxTileSize);
            }
        }

        // Grid information
        int[,] map;

        /// <summary>
        /// Returns the width of the layer in pixels
        /// </summary>
        public int WidthInPixels
        {
            get { return Width * tileWidth;}
        }

        /// <summary>
        /// Returns the height of the layer in pixels
        /// </summary>
        public int HeightInPixels
        {
            get { return Height * tileHeight; }
        }

        /// <summary>
        /// Returns the width of the layer in tiles
        /// </summary>
        public int Width
        {
            get { return map.GetLength(1); }
        }

        /// <summary>
        /// Returns the height of the layer in tiles
        /// </summary>
        public int Height
        {
            get { return map.GetLength(0); }
        }

        #endregion

        #region Fields

        private string gridName;
        private SpriteSheet sheet;
        private Rectangle visibleTiles;

        //drawing parameters
        private Vector2 cameraPostionValue;
        private float zoomValue;
        private Vector2 scaleValue;
        private Vector2 displaySize;
        private bool visibilityChanged;
        private byte alpha;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that loads a tile layer with the specified width and height
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        public TileLayer(int width, int height)
		{
			map = new int[height, width];

			for (int x = 0; x < width; x++)
				for (int y = 0; y < height; y++)
					map[y, x] = -1;
		}

        /// <summary>
        /// Creates a layer with the specified width and height along with a sprite sheet
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        /// <param name="tileSheet">Sprite sheet containing the tile set used</param>
        public TileLayer(int width, int height, SpriteSheet tileSheet)
            :this(width, height)
        {
            sheet = tileSheet;
        }

        /// <summary>
        /// Creates a layer with a specified map
        /// </summary>
        /// <param name="existingMap">Map to be copied to the layer</param>
		public TileLayer(int[,] existingMap)
		{
			map = (int[,])existingMap.Clone();
		}

        #endregion

        #region Public Accessors

        public Vector2 CameraPosition
        {
            set
            {
                cameraPostionValue = value;
                visibilityChanged = true;
            }
            get
            {
                return cameraPostionValue;
            }
        }

        public float CameraZoom
        {
            set
            {               
                zoomValue = value;
                visibilityChanged = true;
            }
            get
            {
                return zoomValue;
            }
        }

        public Vector2 TileScale
        {
            set
            {
                scaleValue = value;
                visibilityChanged = true;
            }
            get
            {
                return scaleValue;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the specified row, col of the map with the tile index
        /// </summary>
        /// <param name="row">Row of the tile</param>
        /// <param name="col">Col of the tile</param>
        /// <param name="tile">Tile index number to use</param>
        public void SetTile(int row, int col, int tile)
        {
            map[row, col] = tile;
        }

        /// <summary>
        /// Prints out the grid of corresponding tiles.
        /// </summary>
        public void debugPrint()
        {
            Console.WriteLine("-=- " + gridName + "-=-\n");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j] + "\t");
                }
                Console.WriteLine();
            }

            // Extra space after everything is written
            Console.WriteLine();
        }

        /// <summary>
        /// This function determines which tiles are visible on the screen,
        /// given the current camera position, rotation, zoom, and tile scale
        /// </summary>
        private void DetermineVisibility()
        {
            //create the view rectangle
            Vector2 upperLeft = Vector2.Zero;
            Vector2 upperRight = Vector2.Zero;
            Vector2 lowerLeft = Vector2.Zero;
            Vector2 lowerRight = Vector2.Zero;
            lowerRight.X = ((displaySize.X / 2) / zoomValue);
            lowerRight.Y = ((displaySize.Y / 2) / zoomValue);
            upperRight.X = lowerRight.X;
            upperRight.Y = -lowerRight.Y;
            lowerLeft.X = -lowerRight.X;
            lowerLeft.Y = lowerRight.Y;
            upperLeft.X = -lowerRight.X;
            upperLeft.Y = -lowerRight.Y;

            lowerLeft += (cameraPostionValue);
            lowerRight += (cameraPostionValue);
            upperRight += (cameraPostionValue);
            upperLeft += (cameraPostionValue);

            //the idea here is to figure out the smallest square
            //(in tile space) that contains tiles
            //the offset is calculated before scaling
            float top = MathHelper.Min(
                MathHelper.Min(upperLeft.Y, lowerRight.Y),
                MathHelper.Min(upperRight.Y, lowerLeft.Y));

            float bottom = MathHelper.Max(
                MathHelper.Max(upperLeft.Y, lowerRight.Y),
                MathHelper.Max(upperRight.Y, lowerLeft.Y));
            float right = MathHelper.Max(
                MathHelper.Max(upperLeft.X, lowerRight.X),
                MathHelper.Max(upperRight.X, lowerLeft.X));
            float left = MathHelper.Min(
                MathHelper.Min(upperLeft.X, lowerRight.X),
                MathHelper.Min(upperRight.X, lowerLeft.X));
            

            //now figure out where we are in the tile sheet
            float scaledTileWidth = (float)Width * scaleValue.X;
            float scaledTileHeight = (float)Height * scaleValue.Y;

            //get the visible tiles
            visibleTiles.X = (int)(left / (scaledTileWidth));
            visibleTiles.Y = (int)(top / (scaledTileWidth));

            //get the number of visible tiles
            visibleTiles.Height =
                (int)((bottom) / (scaledTileHeight)) - visibleTiles.Y + 1;
            visibleTiles.Width =
                (int)((right) / (scaledTileWidth)) - visibleTiles.X + 1;

            //clamp the "upper left" values to 0
            if (visibleTiles.X < 0) visibleTiles.X = 0;
            if (visibleTiles.X > (Width - 1)) visibleTiles.X = Width;
            if (visibleTiles.Y < 0) visibleTiles.Y = 0;
            if (visibleTiles.Y > (Height - 1)) visibleTiles.Y = Height;


            //clamp the "lower right" values to the gameboard size
            if (visibleTiles.Right > (Width - 1))
                visibleTiles.Width = (Width - visibleTiles.X);

            if (visibleTiles.Right < 0) visibleTiles.Width = 0;

            if (visibleTiles.Bottom > (Height - 1))
                visibleTiles.Height = (Height - visibleTiles.Y);

            if (visibleTiles.Bottom < 0) visibleTiles.Height = 0;

            visibilityChanged = false;
        }

        public void Draw(SpriteBatch batch, Camera camera)
        {
            if (visibilityChanged) DetermineVisibility();
            

            float scaledTileWidth = (float)tileWidth * scaleValue.X;
            float scaledTileHeight = (float)tileHeight * scaleValue.Y;
            Vector2 screenCenter = new Vector2(
                (displaySize.X / 2),
                (displaySize.Y / 2));
            //Vector2 screenCenter = Vector2.Zero;

            //begin a batch of sprites to be drawn all at once
            batch.Begin(SpriteBlendMode.AlphaBlend);

            Rectangle sourceRect = new Rectangle();
            Vector2 scale = Vector2.One;
            bool validTile;

            for (int x = visibleTiles.Left; x < visibleTiles.Right; x++)
            //for (int x = 0; x < 10; x++)
            {
                for (int y = visibleTiles.Top; y < visibleTiles.Bottom; y++)
                //for (int y = 0; y < 10; y++)
                {
                    if (map[x,y] != -1)
                    {
                        //Get the tile's position from the grid
                        //in this section we're using reference methods
                        //for the high frequency math functions
                        Vector2 position = Vector2.Zero;
                        position.X = (float)x * scaledTileWidth;
                        position.Y = (float)y * scaledTileHeight;

                        //Now, we get the camera position relative to the tile's position
                        Vector2.Subtract(ref cameraPostionValue, ref position,
                            out position);
                        
                        //get the tile's final size (note that scaling is done after 
                        //determining the position)
                        Vector2.Multiply(ref scaleValue, zoomValue, out scale);

                        //get the source rectangle that defines the tile
                        validTile = sheet.GetRectangle(ref map[x,y],out sourceRect);

                        //Draw the tile.  Notice that position is used as the offset and
                        //the screen center is used as a position.  This is required to
                        //enable scaling and rotation about the center of the screen by
                        //drawing tiles as an offset from the center coordinate
                        // Note that if the tile isn't valid (i.e., there's no tile in that
                        // spot for that layer), don't render anything
                        if (validTile)
                            batch.Draw(sheet.Texture, screenCenter, sourceRect, new Color(255, 255, 255, alpha),
                                1f, position, scale, SpriteEffects.None, 0.0f);
                    }
                }
            }

            batch.End();
        }
        #endregion
    }
}

