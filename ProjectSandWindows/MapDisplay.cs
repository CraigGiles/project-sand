#region File Description
//-----------------------------------------------------------------------------
// MapDisplay.cs
//
// Copyright (C) Project Sand
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SandTileEngine;
#endregion

namespace ProjectSandWindows
{
    /// <summary>
    /// Main display for showing maps for editing
    /// </summary>
	public class MapDisplay : GraphicsDeviceControl
    {
        #region Fields

        SpriteBatch spriteBatch;
        TileMap map;

        // Currently selected layer
        int currentLayer = 0;

        #endregion

        #region Properties

        /// <summary>
        /// The current map to display on this interface
        /// </summary>
        public TileMap Map
        {
            get { return map; }
            set { map = value; }
        }

        /// <summary>
        /// Currently selected layer on the map
        /// </summary>
        public int CurrentLayer
        {
            get { return currentLayer; }
            set 
            { 
                currentLayer = value;
                ChangeLayer();
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initialize the graphics
        /// </summary>
        protected override void Initialize()
		{
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Force the display to update when the window is idle
            Application.Idle += delegate { Invalidate(); };
        }

        #endregion

        #region Layers

        /// <summary>
        /// Modifies the opacity of the layers based on the currently selected layer
        /// </summary>
        void ChangeLayer()
        {
            // If there's no layer selected (index will be -1), just show everything
            if (currentLayer == -1)
                map.SetAlpha(1f);
            else
            {
                // Sets all layers to half opacity
                map.SetAlpha(0.5f);

                // Set the current layer to full opacity
                map[currentLayer].Alpha = 1f;
            }
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Draw the maps
        /// </summary>
        protected override void Draw()
		{
            GraphicsDevice.Clear(Color.Black);

            // Draw the map
            if (map != null)
                map.Draw(spriteBatch);
        }

        #endregion
    }
}
