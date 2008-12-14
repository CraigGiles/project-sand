#region File Description
//-----------------------------------------------------------------------------
// MainForm.cs
//
// Copyright (C) Project Sand
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SandTileEngine;
#endregion

namespace ProjectSandWindows
{
    using Image = System.Drawing.Image;
    using Bitmap = System.Drawing.Bitmap;
    using Keys = Microsoft.Xna.Framework.Input.Keys;

    public enum EditorTool : int
    {
        Paint = 0,
        Erase,
        Fill,
        PaintCollision,
        EraseCollision
    }

    public partial class MainForm : Form
    {
        #region Constants

        /// <summary>
        /// Width of the scroll bar
        /// </summary>
        const int cScrollbarWidth = 18;

        /// <summary>
        /// Large change for scroll bars
        /// </summary>
        const int cLargeScrollChange = 25;

        #endregion

        #region Fields

        // Tile properties window
        frmTileProperties tileProperties = new frmTileProperties();
        // Map properties window
        frmMapProperties mapProperties = new frmMapProperties();

        // Basic data for the editor
        TileMapCollection tileMapData = new TileMapCollection();
        SpriteSheetCollection spriteSheetData = new SpriteSheetCollection();
        // Current map being edited
        TileMap currentMap;
        Camera mapCamera = new Camera();
        Camera tileCamera = new Camera();

        // Current opened file
        string currentProjectFile = "";

        // Last mouse position
        Point lastMousePos;
        // True if we're in pan mode on the map
        bool inPanMode = false;

        /// <summary>
        /// Get the graphics device for this application
        /// </summary>
        public GraphicsDevice GraphicsDevice
        {
            get { return tDisplay.GraphicsDevice; }
        }

        #endregion

        #region Editor Tools

        // Current tool selected
        EditorTool currentTool = EditorTool.Paint;

        /// <summary>
        /// Returns the current selected tool
        /// </summary>
        public EditorTool CurrentTool
        {
            get { return currentTool; }
        }

        #endregion

        #region Tab Items

        // Map display for the tabs
        List<MapDisplay> mapDisplay = new List<MapDisplay>();
        // Tile display
        List<TileDisplay> tileDisplay = new List<TileDisplay>();
        // Scroll bars for the map
        List<HScrollBar> hsbMapDisplay = new List<HScrollBar>();
        List<VScrollBar> vsbMapDisplay = new List<VScrollBar>();

        // Current selected tab index
        int currentTabIndex = 0;

        // Sizes for the map scroll bars
        //int maxWidth = 0, maxHeight = 0;

        #endregion

        #region Initialization

        public MainForm()
        {
            InitializeComponent();

            // Set up events for changing tabs
            mapTabControl.SelectedIndexChanged += new EventHandler(mapTabControl_SelectedIndexChanged);

            // Clear the status at the bottom
            mapSizeStatusLabel.Text = "";
            mapLocationStatusLabel.Text = "";

            // Set the default selected layer (base layer)
            lstLayers.SelectedIndex = 2;

            // Initialize the Tile Display
            tDisplay.SetScrollBars(hsbTileDisplay, vsbTileDisplay);
            tDisplay.Camera = tileCamera;

            ExporterSettings.Initialize();
            SaveSettings.Initialize();

            // Whenever idle, update the displays and screen
            Application.Idle += delegate { UpdateScreen(); };
        }

        /// <summary>
        /// Updates the window with the latest information pulled from the different modules and
        /// forces a redraw to keep the screen fresh.
        /// </summary>
        private void UpdateScreen()
        {
            if (currentMap != null)
            {
                // Update the status bar at the bottom
                if (currentMap.MouseInMap)
                {
                    mapLocationStatusLabel.Text = "(" + currentMap.MouseTile.X + ", " +
                        currentMap.MouseTile.Y + ")";
                }
                else
                    mapLocationStatusLabel.Text = "Invalid";
            }

            // Force the window to redraw
            Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Display Handling

        #region Map/Tile Display

        /// <summary>
        /// Main function to handle changing tiles on the map
        /// </summary>
        void ModifyMapTile()
        {
            // Put the currently selected tile(s) into the map if in paint mode
            if (currentTool == EditorTool.Paint)
            {
                Rectangle tiles = tDisplay.TileSelection;

                // Loop through all the tiles
                for (int r = currentMap.MouseTile.Y, i = 0;
                    r < currentMap.MapHeight && i < tiles.Height; r++, i++)
                {
                    for (int c = currentMap.MouseTile.X, j = 0;
                        c < currentMap.MapWidth && j < tiles.Width; c++, j++)
                    {
                        // Place the tile in the correct layer(s)
                        int index = (tiles.Y + i) * tDisplay.SheetWidth + (tiles.X + j);
                        currentMap[2 - lstLayers.SelectedIndex].SetTile(r, c, index);
                    }
                }
            }
            else if (currentTool == EditorTool.Erase)
            {
                // Erase the current current tile
                currentMap[2 - lstLayers.SelectedIndex].SetTile(currentMap.MouseTile.Y, currentMap.MouseTile.X, -1);
            }
            else if (currentTool == EditorTool.Fill)
            {
                // TODO:  Fill the area with the selected tile(s)
                // Requires developing an algorithm for this.
            }
            else if (currentTool == EditorTool.PaintCollision)
            {
                // Paint the selected area with the collision/bounds
                currentMap.ModifyCollision(1);
            }
            else if (currentTool == EditorTool.EraseCollision)
            {
                // Remove the collision/bounds on the tile
                currentMap.ModifyCollision(-1);
            }
        }

        /// <summary>
        /// Does a bucket fill starting from the selected starting point and covers all tiles nearby that are
        /// the same as the starting point.  For multiple tiles, tile the textures.
        /// </summary>
        void FillMapTile()
        {
            // TODO:  Algorithm
        }

        void mapDisplay_MouseEnter(object sender, EventArgs e)
        {
            // TODO:  Set mouse position, or does this function need to be created since
            // move will trigger immediately after?
            currentMap.MouseInMap = true;
        }

        void mapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the mouse position and calculate where to draw the highlighting square
            // Use the position to find the row and col of the current map
            currentMap.SetMousePosition(e.X, e.Y, mapCamera);
            
            // If the space bar is held down, pan the map depending on how the mouse is moved
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && 
                (hsbMapDisplay[currentTabIndex].Enabled || vsbMapDisplay[currentTabIndex].Enabled))
            {
                inPanMode = true;
                currentMap.MouseInMap = false;
            }

            // Check to see if the user was dragging the mouse
            if (e.Button == MouseButtons.Left)
            {
                // If we're panning, move the map depending on how the mouse is moved
                if (inPanMode)
                {
                    int dX = e.X - lastMousePos.X;
                    int dY = e.Y - lastMousePos.Y;

                    int newH = (int)MathHelper.Clamp(hsbMapDisplay[currentTabIndex].Value + dX, 0,
                        hsbMapDisplay[currentTabIndex].Maximum - hsbMapDisplay[currentTabIndex].LargeChange + 1);
                    int newV = (int)MathHelper.Clamp(vsbMapDisplay[currentTabIndex].Value + dY, 0,
                        vsbMapDisplay[currentTabIndex].Maximum - vsbMapDisplay[currentTabIndex].LargeChange + 1);

                    hsbMapDisplay[currentTabIndex].Value = newH;
                    vsbMapDisplay[currentTabIndex].Value = newV;
                }
                else
                {
                    if ( (tDisplay.TileSelection != Rectangle.Empty || currentTool == EditorTool.PaintCollision ||
                          currentTool == EditorTool.EraseCollision) && 
                        lstLayers.SelectedIndex != -1 && currentMap.MouseTile.X >= 0 && currentMap.MouseTile.Y >= 0)
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
                currentMap.MouseInMap = true;
            }

            // Store the position for later
            lastMousePos.X = e.X;
            lastMousePos.Y = e.Y;
        }

        void mapDisplay_MouseLeave(object sender, EventArgs e)
        {
            // When the moust leaves, reset the grid highlights
            // TODO:  Reset grid highlights
            currentMap.MouseInMap = false;
        }

        void display_MouseClick(object sender, MouseEventArgs e)
        {
            // TODO:  Do something with the clicks
            if (e.Button == MouseButtons.Left && !inPanMode && lstLayers.SelectedIndex != -1)
            {
                // Modify the map
                ModifyMapTile();
            }
            else if (e.Button == MouseButtons.Right)
                Console.WriteLine("Right Click!");            
        }

        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle whether to show the grid on any map
            for (int i = 0; i < tileMapData.Count; i++)
                tileMapData[i].ShowGrid = showGridToolStripMenuItem.Checked;
        }

        private void showCollisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle whether or not to show the collision layer
            UpdateMapDisplay();
        }

        #endregion

        #endregion

        #region New Project

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Close down the current project and start a blank project
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            // Call the menu item for new project
            newProjectToolStripMenuItem_Click(sender, e);
        }

        #endregion

        #region Opening File

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Sand Tile Editor file (*.ste)|*.ste";
            //openFileDialog1.InitialDirectory = contentPathTextBox.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                // TODO:  Do something with the file
                SaveSettings.Settings.DeSerializeSaveSettings(filename, tileMapData);

            }
        }

        private void openProjectButton_Click(object sender, EventArgs e)
        {
            // Call the menu item command as it does the same thing
            openProjectToolStripMenuItem_Click(sender, e);
        }

        #endregion

        #region Saving File

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If the project is a new file that hasn't been saved yet, load the 
            // save as dialog instead of saving
            if (currentProjectFile == String.Empty)
                saveAsToolStripMenuItem_Click(sender, e);
            else
            {

                // TODO:  Save the file data to the current file
                SaveSettings.Settings.SerializeSaveSettings(currentProjectFile, tileMapData);

                
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Calls the menu item save file
            saveToolStripMenuItem_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Current project file is the default name
            saveFileDialog1.FileName = currentProjectFile;
            saveFileDialog1.Filter = "Sand Tile Editor file (*.ste)|*.ste";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentProjectFile = saveFileDialog1.FileName;

                // TODO:  Create and save the file
                SaveSettings.Settings.SerializeSaveSettings(currentProjectFile, tileMapData);
                
            }
        }

        #endregion

        #region Importing Tile

        /// <summary>
        /// Opens a texture file selected by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.png, *.bmp, *.jpg, *.tga)|*.png; *.bmp; *.jpg; *.tga";
            //openFileDialog1.InitialDirectory = contentPathTextBox.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                Bitmap image = (Bitmap)Image.FromFile(filename);

                // Use this texture as a sprite sheet and open the tile sheet dialog
                tileProperties.TextureImage = image;

                if (tileProperties.ShowDialog() == DialogResult.OK)
                {
                    // Set the color key parameter
                    // NOTE:  This method will only make one color transparent.  Do we want multiple color support?
                    TextureCreationParameters textureParam = new TextureCreationParameters();
                    textureParam.Width = image.Width;
                    textureParam.Height = image.Height;
                    textureParam.Depth = 0;
                    textureParam.MipLevels = 0;
                    textureParam.MipFilter = FilterOptions.None;
                    textureParam.Filter = FilterOptions.None;
                    textureParam.Format = SurfaceFormat.Unknown;
                    textureParam.TextureUsage = TextureUsage.None;
                    textureParam.ColorKey = tileProperties.TransparentColor;

                    Texture2D texture = Texture2D.FromFile(GraphicsDevice, filename, textureParam);

                    // Create a new sheet
                    SpriteSheet sheet = new SpriteSheet(texture, filename);

                    // Store the image in the tile display window
                    tDisplay.SpriteImage = image;

                    // Enable the tile properties button on the menu strip
                    tilePropertiesToolStripMenuItem.Enabled = true;

                    // Use the properties to adjust the sprite sheets, add them to the collection,
                    // and modify any open maps
                    ModifyTileProperties(sheet);
                }
            }
        }

        /// <summary>
        /// Modifies the properties of the current tile set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tilePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Use this texture as a sprite sheet and open the tile sheet dialog
            tileProperties.TextureImage = tDisplay.SpriteImage;
            tileProperties.TileWidth = SpriteSheetLayer.TileWidth;
            tileProperties.TileHeight = SpriteSheetLayer.TileHeight;

            if (tileProperties.ShowDialog() == DialogResult.OK)
            {
                // If the properties changed, resize the everything
                if (tileProperties.TileWidth != SpriteSheetLayer.TileWidth ||
                    tileProperties.TileHeight != SpriteSheetLayer.TileHeight)
                {
                    // Get the current sprite sheet
                    SpriteSheet sheet = tDisplay.Sheet;
                    sheet.Clear();

                    // Adjust the sprite sheets based on the new properties
                    ModifyTileProperties(sheet);
                }
            }
        }

        /// <summary>
        /// Handles organizing and processing the data for the tile set to adjust the sprite sheet,
        /// add it to the collection, and reload the tile information in any loaded maps.
        /// </summary>
        /// <param name="sheet">SpriteSheet with the tile set information</param>
        public void ModifyTileProperties(SpriteSheet sheet)
        {
            // Use the values from the dialog box to generate the proper source rectangles
            int i = 0;
            for (int r = 0; r < tileProperties.TileSize.Y; r++)
            {
                for (int c = 0; c < tileProperties.TileSize.X; c++)
                {
                    sheet.AddSourceSprite(i,
                        new Rectangle((c * tileProperties.TileWidth),
                            (r * tileProperties.TileHeight),
                            tileProperties.TileWidth, tileProperties.TileHeight));
                    i++;
                }
            }

            // Add the sprite sheet to the collection
            spriteSheetData.AddSpriteSheet(sheet);

            // Store these in the tile display
            tDisplay.LoadTileSheet(tileProperties.TileWidth, tileProperties.TileHeight,
                tileProperties.TileSize.X, tileProperties.TileSize.Y, sheet);

            // Set the camera
            tileCamera.position = Vector2.Zero;
            tDisplay.Camera = tileCamera;

            // Enable the tile properties menu item
            // NOTE:  This will set only one map to the tile set.  Since we're only using
            // one tile set for all maps, we'll set everything to have this tile.  For further
            // features, we might add the addition of multiple tile sets.
            /**
            // If a map is loaded, set the map to have this tile set
            if (currentMap != null)
                currentMap.SetSpriteSheet(tDisplay.Sheet);
             */
            // If there are maps created already, set all maps to use this tile set
            for (int a = 0; a < tileMapData.Count; a++)
            {
                tileMapData[a].SetSpriteSheet(tDisplay.Sheet);

                // Adjust the scroll bars
                AdjustScrollBars(a);
            }
        }

        #endregion

        #region Map Tab Functions

        void mapTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure the current index doesn't fall below 0.  This can happen
            // when removing all tabs.
            currentTabIndex = (int)Math.Max(mapTabControl.SelectedIndex, 0);

            // Update the camera view and map display
            if (mapTabControl.TabCount != 0)
            {
                currentMap = tileMapData[currentTabIndex];
                mapCamera.position = Vector2.Zero;
                currentMap.CameraChange(mapCamera);
            }
            else
            {
                currentMap = null;
            }

            UpdateStatus();
        }

        /// <summary>
        /// Creates another tab for the tab control holding the map display
        /// </summary>
        /// <param name="name">Name of tab to create</param>
        private void CreateNewTab(string name)
        {
            // Add a new tab
            TabPage tab = new TabPage(name);
            //tab.ContextMenuStrip = contextMenuTab;
            mapTabControl.TabPages.Add(tab);

            // Create the map display
            MapDisplay display = new MapDisplay();
            display.Width = tab.Width - cScrollbarWidth;
            display.Height = tab.Height - cScrollbarWidth;
            display.Location = new System.Drawing.Point(0, 0);
            tab.Controls.Add(display);
            mapDisplay.Add(display);
            
            // Connect the events to the functions
            display.MouseLeave += new EventHandler(mapDisplay_MouseLeave);
            display.MouseMove += new MouseEventHandler(mapDisplay_MouseMove);
            display.MouseEnter += new EventHandler(mapDisplay_MouseEnter);
            display.MouseClick += new MouseEventHandler(display_MouseClick);

            // Add the scroll bars
            HScrollBar hsbScroll = new HScrollBar();
            hsbScroll.Width = display.Width;
            hsbScroll.Height = cScrollbarWidth;
            hsbScroll.SmallChange = 1;
            hsbScroll.LargeChange = cLargeScrollChange;
            hsbScroll.Minimum = 0;
            hsbScroll.Location = new System.Drawing.Point(0, display.Height);
            hsbScroll.ValueChanged += new EventHandler(UpdateCamera);
            hsbScroll.Scroll += new ScrollEventHandler(UpdateCameraScroll);
            tab.Controls.Add(hsbScroll);
            hsbMapDisplay.Add(hsbScroll);

            VScrollBar vsbScroll = new VScrollBar();
            vsbScroll.Width = cScrollbarWidth;
            vsbScroll.Height = display.Height;
            vsbScroll.SmallChange = 1;
            vsbScroll.LargeChange = cLargeScrollChange;
            vsbScroll.Minimum = 0;
            vsbScroll.Location = new System.Drawing.Point(display.Width, 0);
            vsbScroll.ValueChanged += new EventHandler(UpdateCamera);
            vsbScroll.Scroll += new ScrollEventHandler(UpdateCameraScroll);
            tab.Controls.Add(vsbScroll);
            vsbMapDisplay.Add(vsbScroll);
        }

        /// <summary>
        /// Removes the current tab from the control
        /// </summary>
        private void RemoveTab()
        {
            // Locate the tab name in the lists and remove them
            int index = tileMapData.FindIndex(mapTabControl.SelectedTab.Text);

            mapDisplay.RemoveAt(index);
            hsbMapDisplay.RemoveAt(index);
            vsbMapDisplay.RemoveAt(index);
            tileMapData.RemoveMap(mapTabControl.SelectedTab.Text);

            // Remove the tab
            mapTabControl.TabPages.Remove(mapTabControl.SelectedTab);

            // If there's no more maps, disable the map removal and properties menu tiem
            if (mapTabControl.TabCount == 0)
            {
                mapPropertiesToolStripMenuItem.Enabled = false;
                removeMapToolStripMenuItem.Enabled = false;
                showGridToolStripMenuItem.Enabled = false;
                showCollisionToolStripMenuItem.Enabled = false;
            }
        }

        #endregion

        #region Map Properties

        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the necessary information
            int num = tileMapData.Count + 1;
            mapProperties.ClearForm();
            mapProperties.Identifier = "Map" + num.ToString();

            // Generates a new map
            if (mapProperties.ShowDialog() == DialogResult.OK)
            {
                // Create a new tab with the map display
                CreateNewTab(mapProperties.Identifier);

                // Use the information provided to generate a new map
                TileMap newMap = new TileMap(mapProperties.HorizontalTiles,
                    mapProperties.VerticalTiles, 
                    new Vector2(mapDisplay[currentTabIndex].Width, mapDisplay[currentTabIndex].Height),
                    tDisplay.GridTexture);
                newMap.Identifier = mapProperties.Identifier;
                newMap.MapName = mapProperties.MapName;

                // Add the map to the collection
                tileMapData.AddMap(newMap);

                // If there's a tileset loaded, load the sheet into the map
                if (tDisplay.Sheet != null)
                    newMap.SetSpriteSheet(tDisplay.Sheet);

                // Set as the current map
                currentMap = newMap;

                // Switch to the new tab, which will be at the end
                mapTabControl.SelectedIndex = mapTabControl.TabCount - 1;

                // Using the map size, resize the scroll bars
                AdjustScrollBars(currentTabIndex);

                // Enable the map properties menu item if not already and map removal
                mapPropertiesToolStripMenuItem.Enabled = true;
                removeMapToolStripMenuItem.Enabled = true;
                showGridToolStripMenuItem.Enabled = true;
                showCollisionToolStripMenuItem.Enabled = true;

                // Update the map display
                currentMap.ShowGrid = showGridToolStripMenuItem.Checked;
                UpdateMapDisplay();

                // Update the status at the bottom
                UpdateStatus();

                // Update the camera and map display
                mapDisplay[currentTabIndex].Map = newMap;
                mapCamera.position = Vector2.Zero;
                currentMap.CameraChange(mapCamera);
            }
        }

        private void mapPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fill in map properties with the current information on the map selected
            mapProperties.ClearForm();
            mapProperties.Identifier = mapTabControl.SelectedTab.Text;
            mapProperties.HorizontalTiles = currentMap.MapWidth;
            mapProperties.VerticalTiles = currentMap.MapHeight;
            mapProperties.MapName = currentMap.MapName;

            if (mapProperties.ShowDialog() == DialogResult.OK)
            {
                // Change the properties of the map and resize if necessary
                currentMap.Identifier = mapProperties.Identifier;
                mapTabControl.SelectedTab.Text = mapProperties.Identifier;
                currentMap.MapName = mapProperties.MapName;
                currentMap.ResizeMap(mapProperties.HorizontalTiles, mapProperties.VerticalTiles);

                // Using the map size, resize the scroll bars
                AdjustScrollBars(currentTabIndex);

                // Update the status at the bottom
                UpdateStatus();
            }
        }

        /// <summary>
        /// Adjusts the scroll bars to have the correct values to match the selected map size by subtracting the
        /// size of the display from the size of the map if the width or height is larger.
        /// </summary>
        /// <param name="currentTab">Currently selected tab for adjusting the scroll bars</param>
        private void AdjustScrollBars(int currentTab)
        {
            int maxWidth, maxHeight;

			if (tileMapData[currentTab].MapWidthInPixels > mapDisplay[currentTab].Width)
			{
                maxWidth = tileMapData[currentTab].MapWidthInPixels - mapDisplay[currentTab].Width;

                hsbMapDisplay[currentTab].Enabled = true;
                hsbMapDisplay[currentTab].Maximum = (maxWidth + cLargeScrollChange) - 1;
			}
			else
			{
                hsbMapDisplay[currentTab].Maximum = 0;
                hsbMapDisplay[currentTab].Enabled = false;
			}

            if (tileMapData[currentTab].MapHeightInPixels > mapDisplay[currentTab].Height)
			{
                maxHeight = tileMapData[currentTab].MapHeightInPixels - mapDisplay[currentTab].Height;

                vsbMapDisplay[currentTab].Enabled = true;
                vsbMapDisplay[currentTab].Maximum = (maxHeight + cLargeScrollChange) - 1;
			}
			else
			{
                vsbMapDisplay[currentTab].Maximum = 0;
                vsbMapDisplay[currentTab].Enabled = false;
			}
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Start creating a new map
            newMapToolStripMenuItem_Click(sender, e);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Removes the currently selected tab
            RemoveTab();
        }

        private void removeMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Removes the currently selected tab
            RemoveTab();
        }

        /// <summary>
        /// Used mainly for direct values changes to the scroll bars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpdateCamera(object sender, EventArgs e)
        {
            mapCamera.position.X = hsbMapDisplay[currentTabIndex].Value;
            mapCamera.position.Y = vsbMapDisplay[currentTabIndex].Value;
            currentMap.CameraChange(mapCamera);
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
                    mapCamera.position.X = e.NewValue;

                //Console.WriteLine("Horiz: " + e.NewValue.ToString());
            }
            else
            {
                // If the scroll bar is being dragged or stopped moving, update the position
                if (e.Type == ScrollEventType.ThumbPosition || e.Type == ScrollEventType.ThumbTrack ||
                    e.Type == ScrollEventType.EndScroll)
                    mapCamera.position.Y = e.NewValue;

                //Console.WriteLine("Vert: " + e.NewValue.ToString());
            }

            // Update the camera
            currentMap.CameraChange(mapCamera);

            // Force the display to update
            mapDisplay[currentTabIndex].Invalidate();
        }

        #endregion

        #region Status Updates

        /// <summary>
        /// Updates the data on the status bar to reflect recent changes
        /// </summary>
        private void UpdateStatus()
        {
            // If there's no tabs, clear the status at the bottom
            if (mapTabControl.SelectedIndex == -1)
            {
                mapSizeStatusLabel.Text = "";
                mapLocationStatusLabel.Text = "";
            }
            else
            {
                // Update the status at the bottom
                mapSizeStatusLabel.Text = "Size: (" + currentMap.MapWidth + ", " +
                   currentMap.MapHeight + ")";
            }
        }

        /// <summary>
        /// Updates the map display when selecting different tools.
        /// </summary>
        /// <remarks>Currently, this is mainly for the collision layer, but may be used
        /// for something else later on</remarks>
        private void UpdateMapDisplay()
        {
            // Check to see if the current map isn't null
            if (currentMap != null)
            {
                // Toggles on and off the collision layer
                if (currentTool == EditorTool.PaintCollision || currentTool == EditorTool.EraseCollision ||
                    showCollisionToolStripMenuItem.Checked == true)
                    currentMap.ShowCollision = true;
                else
                    currentMap.ShowCollision = false;
            }
        }

        #endregion

        #region Editor Tool States

        private void rbtnErase_CheckedChanged(object sender, EventArgs e)
        {
            currentTool = EditorTool.Erase;
            UpdateMapDisplay();
        }

        private void rbtnPaint_CheckedChanged(object sender, EventArgs e)
        {
            currentTool = EditorTool.Paint;
            UpdateMapDisplay();
        }

        private void rbtnFill_CheckedChanged(object sender, EventArgs e)
        {
            currentTool = EditorTool.Fill;
            UpdateMapDisplay();
        }

        private void rbtnCollision_CheckedChanged(object sender, EventArgs e)
        {
            currentTool = EditorTool.PaintCollision;
            UpdateMapDisplay();
        }

        private void rbtnEraseCollision_CheckedChanged(object sender, EventArgs e)
        {
            currentTool = EditorTool.EraseCollision;
            UpdateMapDisplay();
        }

        #endregion

        private void exportXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExporterForm form = new ExporterForm(tileMapData[0]);
            form.ShowDialog();
        }

        private void lstLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mapDisplay != null && mapDisplay.Count > 0)
            {
                if (lstLayers.SelectedIndex == -1)
                    mapDisplay[currentTabIndex].CurrentLayer = -1;
                else
                    mapDisplay[currentTabIndex].CurrentLayer = 2 - lstLayers.SelectedIndex;
            }
        }

        private void xMLSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExporterSettingsForm form = new ExporterSettingsForm();
            form.ShowDialog();
        }

        private void debugButton_Click(object sender, EventArgs e)
        {
            // DEBUG!  A generic button use to debug certain functions.  Used for testing purposes and
            // can crash the program.
            // For this test, just testing copying data to a map (if on exists)
            if (tileMapData.Count > 0)
            {
                int height = tileMapData[0].MapHeight;
                int width = tileMapData[0].MapWidth;

                // Create a dummy data to replace
                int[,] dummyData = new int[height, width];
                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)
                        dummyData[i, j] = 10;

                // Replace the map data
                tileMapData[0].SetMap(dummyData, 0);
            }
        }
    }
}