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

    public partial class MainForm : Form
    {
        #region Constants

        /// <summary>
        /// Width of the scroll bar
        /// </summary>
        const int cScrollbarWidth = 18;

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
        int maxWidth = 0, maxHeight = 0;

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

            // Initialize the Tile Display
            tDisplay.SetScrollBars(hsbTileDisplay, vsbTileDisplay);
            tDisplay.Camera = tileCamera;

            ExporterSettings.Initialize();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Display Handling

        #region Map/Tile Display

        void mapDisplay_MouseEnter(object sender, EventArgs e)
        {
            // TODO:  Set mouse position, or does this function need to be created since
            // move will trigger immediately after?
            currentMap.MouseInMap = true;
            mapLocationStatusLabel.Text = "In!";
        }

        void mapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the mouse position and calculate where to draw the highlighting square
            // Use the position to find the row and col of the current map
            currentMap.SetMousePosition(e.X, e.Y, mapCamera);

            // Update the status at the bottom
            mapLocationStatusLabel.Text = "(" + currentMap.MouseTile.X + ", " + 
                currentMap.MouseTile.Y + ")";
            
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
                    // Put the currently selected tile(s) into the map
                    if (tDisplay.TileSelection != Rectangle.Empty && lstLayers.SelectedIndex != -1 &&
                        currentMap.MouseTile.X >= 0 && currentMap.MouseTile.Y >= 0)
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
            mapLocationStatusLabel.Text = "Invalid";
            currentMap.MouseInMap = false;
        }

        void display_MouseClick(object sender, MouseEventArgs e)
        {
            // TODO:  Do something with the clicks
            if (e.Button == MouseButtons.Left && !inPanMode)
            {
                // Put the currently selected tile(s) into the map
                if (tDisplay.TileSelection != Rectangle.Empty && lstLayers.SelectedIndex != -1)
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
            }
            else if (e.Button == MouseButtons.Right)
                Console.WriteLine("Right Click!");            
        }

        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle whether to show the grid on the map
            currentMap.ShowGrid = showGridToolStripMenuItem.Checked;
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
                    tDisplay.SpriteImage = image;

                    // Set the camera
                    tileCamera.position = Vector2.Zero;
                    tDisplay.Camera = tileCamera;

                    // Enable the tile properties menu item
                    tilePropertiesToolStripMenuItem.Enabled = true;

                    // If a map is loaded, set the map to have this tile set
                    if (currentMap != null)
                        currentMap.SetSpriteSheet(tDisplay.Sheet);
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

                    // Clear the sprite sheet and use the values from the dialog box to 
                    // generate the proper source rectangles
                    sheet.Clear();

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

                    // Store the updated values
                    tDisplay.LoadTileSheet(tileProperties.TileWidth, tileProperties.TileHeight,
                        tileProperties.TileSize.X, tileProperties.TileSize.Y, sheet);

                    // Reset the camera
                    tileCamera.position = Vector2.Zero;
                    tDisplay.Camera = tileCamera;
                }
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
            hsbScroll.LargeChange = 25;
            hsbScroll.Location = new System.Drawing.Point(0, display.Height);
            hsbScroll.ValueChanged += new EventHandler(UpdateCamera);
            hsbScroll.Scroll += new ScrollEventHandler(UpdateCameraScroll);
            tab.Controls.Add(hsbScroll);
            hsbMapDisplay.Add(hsbScroll);

            VScrollBar vsbScroll = new VScrollBar();
            vsbScroll.Width = cScrollbarWidth;
            vsbScroll.Height = display.Height;
            vsbScroll.SmallChange = 1;
            vsbScroll.LargeChange = 25;
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
                AdjustScrollBars();

                // Enable the map properties menu item if not already and map removal
                mapPropertiesToolStripMenuItem.Enabled = true;
                removeMapToolStripMenuItem.Enabled = true;
                showGridToolStripMenuItem.Enabled = true;

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
                AdjustScrollBars();

                // Update the status at the bottom
                UpdateStatus();
            }
        }

        /// <summary>
        /// Adjusts the scroll bars to have the correct values to match the selected map size by subtracting the
        /// size of the display from the size of the map if the width or height is larger.
        /// </summary>
        private void AdjustScrollBars()
        {
			if (currentMap.MapWidthInPixels > mapDisplay[currentTabIndex].Width)
			{
				maxWidth = (int)Math.Max(currentMap.MapWidthInPixels - mapDisplay[currentTabIndex].Width, maxWidth);

                hsbMapDisplay[currentTabIndex].Enabled = true;
                hsbMapDisplay[currentTabIndex].Minimum = 0;
                hsbMapDisplay[currentTabIndex].Maximum = (maxWidth + hsbMapDisplay[currentTabIndex].LargeChange) - 1;
			}
			else
			{
				maxWidth = 0;
                hsbMapDisplay[currentTabIndex].Minimum = 0;
                hsbMapDisplay[currentTabIndex].Maximum = 0;
                hsbMapDisplay[currentTabIndex].Enabled = false;
			}

            if (currentMap.MapHeightInPixels > mapDisplay[currentTabIndex].Height)
			{
                maxHeight = (int)Math.Max(currentMap.MapHeightInPixels - mapDisplay[currentTabIndex].Height, maxHeight);

                vsbMapDisplay[currentTabIndex].Enabled = true;
                vsbMapDisplay[currentTabIndex].Minimum = 0;
                vsbMapDisplay[currentTabIndex].Maximum = (maxHeight + vsbMapDisplay[currentTabIndex].LargeChange) - 1;
			}
			else
			{
				maxHeight = 0;
                vsbMapDisplay[currentTabIndex].Minimum = 0;
                vsbMapDisplay[currentTabIndex].Maximum = 0;
                vsbMapDisplay[currentTabIndex].Enabled = false;
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

        #endregion

        private void exportXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExporterForm form = new ExporterForm(tileMapData[0]);
            form.ShowDialog();
        }
    }
}