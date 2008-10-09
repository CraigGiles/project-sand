#region File Description
//-----------------------------------------------------------------------------
// Layer.cs
//
// Copyright (C) Project Sand
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
    /// Base class that all layers (TileLayer, GridLayer, and SheetLayer) inherit from.  Provides
    /// basic camera controls and render parameters
    /// </summary>
    public class BaseLayer
    {
        #region Constants

        protected const int cMinTileSize = 20;
        protected const int cMaxTileSize = 100;
        protected const int cNoTile = -1;

        #endregion

        #region Camera Properties

        protected Vector2 cameraPostionValue;

        /// <summary>
        /// Current position of the camera on the screen
        /// </summary>
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

        protected float zoomValue = 1f;

        /// <summary>
        /// How much zoom the camera has
        /// </summary>
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

        protected Vector2 scaleValue = Vector2.One;

        /// <summary>
        /// Scale of the tiles
        /// </summary>
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

        protected Vector2 displaySize;

        /// <summary>
        /// Used to determine how much to render onto the display before
        /// being clipped by the edges
        /// </summary>
        public Vector2 DisplaySize
        {
            set
            {
                displaySize = value;
                visibilityChanged = true;
            }
            get
            {
                return displaySize;
            }
        }

        /// <summary>
        /// Internal bool to determine if the camera changed since last update
        /// </summary>
        protected bool visibilityChanged;

        /// <summary>
        /// Rectangle representing the tiles visible on the display
        /// </summary>
        protected Rectangle visibleTiles;

        #endregion

        #region Layer Properties

        /// <summary>
        /// Sheet the layer is using to render the tiles
        /// </summary>
        protected SpriteSheet sheet;

        /// <summary>
        /// Sheet the layer is using to render the tiles
        /// </summary>
        public SpriteSheet Sheet
        {
            get { return sheet; }
        }

        /// <summary>
        /// Texture the layer is using to render the tiles
        /// </summary>
        protected Texture2D texture;

        protected float alpha = 1.0f;

        /// <summary>
        /// Determines the opacity of the layer
        /// </summary>
        public float Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        #endregion

        #region Tile Properties

        protected static int tileWidth = 32;
        protected static int tileHeight = 32;

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
        protected int[,] map;

        /// <summary>
        /// Returns the matrix of tile information on the layer
        /// </summary>
        public int[,] Map
        {
            get { return map; }
        }

        /// <summary>
        /// Returns the width of the layer in pixels
        /// </summary>
        public int WidthInPixels
        {
            get { return Width * tileWidth; }
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

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseLayer()
        {
            // Does nothing
        }

        /// <summary>
        /// Constructor that loads a tile layer with the specified width and height
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        public BaseLayer(int width, int height)
        {
            map = new int[height, width];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    map[y, x] = cNoTile;
        }

        /// <summary>
        /// Creates a special layer with the specified width and height along with a texture for a grid,
        /// atmosphere, or background
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        /// <param name="tileTexture">Special texture used for a grid, atmosphere, or background</param>
        public BaseLayer(int width, int height, Texture2D tileTexture)
            : this(width, height)
        {
            texture = tileTexture;
        }

        /// <summary>
        /// Creates a layer with the specified width and height along with a sprite sheet
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        /// <param name="tileSheet">Sprite sheet containing the tile set used</param>
        public BaseLayer(int width, int height, SpriteSheet tileSheet)
            :this(width, height)
        {
            sheet = tileSheet;
        }

        /// <summary>
        /// Creates a layer with a specified map
        /// </summary>
        /// <param name="existingMap">Map to be copied to the layer</param>
		public BaseLayer(int[,] existingMap)
		{
			map = (int[,])existingMap.Clone();
		}

        #endregion

        #region Camera Methods

        /// <summary>
        /// This function determines which tiles are visible on the screen,
        /// given the current camera position, rotation, zoom, and tile scale
        /// </summary>
        protected void DetermineVisibility()
        {
            //create the view rectangle
            Vector2 upperLeft = Vector2.Zero;
            Vector2 upperRight = Vector2.Zero;
            Vector2 lowerLeft = Vector2.Zero;
            Vector2 lowerRight = Vector2.Zero;
            lowerRight.X = (displaySize.X / zoomValue);
            lowerRight.Y = (displaySize.Y / zoomValue);
            upperRight.X = lowerRight.X;
            upperRight.Y = 0;
            lowerLeft.X = 0;
            lowerLeft.Y = lowerRight.Y;

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
            float scaledTileWidth = (float)TileWidth * scaleValue.X;
            float scaledTileHeight = (float)TileHeight * scaleValue.Y;

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

        #endregion

        #region Layer Methods

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
        /// Sets the sprite sheet that this layer uses
        /// </summary>
        /// <param name="sheet">Sheet containing the texture for the layer to use</param>
        public void SetSpriteSheet(SpriteSheet sheet)
        {
            this.sheet = sheet;
        }

        /// <summary>
        /// Resizes the layer to the new dimensions while preserving the previous data
        /// </summary>
        /// <param name="width">New width of the layer in tiles</param>
        /// <param name="height">New height of the layer in tiles</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool ResizeLayer(int width, int height)
        {
            // Safety check
            if (width <= 0 || height <= 0)
                return false;

            // Creates a new array with the dimenions
            int[,] newMap = new int[height, width];

            // Determines the smaller grid and loops over what is necessary
            int copyRows = Math.Min(height, Height);
            int copyCols = Math.Min(width, Width);

            // Copies what it can from the previous map
            for (int r = 0; r < copyRows; r++)
            {
                for (int c = 0; c < copyCols; c++)
                {
                    newMap[r, c] = map[r, c];
                }
            }

            // Replace the old map with the new
            map = newMap;

            return true;
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Main drawing function that every class must override for their specific drawing
        /// </summary>
        /// <param name="batch">Batch to render with</param>
        public virtual void Draw(SpriteBatch batch)
        { }
        
        #endregion
    }
}
