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
    /// Enum for easier reading of layer numbers
    /// </summary>
    public enum Layer : int
    {
        BaseLayer = 0,
        MiddleLayer,
        TopLayer,
        CollisionLayer,
        Atmosphere
    };

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

        // Name of the map for the editor
        string identifier;
        // Name of the map used in game or for information
        string mapName;

        // Tile layer information
        SpriteSheet tileSheet;
        List<TileLayer> tileLayer = new List<TileLayer>(cMaxLayers);
        // Special grid layer for displaying over the layers
        TileLayer gridLayer;
        // Grid texture (a white point for drawing)
        Texture2D whiteGrid;

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

        // True if we're displaying a grid
        bool showGrid = true;
        // True if the mouse is valid and inside the grid
        bool mouseInMap = false;
        // Current mouse position in tile coordinates
        Point mouseTile = new Point();

        #endregion

        #region Properties

        #region Display Properties

        /// <summary>
        /// Whether or not to show the grid over the map
        /// </summary>
        public bool ShowGrid
        {
            get { return showGrid; }
            set { showGrid = value; }
        }

        /// <summary>
        /// True if the mouse is within the map display, false otherwise
        /// </summary>
        public bool MouseInMap
        {
            get { return mouseInMap; }
            set { mouseInMap = value; }
        }

        #endregion

        #region Map Properties

        /// <summary>
        /// Name of the map used for the editor
        /// </summary>
        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
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
        /// Returns the tile set that this map is using
        /// </summary>
        public SpriteSheet TileSheet
        {
            get { return tileSheet; }
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
        /// Returns the current map height in tiles
        /// </summary>
        public int MapHeight
        {
            get { return mapHeight; }
        }

        /// <summary>
        /// Returns the current map height in pixels
        /// </summary>
        /// <remarks>For now, just get the pixels from the first layer</remarks>
        public int MapHeightInPixels
        {
            get { return tileLayer[0].HeightInPixels; }
        }

        /// <summary>
        /// Returns the current map width in tiles
        /// </summary>
        public int MapWidth
        {
            get { return mapWidth; }
        }

        /// <summary>
        /// Returns the current map width in pixels
        /// </summary>
        /// <remarks>For now, just get the pixels from the first layer</remarks>
        public int MapWidthInPixels
        {
            get { return tileLayer[0].WidthInPixels; }
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
            mapWidth = width;
            mapHeight = height;

            // Creates all the layers for the map
            for (int i = 0; i < cMaxLayers; i++)
            {
                TileLayer layer = new TileLayer(width, height);
                tileLayer.Add(layer);
            }
        }

        /// <summary>
        /// Constructor that creates a map with the specified width and height in tiles and also
        /// stores the size of the display
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        /// <param name="displaySize">Display size of the window</param>
        /// <param name="graphics">Graphics to the display for loading files</param>
        public TileMap(int width, int height, Vector2 displaySize, GraphicsDevice graphics)
            :this(width, height)
        {
            // Load the grid lines (need another way of doing this?)
            whiteGrid = Texture2D.FromFile(graphics, "Resources/whitepixel.png");

            // Add the grid layer
            gridLayer = new TileLayer(width, height, whiteGrid, true);

            SetDisplaySize(displaySize);
        }

        #endregion

        #region Camera Functions

        /// <summary>
        /// Whenever the camera is changed, update the layers with the new information
        /// </summary>
        /// <param name="camera">Current camera data</param>
        public void CameraChange(Camera camera)
        {
            for (int i = 0; i < tileLayer.Count; i++)
            {
                tileLayer[i].CameraPosition = camera.position;
                tileLayer[i].CameraZoom = camera.Zoom;
            }
            gridLayer.CameraPosition = camera.position;
            gridLayer.CameraZoom = camera.Zoom;
        }

        /// <summary>
        /// Stores the display size of the map window for rendering
        /// </summary>
        /// <param name="displaySize">Size of the map window</param>
        public void SetDisplaySize(Vector2 displaySize)
        {
            for (int i = 0; i < tileLayer.Count; i++)
            {
                tileLayer[i].DisplaySize = displaySize;
            }
            gridLayer.DisplaySize = displaySize;
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

            // If the width and height are different than current, resize the map
            if (mapWidth != width || mapHeight != height)
            {
                mapWidth = width;
                mapHeight = height;

                // Goes through each layer and resizes them
                for (int i = 0; i < tileLayer.Count; i++)
                    tileLayer[i].ResizeLayer(width, height);
            }

            return true;
        }

        /// <summary>
        /// Sets where the mouse is currently hovering over
        /// </summary>
        /// <param name="x">X coordinate with respect to the top-left corner</param>
        /// <param name="y">Y coordinate with respect to the top-left corner</param>
        public void SetMousePosition(int x, int y, Camera camera)
        {
            // Calculate the tile the cursor is on
            mouseTile.X = (int)((x + camera.position.X) / TileLayer.TileWidth);
            mouseTile.Y = (int)((y + camera.position.Y) / TileLayer.TileHeight);
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

            // If the grid is on, overlay the layers with a grid
            if (showGrid)
            {
                gridLayer.Draw(spriteBatch);
            }

            // If the mouse is valid, highlight the tile it's over
            if (mouseInMap)
            {
                // TODO:  Highlight tile
                gridLayer.DrawHighlight(spriteBatch, mouseTile.Y, mouseTile.X);
            }
        }

        #endregion
    }
}
