#region File Description
//-----------------------------------------------------------------------------
// TileDisplay.cs
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
using SandTileEngine;
#endregion

namespace ProjectSandWindows
{
    using Image = System.Drawing.Image;
    using Bitmap = System.Drawing.Bitmap;

    /// <summary>
    /// Main display for showing tile sheets
    /// </summary>
	public class TileDisplay : GraphicsDeviceControl
    {
        #region Constants

        /// <summary>
        /// Controls how fast to scroll the display when the mouse is out of the display
        /// </summary>
        const float cScrollFactor = 0.5f;

        #endregion

        #region Fields

        // Display fields
        SpriteBatch spriteBatch;
        SpriteSheetLayer sheetLayer;
        GridLayer gridLayer;
        Camera camera = new Camera();

        // Image file for displaying in the properties window
        Bitmap spriteImage;

        // Grid texture (a white point for drawing)
        Texture2D whiteGrid;

        // Scroll bars for controlling the camera view
        HScrollBar hsbTileDisplay;
        VScrollBar vsbTileDisplay;

        // Selection fields
        bool isSelected = false;
        Point lastMousePos = new Point();
        Point currentTilePos = new Point();
        // Note that the rectangle has X = col, Y = row, width/height = tiles instead of pixel positions
        Rectangle tileSelection = Rectangle.Empty;
        Point beginSelection = new Point(-1, -1);
        Point endSelection = new Point();

        // True if the grid is showing
        bool showGrid = true;
        // True if the mouse is in the tile display
        bool mouseInDisplay = false;
        // True if the mouse is currently selecting the tiles
        bool inSelection = false;

        // Scroll bar variables
        int maxWidth, maxHeight;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the sprite sheet this display is using
        /// </summary>
        public SpriteSheet Sheet
        {
            get 
            {
                if (sheetLayer != null)
                    return sheetLayer.Sheet;
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns the texture used for displaying a grid
        /// </summary>
        public Texture2D GridTexture
        {
            get { return whiteGrid; }
        }

        /// <summary>
        /// Windows image used to display the tile set in a window box
        /// </summary>
        public Bitmap SpriteImage
        {
            get { return spriteImage; }
            set { spriteImage = value; }
        }

        /// <summary>
        /// Returns the currently selected tiles
        /// </summary>
        public Rectangle TileSelection
        {
            get { return tileSelection; }
        }

        /// <summary>
        /// Returns the width in tiles of the sheet layer
        /// </summary>
        public int SheetWidth
        {
            get
            {
                if (sheetLayer != null)
                    return sheetLayer.Width;
                else
                    return -1;
            }
        }

        /// <summary>
        /// Returns the height in tiles of the sheet layer
        /// </summary>
        public int SheetHeight
        {
            get 
            {
                if (sheetLayer != null)
                    return sheetLayer.Height;
                else
                    return -1;
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
            whiteGrid = Texture2D.FromFile(GraphicsDevice, "Resources/whitepixel.png");

            // Force the display to update when the window is idle
            Application.Idle += delegate { Invalidate(); };

            // Callbacks for mouse over events
            MouseEnter += new EventHandler(tileDisplay_MouseEnter);
            MouseMove += new MouseEventHandler(tileDisplay_MouseMove);
            MouseLeave += new EventHandler(tileDisplay_MouseLeave);
            MouseClick += new MouseEventHandler(tileDisplay_MouseClick);
        }

        /// <summary>
        /// Initializes the scroll bars linked to this display.  Should be set when this display is created.
        /// </summary>
        /// <param name="hsb"></param>
        /// <param name="vsb"></param>
        public void SetScrollBars(HScrollBar hsb, VScrollBar vsb)
        {
            hsbTileDisplay = hsb;
            vsbTileDisplay = vsb;

            // Link the scroll bars to a function
            hsbTileDisplay.Scroll += new ScrollEventHandler(UpdateCameraScroll);
            vsbTileDisplay.Scroll += new ScrollEventHandler(UpdateCameraScroll);
            hsbTileDisplay.ValueChanged += new EventHandler(UpdateCamera);
            vsbTileDisplay.ValueChanged += new EventHandler(UpdateCamera);
        }

        #endregion

        #region Mouse Tracking

        /// <summary>
        /// Sets where the mouse is currently hovering over
        /// </summary>
        /// <param name="x">X coordinate with respect to the top-left corner</param>
        /// <param name="y">Y coordinate with respect to the top-left corner</param>
        public void SetMousePosition(int x, int y)
        {
            // Calculate the tile the cursor is on
            currentTilePos.X = (int)((x + camera.position.X) / TileLayer.TileWidth);
            currentTilePos.Y = (int)((y + camera.position.Y) / TileLayer.TileHeight);
        }

        /// <summary>
        /// Calculate how to draw the selection rectangle
        /// </summary>
        public void CalculateSelection()
        {
            int width, height;
            int x, y;

            // Calculate the position and size of the selection
            x = (int)Math.Min(beginSelection.X, endSelection.X);
            y = (int)Math.Min(beginSelection.Y, endSelection.Y);
            width = (int)Math.Abs(beginSelection.X - endSelection.X) + 1;
            height = (int)Math.Abs(beginSelection.Y - endSelection.Y) + 1;

            tileSelection = new Rectangle(x, y, width, height);
        }

        void tileDisplay_MouseEnter(object sender, EventArgs e)
        {
            mouseInDisplay = true;
        }

        void tileDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the mouse position and calculate where to draw the highlighting square
            SetMousePosition(e.X, e.Y);

            // Check to see if the user was dragging the mouse
            int dX = 0, dY = 0;
            if (e.Button == MouseButtons.Left)
            {
                // If this is the first time here, we're just beginning to select the tiles,
                // so set this as the beginning point
                if (!inSelection)
                {
                    inSelection = true;
                    beginSelection = currentTilePos;
                }
                else
                {
                    endSelection = currentTilePos;
                    CalculateSelection();
                }

                // If the current mouse position is outside of the display, scroll
                // the tile display to keep up with it
                if (e.X > Width)
                    dX = (int)((e.X - Width) * cScrollFactor);
                if (e.X < 0)
                    dX = (int)(e.X * cScrollFactor);
                if (e.Y > Height)
                    dY = (int)((e.Y - Height) * cScrollFactor);
                if (e.Y < 0)
                    dY = (int)(e.Y * cScrollFactor);

                int newH = (int)MathHelper.Clamp(hsbTileDisplay.Value + dX, 0,
                    hsbTileDisplay.Maximum - hsbTileDisplay.LargeChange + 1);
                int newV = (int)MathHelper.Clamp(vsbTileDisplay.Value + dY, 0,
                    vsbTileDisplay.Maximum - vsbTileDisplay.LargeChange + 1);

                // If the scroll bars are disabled, don't do anything
                if (hsbTileDisplay.Enabled)
                    hsbTileDisplay.Value = newH;
                if (vsbTileDisplay.Enabled)
                    vsbTileDisplay.Value = newV;
            }
            else if (e.Button == MouseButtons.None)
            {
                // If the mouse doesn't have any buttons press, reset selection
                inSelection = false;
                mouseInDisplay = true;
            }

            // Store the position for later
            lastMousePos.X = e.X;
            lastMousePos.Y = e.Y;
        }

        void tileDisplay_MouseLeave(object sender, EventArgs e)
        {
            // When the moust leaves, reset the grid highlights
            mouseInDisplay = false;
        }

        void tileDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            // TODO:  Do something with the clicks
            if (e.Button == MouseButtons.Left)
            {
                // Get the tile position
                SetMousePosition(e.X, e.Y);

                // Set the end selection
                endSelection = currentTilePos;

                // If there is no beginning selection, then we just selected one square
                if (beginSelection.X == -1 || beginSelection.Y == -1)
                    beginSelection = endSelection;

                CalculateSelection();

                // Reset the beginning selection
                beginSelection = new Point(-1, -1);
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Clear any selections
                inSelection = false;
                beginSelection = new Point(-1, -1);
                tileSelection = Rectangle.Empty;
            }
        }

        #endregion

        #region Camera Functions

        /// <summary>
        /// Whenever the camera is changed, update the layers with the new information
        /// </summary>
        /// <param name="camera">Current camera data</param>
        public void CameraChange(Camera camera)
        {
            sheetLayer.CameraPosition = camera.position;
            sheetLayer.CameraZoom = camera.Zoom;
            gridLayer.CameraPosition = camera.position;
            gridLayer.CameraZoom = camera.Zoom;
        }

        #endregion

        #region Loading Sheets

        /// <summary>
        /// Loads the tile sheet to be displayed
        /// </summary>
        /// <param name="tileWidth">Tile width in pixels</param>
        /// <param name="tileHeight">Tile height in pixels</param>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        /// <param name="sheet">Loaded sprite sheet</param>
        public void LoadTileSheet(int tileWidth, int tileHeight, int width, int height, SpriteSheet sheet)
        {
            // If we already loaded one, resize the layers
            // TODO:  If we want to be able to load multiple tilesets, need a list to contain them
            if (sheetLayer == null)
            {
                sheetLayer = new SpriteSheetLayer(width, height, sheet);
                sheetLayer.DisplaySize = new Vector2(Width, Height);
            }
            else
                sheetLayer.ChangeSpriteSheet(width, height, sheet);

            // Create a new grid layer if not already created
            if (gridLayer == null)
            {
                gridLayer = new GridLayer(width, height, whiteGrid);
                gridLayer.DisplaySize = new Vector2(Width, Height);
            }
            else
                gridLayer.ResizeLayer(width, height);

            // Store the tile sizes
            SpriteSheetLayer.TileWidth = tileWidth;
            SpriteSheetLayer.TileHeight = tileHeight;

            // Reset any selections made
            tileSelection = Rectangle.Empty;

            // Resize the scroll bars
            AdjustScrollBars();

            // Reset the scroll bar values
            hsbTileDisplay.Value = vsbTileDisplay.Value = 0;

            // Reset the camera
            camera.position = Vector2.Zero;

        }

        #endregion

        #region Scroll Bars

        /// <summary>
        /// Adjusts the scroll bars to have the correct values to match the selected map size by subtracting the
        /// size of the display from the size of the map if the width or height is larger.
        /// </summary>
        private void AdjustScrollBars()
        {
            if (sheetLayer.WidthInPixels > Width)
            {
                maxWidth = (int)Math.Max(sheetLayer.WidthInPixels - Width, maxWidth);

                hsbTileDisplay.Enabled = true;
                hsbTileDisplay.Minimum = 0;
                hsbTileDisplay.Maximum = (maxWidth + hsbTileDisplay.LargeChange) - 1;
            }
            else
            {
                maxWidth = 0;
                hsbTileDisplay.Minimum = 0;
                hsbTileDisplay.Maximum = 0;
                hsbTileDisplay.Enabled = false;
            }

            if (sheetLayer.HeightInPixels > Height)
            {
                maxHeight = (int)Math.Max(sheetLayer.HeightInPixels - Height, maxHeight);

                vsbTileDisplay.Enabled = true;
                vsbTileDisplay.Minimum = 0;
                vsbTileDisplay.Maximum = (maxHeight + vsbTileDisplay.LargeChange) - 1;
            }
            else
            {
                maxHeight = 0;
                vsbTileDisplay.Minimum = 0;
                vsbTileDisplay.Maximum = 0;
                vsbTileDisplay.Enabled = false;
            }
        }

        /// <summary>
        /// Used mainly for direct values changes to the scroll bars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpdateCamera(object sender, EventArgs e)
        {
            camera.position.X = hsbTileDisplay.Value;
            camera.position.Y = vsbTileDisplay.Value;
            
            sheetLayer.CameraPosition = gridLayer.CameraPosition = camera.position;
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
            sheetLayer.CameraPosition = gridLayer.CameraPosition = camera.position;

            // Force the display to update
            Invalidate();
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Draw the tiles for selection
        /// </summary>
		protected override void Draw()
		{
            GraphicsDevice.Clear(Color.Black);

            // Render the tiles
            if (sheetLayer != null)
                sheetLayer.Draw(spriteBatch);

            // Render the grid and selection
            if (gridLayer != null)
            {
                if (showGrid)
                    gridLayer.Draw(spriteBatch);

                if (tileSelection != Rectangle.Empty)
                    gridLayer.DrawHighlight(spriteBatch, tileSelection);

                if (mouseInDisplay && !inSelection)
                    gridLayer.DrawHighlight(spriteBatch, currentTilePos.Y, currentTilePos.X);
            }

        }

        #endregion
    }
}
