#region File Description
//-----------------------------------------------------------------------------
// ProjectSession.cs
//
// Copyright (C) Project Sand
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
#endregion

namespace SandTileEngine
{
    /// <summary>
    /// Keeps track of the current project session by storing the maps, tile sheets, and other information
    /// in a centralized place.  Acts as a semi-controller class by relaying commands to the actual collections
    /// between the UI and base classes.
    /// </summary>
    public class ProjectSession
    {
        #region Fields

        // Basic map and tile information
        TileMapCollection mapData;
        SpriteSheetCollection sheetData;

        // Curernt map being edited
        TileMap currentMap;
        // Current tile sheet being used
        SpriteSheet currentSheet;

        // Tile sheet filename
        string tileFilename;
        // Filename with the full path information
        string tileFullFilename;

        // Currently opened project file, if any
        string currentProjectFile = "";
        // Project name
        string projectName;

        #endregion

        #region Singleton

        /// <summary>
        /// The single Session instance that can be active at a time.
        /// </summary>
        private static ProjectSession singleton;

        /// <summary>
        /// Simple function to see if the session is valid
        /// </summary>
        /// <returns>True if the session is valid, false otherwise</returns>
        private static bool SessionValid()
        {
            return (singleton != null);
        }

        #endregion

        #region Properties

        #region Private Helpers

        /// <summary>
        /// Helper property to access the map collection data
        /// </summary>
        private static TileMapCollection MapData
        {
            get
            {
                if (SessionValid())
                    return singleton.mapData;
                else
                    return null;
            }
        }

        /// <summary>
        /// Helper property to access the sheet collection data
        /// </summary>
        private static SpriteSheetCollection SheetData
        {
            get
            {
                if (SessionValid())
                    return singleton.sheetData;
                else
                    return null;
            }
        }

        #endregion

        #region Public Accessors

        /// <summary>
        /// Obtain the current map being edited
        /// </summary>
        public static TileMap CurrentMap
        {
            get
            {
                if (SessionValid())
                    return singleton.currentMap;
                else
                    return null;
            }
        }

        /// <summary>
        /// Obtain the current tile sheet being used 
        /// </summary>
        public static SpriteSheet CurrentTileSheet
        {
            get
            {
                if (SessionValid())
                    return singleton.currentSheet;
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns the number of maps currently in the project session
        /// </summary>
        public static int MapCount
        {
            get
            {
                if (SessionValid())
                    return MapData.Count;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Returns the number of sprite sheets currently in the project session
        /// </summary>
        public static int TileCount
        {
            get
            {
                if (SessionValid())
                    return SheetData.Count;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Returns the MouseTile information from the current map
        /// </summary>
        public static Point MouseTile
        {
            get
            {
                if (SessionValid())
                    return CurrentMap.MouseTile;
                else
                    return Point.Zero;
            }
        }

        /// <summary>
        /// Returns the current map's width in tiles
        /// </summary>
        public static int MapWidth
        {
            get
            {
                if (SessionValid())
                    return CurrentMap.MapWidth;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Returns the current map's height in tiles
        /// </summary>
        public static int MapHeight
        {
            get
            {
                if (SessionValid())
                    return CurrentMap.MapHeight;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Current project file name
        /// </summary>
        public static string CurrentProjectFile
        {
            get
            {
                if (SessionValid())
                    return singleton.currentProjectFile;
                else
                    return string.Empty;
            }
            set
            {
                if (SessionValid())
                    singleton.currentProjectFile = value;
            }
        }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Private constructor that creates the blank collections
        /// </summary>
        /// <param name="mapCollection">Map data to initialize with</param>
        /// <param name="sheetCollection">Sheet data to initialize with</param>
        ProjectSession(TileMapCollection mapCollection, SpriteSheetCollection sheetCollection)
        {
            if (mapCollection == null)
                mapData = new TileMapCollection();
            else
                mapData = mapCollection;

            if (sheetCollection == null)
                sheetData = new SpriteSheetCollection();
            else
                sheetData = sheetCollection;
        }

        #endregion

        #region Session Actions

        /// <summary>
        /// Creates a new blank session
        /// </summary>
        public static void NewSession()
        {
            // Load a session with null parameters
            LoadSession(null, null);
        }

        /// <summary>
        /// Loads a new session with the provided map and tile information
        /// </summary>
        /// <param name="mapCollection">Collection of the maps to load</param>
        /// <param name="sheetCollection">Collection of tile sheets to load</param>
        public static void LoadSession(TileMapCollection mapCollection, 
            SpriteSheetCollection sheetCollection)
        {
            // Clear any previous session
            CloseSession();

            // Create a new session
            singleton = new ProjectSession(mapCollection, sheetCollection);
        }

        /// <summary>
        /// Closes the current session and clears the project
        /// </summary>
        public static void CloseSession()
        {
            // Erases any previous stored data
            singleton = null;
        }

        #endregion

        #region Map Methods

        /// <summary>
        /// Checks to make sure the selected index is within the bounds
        /// </summary>
        /// <param name="index">Index of the map from the map collection</param>
        /// <returns>True if bounds are good, false otherwise</returns>
        private static bool CheckBounds(int index)
        {
            // Check to make sure the session is valid and within bounds
            return (SessionValid() && (index >= 0 && index < MapData.Count));
        }

        /// <summary>
        /// Sets the current map to the selected index
        /// </summary>
        /// <param name="index">Index of the map</param>
        public static void SelectMap(int index)
        {
            if (CheckBounds(index))
                singleton.currentMap = MapData[index];
        }

        /// <summary>
        /// Returns the specified map from the collection
        /// </summary>
        /// <param name="index">Index to the map</param>
        /// <returns>TileMap of the selected index</returns>
        public static TileMap GetMap(int index)
        {
            if (CheckBounds(index))
                return MapData[index];
            else
                return null;
        }

        /// <summary>
        /// Adds a map to the project collection
        /// </summary>
        /// <param name="map">Map to be added</param>
        public static void AddMap(TileMap map)
        {
            MapData.AddMap(map);

            // If there's a tile sheet loaded already, set the map to use it
            if (CurrentTileSheet != null)
                map.SetSpriteSheet(CurrentTileSheet);

            // Set the current map to the newly created map
            singleton.currentMap = map;
        }

        /// <summary>
        /// Removes the map with the specified name
        /// </summary>
        /// <param name="name">Name of the map to remove</param>
        public static void RemoveMap(string name)
        {
            MapData.RemoveMap(name);
        }

        /// <summary>
        /// Returns the index position of the specified map
        /// </summary>
        /// <param name="name">Name of the map to find</param>
        /// <returns>Index of the map name</returns>
        public static int FindMapIndex(string name)
        {
            return MapData.FindIndex(name);
        }

        /// <summary>
        /// Updates the camera view on the current map
        /// </summary>
        /// <param name="camera">Camera with the updated information</param>
        public static void UpdateMapCamera(Camera camera)
        {
            CurrentMap.CameraChange(camera);
        }

        /// <summary>
        /// Toggles whether or not to show the grid for the maps
        /// </summary>
        /// <param name="flag">True/false flag for showing the grid</param>
        public static void ToggleGrid(bool flag)
        {
            for (int i = 0; i < MapCount; i++)
                MapData[i].ShowGrid = flag;
        }

        /// <summary>
        /// Toggles whether or not to show the collision layer for the current map
        /// </summary>
        /// <param name="flag">True/false for showing the collision layer</param>
        public static void ToggleCollisionView(bool flag)
        {
            CurrentMap.ShowCollision = flag;
        }

        /// <summary>
        /// Puts the selected tiles into the map
        /// </summary>
        /// <param name="layerIndex">Layer to paint on the map</param>
        /// <param name="tiles">Rectangle area of tiles to paint on</param>
        /// <param name="width">Width of the sprite sheet in tiles</param>
        public static void PaintTile(int layerIndex, Rectangle tiles, int width)
        {
            // Loop through all the tiles
            for (int r = CurrentMap.MouseTile.Y, i = 0;
                r < CurrentMap.MapHeight && i < tiles.Height; r++, i++)
            {
                for (int c = CurrentMap.MouseTile.X, j = 0;
                    c < CurrentMap.MapWidth && j < tiles.Width; c++, j++)
                {
                    // Place the tile in the correct layer(s)
                    int index = (tiles.Y + i) * width + (tiles.X + j);
                    CurrentMap[layerIndex].SetTile(r, c, index);
                }
            }
        }

        /// <summary>
        /// Erases the current mouse position on the map of the specified layer
        /// </summary>
        /// <param name="layerIndex">Layer to erase the tile from</param>
        public static void EraseTile(int layerIndex)
        {
            CurrentMap[2 - layerIndex].SetTile(CurrentMap.MouseTile.Y, CurrentMap.MouseTile.X, -1);
        }

        /// <summary>
        /// Modifies the collision value of the currently selected tile
        /// </summary>
        /// <param name="bound">-1 for no collision, 1-15 if there is</param>
        public static void ModifyCollision(int bound)
        {
            CurrentMap.ModifyCollision(bound);
        }

        /// <summary>
        /// Does a bucket fill starting from the selected starting point and covers all tiles nearby that are
        /// the same as the starting point.  For multiple tiles, tile the textures.
        /// </summary>
        public static void FillMapTile()
        {
            // TODO:  Algorithm
        }

        #endregion

        #region Tile Methods

        /// <summary>
        /// Adds a tile to the project collection
        /// </summary>
        /// <param name="sheet">SpriteSheet ot be added</param>
        public static void AddSpriteSheet(SpriteSheet sheet)
        {
            SheetData.AddSpriteSheet(sheet);
        }

        /// <summary>
        /// Sets all the maps in the collection to the specified sprite sheet
        /// </summary>
        /// <param name="sheet">Sprite sheet for all the maps</param>
        public static void SetSpriteSheet(SpriteSheet sheet)
        {
            for (int i = 0; i < MapCount; i++)
            {
                MapData[i].SetSpriteSheet(sheet);
            }
        }

        #endregion
    }
}
