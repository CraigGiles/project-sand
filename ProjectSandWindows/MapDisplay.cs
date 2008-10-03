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

        #endregion

        /// <summary>
        /// Initialize the graphics
        /// </summary>
        protected override void Initialize()
		{
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Force the display to update when the window is idle
            Application.Idle += delegate { Invalidate(); };
		}

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
	}
}
