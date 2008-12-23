#region File Description
//-----------------------------------------------------------------------------
// MapDisplay.cs
//
// Copyright (C) Project Sand
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SandTileEngine;
#endregion

namespace ProjectSandWindows
{
    using Keys = Microsoft.Xna.Framework.Input.Keys;

    /// <summary>
    /// Main display for showing maps for editing
    /// </summary>
	public class MapDisplay : GraphicsDeviceControl
    {
        #region Constants

        /// <summary>
        /// Controls how fast to scroll the display when the mouse is out of the display
        /// </summary>
        const float cScrollFactor = 0.5f;

        #endregion

        #region Fields

        SpriteBatch spriteBatch;
        TileMap map;
        Camera camera = new Camera();

        // Currently selected layer
        int currentLayer = 0;

        // Scroll bars for controlling the camera view
        HScrollBar hsbMapDisplay;
        VScrollBar vsbMapDisplay;

        // Mouse positions
        Point lastMousePos = new Point();

        // Selected tiles passed in from the TileDisplay
        Rectangle tileSelection = Rectangle.Empty;
        // Width in number of tiles of the tile sheet
        int tileWidth;

        // Flag for if the user is panning the map
        bool inPanMode = false;

        #endregion

        #region Properties

        /// <summary>
        /// The map to display on this interface
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

        /// <summary>
        /// Currently selected tiles from the tile sheet
        /// </summary>
        public Rectangle TileSelection
        {
            get { return tileSelection; }
            set { tileSelection = value; }
        }

        /// <summary>
        /// Tile width of the open tile sheet
        /// </summary>
        public int TileWidth
        {
            get { return tileWidth; }
            set { tileWidth = value; }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initialize the graphics
        /// </summary>
        protected override void Initialize()
		{
            // Initialize the sprite batch
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Connect the events to the functions
            MouseLeave += new EventHandler(mapDisplay_MouseLeave);
            MouseMove += new MouseEventHandler(mapDisplay_MouseMove);
            MouseEnter += new EventHandler(mapDisplay_MouseEnter);
            MouseClick += new MouseEventHandler(display_MouseClick);

            // Force the display to update when the window is idle
            Application.Idle += delegate { Invalidate(); };
        }

        /// <summary>
        /// Initializes the scroll bars linked to this display.  Should be set when this display is created.
        /// </summary>
        /// <param name="hsb"></param>
        /// <param name="vsb"></param>
        public void SetScrollBars(HScrollBar hsb, VScrollBar vsb)
        {
            hsbMapDisplay = hsb;
            vsbMapDisplay = vsb;

            // Link the scroll bars to a function
            hsbMapDisplay.Scroll += new ScrollEventHandler(UpdateCameraScroll);
            vsbMapDisplay.Scroll += new ScrollEventHandler(UpdateCameraScroll);
            hsbMapDisplay.ValueChanged += new EventHandler(UpdateCamera);
            vsbMapDisplay.ValueChanged += new EventHandler(UpdateCamera);
        }

        #endregion

        #region Mouse Tracking

        /// <summary>
        /// Main function to handle changing tiles on the map
        /// </summary>
        void ModifyMapTile()
        {
            // Put the currently selected tile(s) into the map if in paint mode
            if (MainForm.CurrentTool == EditorTool.Paint)
            {
                // Paint selected tiles
                ProjectSession.PaintTile(currentLayer, tileSelection, tileWidth);
            }
            else if (MainForm.CurrentTool == EditorTool.Erase)
            {
                // Erase the current current tile
                ProjectSession.EraseTile(currentLayer);
            }
            else if (MainForm.CurrentTool == EditorTool.Fill)
            {
                // TODO:  Fill the area with the selected tile(s)
                // Requires developing an algorithm for this.
            }
            else if (MainForm.CurrentTool == EditorTool.PaintCollision)
            {
                // Paint the selected area with the collision/bounds
                ProjectSession.ModifyCollision(1);
            }
            else if (MainForm.CurrentTool == EditorTool.EraseCollision)
            {
                // Remove the collision/bounds on the tile
                ProjectSession.ModifyCollision(-1);
            }
        }

        void mapDisplay_MouseEnter(object sender, EventArgs e)
        {
            // TODO:  Set mouse position, or does this function need to be created since
            // move will trigger immediately after?
            ProjectSession.CurrentMap.MouseInMap = true;
        }

        void mapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the mouse position and calculate where to draw the highlighting square
            // Use the position to find the row and col of the current map
            ProjectSession.CurrentMap.SetMousePosition(e.X, e.Y, camera);

            // If the space bar is held down, pan the map depending on how the mouse is moved
            if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
                (hsbMapDisplay.Enabled || vsbMapDisplay.Enabled))
            {
                inPanMode = true;
                ProjectSession.CurrentMap.MouseInMap = false;
            }

            // Check to see if the user was dragging the mouse
            if (e.Button == MouseButtons.Left)
            {
                // If we're panning, move the map depending on how the mouse is moved
                if (inPanMode)
                {
                    int dX = e.X - lastMousePos.X;
                    int dY = e.Y - lastMousePos.Y;

                    int newH = (int)MathHelper.Clamp(hsbMapDisplay.Value + dX, 0,
                        hsbMapDisplay.Maximum - hsbMapDisplay.LargeChange + 1);
                    int newV = (int)MathHelper.Clamp(vsbMapDisplay.Value + dY, 0,
                        vsbMapDisplay.Maximum - vsbMapDisplay.LargeChange + 1);

                    hsbMapDisplay.Value = newH;
                    vsbMapDisplay.Value = newV;
                }
                else
                {
                    if ((tileSelection != Rectangle.Empty || MainForm.CurrentTool == EditorTool.PaintCollision ||
                          MainForm.CurrentTool == EditorTool.EraseCollision) &&
                        currentLayer != -1 && ProjectSession.MouseTile.X >= 0 && ProjectSession.MouseTile.Y >= 0)
                    {
                        // If within bounds, change the map
                        ModifyMapTile();
                    }
                }
            }
            else if (e.Button == MouseButtons.None && Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                // If the mouse doesn't have any buttons press, disable any modes
                inPanMode = false;
                ProjectSession.CurrentMap.MouseInMap = true;
            }

            // Store the position for later
            lastMousePos.X = e.X;
            lastMousePos.Y = e.Y;
        }

        void mapDisplay_MouseLeave(object sender, EventArgs e)
        {
            // When the moust leaves, reset the grid highlights
            // TODO:  Reset grid highlights
            ProjectSession.CurrentMap.MouseInMap = false;
        }

        void display_MouseClick(object sender, MouseEventArgs e)
        {
            // TODO:  Do something with the clicks
            if (e.Button == MouseButtons.Left && !inPanMode && currentLayer != -1)
            {
                // Modify the map
                ModifyMapTile();
            }
            else if (e.Button == MouseButtons.Right)
                Console.WriteLine("Right Click!");
        }

        #endregion

        #region Scroll Bars

        /// <summary>
        /// Adjusts the scroll bars to have the correct values to match the selected map size by subtracting the
        /// size of the display from the size of the map if the width or height is larger.
        /// </summary>
        private void AdjustScrollBars()
        {
            int maxWidth, maxHeight;

            if (map.MapWidthInPixels > Width)
            {
                maxWidth = map.MapWidthInPixels - Width;

                hsbMapDisplay.Enabled = true;
                hsbMapDisplay.Minimum = 0;
                hsbMapDisplay.Maximum = (maxWidth + hsbMapDisplay.LargeChange) - 1;
            }
            else
            {
                maxWidth = 0;
                hsbMapDisplay.Minimum = 0;
                hsbMapDisplay.Maximum = 0;
                hsbMapDisplay.Enabled = false;
            }

            if (map.MapHeightInPixels > Height)
            {
                maxHeight = map.MapHeightInPixels - Height;

                vsbMapDisplay.Enabled = true;
                vsbMapDisplay.Minimum = 0;
                vsbMapDisplay.Maximum = (maxHeight + vsbMapDisplay.LargeChange) - 1;
            }
            else
            {
                maxHeight = 0;
                vsbMapDisplay.Minimum = 0;
                vsbMapDisplay.Maximum = 0;
                vsbMapDisplay.Enabled = false;
            }
        }

        /// <summary>
        /// Used mainly for direct values changes to the scroll bars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpdateCamera(object sender, EventArgs e)
        {
            camera.position.X = hsbMapDisplay.Value;
            camera.position.Y = vsbMapDisplay.Value;

            map.CameraChange(camera);
        }

        /// <summary>
        /// Updates the camera when the scroll bar is changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpdateCameraScroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                // If the scroll bar is being dragged or stopped moving, update the position
                if (e.Type == ScrollEventType.ThumbPosition || e.Type == ScrollEventType.ThumbTrack ||
                    e.Type == ScrollEventType.EndScroll)
                    camera.position.X = e.NewValue;
            }
            else
            {
                // If the scroll bar is being dragged or stopped moving, update the position
                if (e.Type == ScrollEventType.ThumbPosition || e.Type == ScrollEventType.ThumbTrack ||
                    e.Type == ScrollEventType.EndScroll)
                    camera.position.Y = e.NewValue;
            }

            // Update the camera
            map.CameraChange(camera);

            // Force the display to update
            Invalidate();
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
