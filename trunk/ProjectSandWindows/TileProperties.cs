#region Using Statements
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace ProjectSandWindows
{
    public partial class frmTileProperties : Form
    {
        #region Fields

        // Local copy of the texture to be loaded in the properties
        Texture2D texture;
        Image image;

        /// <summary>
        /// Local copy of the texture to be loaded in the properties
        /// </summary>
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        /// <summary>
        /// Local copy of the texture image for preview viewing
        /// </summary>
        public Image TextureImage
        {
            get { return image; }
            set { image = value; }
        }

        #endregion

        #region Initialization

        public frmTileProperties()
        {
            InitializeComponent();
        }

        private void frmTileSheetProperties_Load(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Returns that OK was clicked
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close thw dialog and remove the data
            texture.Dispose();
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}