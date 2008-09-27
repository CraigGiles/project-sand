#region File Description
//-----------------------------------------------------------------------------
// SandTileEngine.cs
//
// Copyright (C) David Hsu
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
#endregion

namespace SandTileEngine
{
    /// <summary>
    /// Tile editor renderer that will display
    /// </summary>
    public class TileMap
    {
        #region Constants

        // Max number of tiles
        const int cNumTiles = 200;
        // Max number of layers for a map
        const int cMaxLayers = 5;

        #endregion

        #region Fields

        // Name of the map
        string name;
        // Name of the map used in game or for information
        string mapName;

        // Tile layer information
        SpriteSheet tileSheet;
        List<TileLayer> tileLayer = new List<TileLayer>(cMaxLayers);

        // Animated sprites
        //private SpriteSheet animatedSpriteSheet;
        //private AnimatedSprite animatedSprite;
        //private Vector2 animatedSpritePosition;
        //private float accumulator;

        // Stored map information
        string mapTileFile;
        int tileWidth, tileHeight;
        int[] transparentColor = new int[3];
        int mapWidth, mapHeight;
        int[,] mapBounds;
        int[,] mapCodes;

        #endregion

        #region Properties

        /// <summary>
        /// Name of the map used for the editor
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Name of the map used in game or for information
        /// </summary>
        public string MapName
        {
            get { return mapName; }
            set { mapName = value; }
        }

        /// <summary>
        /// Returns the 2D array of map boundaries
        /// </summary>
        public int[,] MapBounds
        {
            get { return mapBounds; }
        }

        /// <summary>
        /// Returns the 2D array of map codes
        /// </summary>
        public int[,] MapCodes
        {
            get { return mapCodes; }
        }

        /// <summary>
        /// Returns the current map height
        /// </summary>
        public int MapHeight
        {
            get { return mapHeight; }
        }

        /// <summary>
        /// Returns the current map width
        /// </summary>
        public int MapWidth
        {
            get { return mapWidth; }
        }

        /// <summary>
        /// Obtains the i-th layer of the map
        /// </summary>
        public TileLayer this[int i]
        {
            get { return tileLayer[i]; }
            set { tileLayer[i] = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default contructor
        /// </summary>
        public TileMap()
        {
            // TODO: Need to do anything?
        }

        /// <summary>
        /// Constructor that creates a map with the specified width and height in tiles
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        public TileMap(int width, int height)
        {
            // Creates all the layers for the map
            for (int i = 0; i < cMaxLayers; i++)
            {
                TileLayer layer = new TileLayer(width, height);
                tileLayer.Add(layer);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the tileset that the map will use
        /// </summary>
        /// <param name="sheet">Sheet containing the tileset</param>
        public void SetSpriteSheet(SpriteSheet sheet)
        {
            tileSheet = sheet;

            // Goes through all the layers and sets the sheet
            for (int i = 0; i < tileLayer.Count; i++)
            {
                tileLayer[i].SetSpriteSheet(sheet);
            }
        }

        /// <summary>
        /// Resizes the map to the new width and height
        /// </summary>
        /// <param name="width">New width size for the map in tiles</param>
        /// <param name="height">New height size for the map in tiles</param>
        /// <returns>True if the resize was successful, false otherwise</returns>
        public bool ResizeMap(int width, int height)
        {
            // Safety check, make sure the width and height are valid
            if (width <= 0 || height <= 0)
                return false;

            mapWidth = width;
            mapHeight = height;

            // Goes through each layer and resizes them
            for (int i = 0; i < tileLayer.Count; i++)
                tileLayer[i].ResizeLayer(width, height);

            return true;
        }

        #endregion

        #region Drawing and Rendering

        /// <summary>
        /// Renders the game scene
        /// </summary>
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (TileLayer layer in tileLayer)
            {
                layer.Draw(spriteBatch);
            }
        }

        #endregion
    }
}
