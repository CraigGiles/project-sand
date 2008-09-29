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
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SandTileEngine;
#endregion

namespace ProjectSandWindows
{
    public partial class MainForm : Form
    {
        #region Fields

        // Tile properties window
        frmTileProperties tileProperties = new frmTileProperties();
        // Map properties window
        frmMapProperties mapProperties = new frmMapProperties();

        // Basic data for the editor
        TileMapCollection tileMapData = new TileMapCollection();
        Camera camera = new Camera();

        // Current opened file
        string currentProjectFile = "";

        /// <summary>
        /// Returns the graphics device for rendering
        /// </summary>
        public GraphicsDevice GraphicsDevice
        {
            get { return mapDisplay.GraphicsDevice; }
        }

        #endregion

        #region Initialization

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

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

        #region Map Properties

        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Generates a new map
            if (mapProperties.ShowDialog() == DialogResult.OK)
            {
                // TODO:  Use the information provided to generate a new map
            }
        }

        private void mapPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mapProperties.ShowDialog() == DialogResult.OK)
            {
                // TODO:  Change the properties of the map and resize if necessary
            }
        }

        #endregion
    }
}