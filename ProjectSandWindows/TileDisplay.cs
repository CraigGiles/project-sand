#region File Description
//-----------------------------------------------------------------------------
// TileDisplay.cs
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
    /// Main display for showing tile sheets
    /// </summary>
	public class TileDisplay : GraphicsDeviceControl
    {
        #region Fields

        SpriteBatch spriteBatch;
        SpriteSheet tileSheet;
        Camera camera;

        #endregion

        #region Properties

        /// <summary>
        /// Curernt tile sheet to display
        /// </summary>
        public SpriteSheet TileSheet
        {
            get { return tileSheet; }
            set { tileSheet = value; }
        }

        /// <summary>
        /// Camera used for viewing the tiles
        /// </summary>
        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
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
        /// Draw the tiles for selection
        /// </summary>
		protected override void Draw()
		{
            GraphicsDevice.Clear(Color.Black);

            // TODO:  Render the tiles
		}
	}
}
