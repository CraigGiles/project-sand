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

        // Default values for loading tiles
        const int cDefaultTileHeight = 40;
        const int cDefaultTileWidth = 40;
        const int cTileOffset = 1;

        #endregion

        #region Fields

        // Name of the map
        string name;
        // Name of the map used in game or for information
        string mapName;

        // Tile information
        SpriteSheet tileSheet;
        List<TileLayer> tileLayer = new List<TileLayer>();

        // Alpha of each layer
        List<int> tileLayerAlpha;

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
        public byte this[int i]
        {
            get { return tileLayer[i]; }
            set { tileLayer[i] = value; }
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
                layer.Draw(spriteBatch, camera);
            }
        }

        #endregion
    }
}
