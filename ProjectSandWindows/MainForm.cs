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

    public partial class MainForm : Form
    {
        #region Fields

        // XNA sprite batch for rendering
        SpriteBatch spriteBatch;

        // Tile properties window
        frmTileProperties tileProperties = new frmTileProperties();
        // Map properties window
        frmMapProperties mapProperties = new frmMapProperties();

        // Basic data for the editor
        TileMapCollection tileMapData = new TileMapCollection();
        Camera camera = new Camera();

        // Current opened file
        string currentProjectFile = "";

        // Last mouse position
        Point lastMousePos;

        // Sizes for the map scroll bars
        int maxWidth = 0, maxHeight = 0;

        /// <summary>
        /// Returns the graphics device for rendering
        /// </summary>
        public GraphicsDevice GraphicsDevice
        {
            get { return tileDisplay.GraphicsDevice; }
        }

        #endregion

        #region Tab Items

        // Map display for the tabs
        List<TileDisplay> mapDisplay = new List<TileDisplay>();
        // Scroll bars for the map
        List<HScrollBar> hsbMapDisplay = new List<HScrollBar>();
        List<VScrollBar> vsbMapDisplay = new List<VScrollBar>();

        // Current selected tab index
        int currentTabIndex = 0;

        #endregion

        #region Initialization

        public MainForm()
        {
            InitializeComponent();

            // Sets up event handlers for the tile and map display
            tileDisplay.OnInitialize += new EventHandler(tileDisplay_OnInitialize);
            tileDisplay.OnDraw += new EventHandler(tileDisplay_OnDraw);

            // Set up events for changing tabs
            mapTabControl.SelectedIndexChanged += new EventHandler(mapTabControl_SelectedIndexChanged);

            // Forces the map and tiles to keep redrawing when idle
            Application.Idle += delegate { 
                tileDisplay.Invalidate();
            };

            // Clear the status at the bottom
            mapSizeStatusLabel.Text = "";
            mapLocationStatusLabel.Text = "";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Display Handling

        #region Map/Tile Display

        void tileDisplay_OnInitialize(object sender, EventArgs e)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        void tileDisplay_OnDraw(object sender, EventArgs e)
        {
            Logic();
            Render();
        }

        void mapDisplay_MouseEnter(object sender, EventArgs e)
        {
            // TODO:  Set mouse position, or does this function need to be created since
            // move will trigger immediately after?
            mapLocationStatusLabel.Text = "In!";
        }

        void mapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the mouse position and calculate where to draw the highlighting square
            // TODO:  For now, just updating the status bar at the bottom
            mapLocationStatusLabel.Text = "(" + e.X + ", " + e.Y + ")";
        }

        void mapDisplay_MouseLeave(object sender, EventArgs e)
        {
            // When the moust leaves, reset the grid highlights
            mapLocationStatusLabel.Text = "Invalid";
        }

        void display_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Console.WriteLine("Left Click!");
            else if (e.Button == MouseButtons.Right)
                Console.WriteLine("Right Click!");            
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
            openFileDialog1.Filter = "JPG Image (*.jpg)|*.jpg|PNG Image (*.png)|*.png|BMP Image (*.bmp)|*.bmp|TGA Image (*.tga)|*.tga";
            //openFileDialog1.InitialDirectory = contentPathTextBox.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                Texture2D texture = Texture2D.FromFile(GraphicsDevice, filename);
                Image image = Image.FromFile(filename);

                // Use this texture as a sprite sheet and open the tile sheet dialog
                tileProperties.Texture = texture;
                tileProperties.TextureImage = image;

                if (tileProperties.ShowDialog() == DialogResult.OK)
                {
                    // TODO:  Get the values from the form and load it into the classes
                }
            }
        }

        #endregion

        #region Tab Functions

        void mapTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure the current index doesn't fall below 0.  This can happen
            // when removing all tabs.
            currentTabIndex = (int)Math.Max(mapTabControl.SelectedIndex, 0);

            // If there's actually no tabs, clear the bottom
            if (mapTabControl.SelectedIndex == -1)
            {
                mapSizeStatusLabel.Text = "";
                mapLocationStatusLabel.Text = "";
            }
            else
            {
                // Update the status at the bottom
                mapSizeStatusLabel.Text = "Size: (" + tileMapData[currentTabIndex].MapWidth + ", " +
                   tileMapData[currentTabIndex].MapHeight + ")";
            }
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
            TileDisplay display = new TileDisplay();
            display.Width = 524;
            display.Height = 442;
            display.Location = new System.Drawing.Point(0, 0);
            tab.Controls.Add(display);
            mapDisplay.Add(display);
            
            // Connect the events to the functions
            display.OnInitialize += new EventHandler(tileDisplay_OnInitialize);
            display.OnDraw += new EventHandler(tileDisplay_OnDraw);
            display.MouseLeave += new EventHandler(mapDisplay_MouseLeave);
            display.MouseMove += new MouseEventHandler(mapDisplay_MouseMove);
            display.MouseEnter += new EventHandler(mapDisplay_MouseEnter);
            display.MouseClick += new MouseEventHandler(display_MouseClick);

            // Forces the map and tiles to keep redrawing when idle
            Application.Idle += delegate { display.Invalidate(); };

            // Add the scroll bars
            HScrollBar hsbScroll = new HScrollBar();
            hsbScroll.Width = 524;
            hsbScroll.Height = 18;
            hsbScroll.Location = new System.Drawing.Point(0, 442);
            tab.Controls.Add(hsbScroll);
            hsbMapDisplay.Add(hsbScroll);

            VScrollBar vsbScroll = new VScrollBar();
            vsbScroll.Width = 18;
            vsbScroll.Height = 442;
            vsbScroll.Location = new System.Drawing.Point(524, 0);
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
                    new Vector2(mapDisplay[currentTabIndex].Width, mapDisplay[currentTabIndex].Height));
                newMap.Identifier = mapProperties.Identifier;
                newMap.MapName = mapProperties.MapName;

                // Add the map to the collection
                tileMapData.AddMap(newMap);

                // Switch to the new tab, which will be at the end
                mapTabControl.SelectedIndex = mapTabControl.TabCount - 1;

                // Using the map size, resize the scroll bars
                AdjustScrollBars();

                // Enable the map properties menu item if not already and map removal
                mapPropertiesToolStripMenuItem.Enabled = true;
                removeMapToolStripMenuItem.Enabled = true;
            }
        }

        private void mapPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fill in map properties with the current information on the map selected
            mapProperties.ClearForm();
            mapProperties.Identifier = mapTabControl.SelectedTab.Text;
            mapProperties.HorizontalTiles = tileMapData[currentTabIndex].MapWidth;
            mapProperties.VerticalTiles = tileMapData[currentTabIndex].MapHeight;
            mapProperties.MapName = tileMapData[currentTabIndex].MapName;

            if (mapProperties.ShowDialog() == DialogResult.OK)
            {
                // Change the properties of the map and resize if necessary
                tileMapData[currentTabIndex].Identifier = mapProperties.Identifier;
                mapTabControl.SelectedTab.Text = mapProperties.Identifier;
                tileMapData[currentTabIndex].MapName = mapProperties.MapName;
                tileMapData[currentTabIndex].ResizeMap(mapProperties.HorizontalTiles, mapProperties.VerticalTiles);

                // Using the map size, resize the scroll bars
                AdjustScrollBars();

                // Update the status at the bottom
                mapSizeStatusLabel.Text = "Size: (" + tileMapData[currentTabIndex].MapWidth + ", " +
                   tileMapData[currentTabIndex].MapHeight + ")";
            }
        }

        /// <summary>
        /// Adjusts the scroll bars to have the correct values to match the selected map size
        /// </summary>
        private void AdjustScrollBars()
        {
            // Note that the camera is centered, so we calculate everything with respect to
            // the center of the camera view

            // TODO:  Reference the correct map index
			if (tileMapData[currentTabIndex].MapWidthInPixels > mapDisplay[currentTabIndex].Width)
			{
				maxWidth = (int)Math.Max(tileMapData[currentTabIndex].MapWidthInPixels - mapDisplay[currentTabIndex].Width, maxWidth);

                hsbMapDisplay[currentTabIndex].Enabled = true;
                hsbMapDisplay[currentTabIndex].Minimum = 0;
                hsbMapDisplay[currentTabIndex].Maximum = maxWidth;
			}
			else
			{
				maxWidth = 0;
                hsbMapDisplay[currentTabIndex].Enabled = false;
			}

            if (tileMapData[currentTabIndex].MapHeightInPixels > mapDisplay[currentTabIndex].Height)
			{
                maxHeight = (int)Math.Max(tileMapData[currentTabIndex].MapHeightInPixels - mapDisplay[currentTabIndex].Height, maxHeight);

                vsbMapDisplay[currentTabIndex].Enabled = true;
                vsbMapDisplay[currentTabIndex].Minimum = 0;
                vsbMapDisplay[currentTabIndex].Maximum = maxHeight;
			}
			else
			{
				maxHeight = 0;
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

        #endregion

        #region Logic and Drawing

        private void Logic()
        {
            // Check the scroll bar positions for updating the camera position

        }

        private void Render()
        {
            GraphicsDevice.Clear(Color.Black);
        }

        #endregion
    }
}