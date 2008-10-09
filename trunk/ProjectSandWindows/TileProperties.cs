#region Using Statements
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace ProjectSandWindows
{
    public partial class frmTileProperties : Form
    {
        #region Texture Properties

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

        #region Tile Properties

        string tileName;

        /// <summary>
        /// Name of the tile set
        /// </summary>
        public string TileName
        {
            get { return tileName; }
            set { tileName = value; }
        }

        int tileWidth;

        /// <summary>
        /// Width of the tile set in pixels
        /// </summary>
        public int TileWidth
        {
            get { return tileWidth; }
            set { tileWidth = value; }
        }

        int tileHeight;

        /// <summary>
        /// Height of the tile set in pixels
        /// </summary>
        public int TileHeight
        {
            get { return tileHeight; }
            set { tileHeight = value; }
        }

        int horizSpace;

        /// <summary>
        /// Padding of each tile horizontally
        /// </summary>
        public int HorizSpace
        {
            get { return horizSpace; }
            set { horizSpace = value; }
        }

        int verticalSpace;

        /// <summary>
        /// Padding of each tile vertically
        /// </summary>
        public int VerticalSpace
        {
            get { return verticalSpace; }
            set { verticalSpace = value; }
        }

        int leftClip;

        /// <summary>
        /// Amount of pixels to remove from the left
        /// </summary>
        public int LeftClip
        {
            get { return leftClip; }
            set { leftClip = value; }
        }

        int topClip;

        /// <summary>
        /// Amount of pixels to remove from the top
        /// </summary>
        public int TopClip
        {
            get { return topClip; }
            set { topClip = value; }
        }

        Point tileSize;

        /// <summary>
        /// Returns the size of the tile set in number of tiles
        /// </summary>
        /// <remarks>Calculated internally when OK is pressed</remarks>
        public Point TileSize
        {
            get { return tileSize; }
        }

        #endregion

        #region Initialization

        public frmTileProperties()
        {
            InitializeComponent();

            this.Shown += new EventHandler(frmTileSheetProperties_Shown);
        }

        private void frmTileSheetProperties_Shown(object sender, EventArgs e)
        {
            // Fill the preview
            picPreview.Image = image;

            // Get the size of the texture
            if (texture != null)
                lblSizePosition.Text = "Size: (" + texture.Width + ", " + texture.Height + ")";
            else
                lblSizePosition.Text = "No Texture Loaded!!";
        }

        private void frmTileSheetProperties_Load(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Returns that OK was clicked
            this.DialogResult = DialogResult.OK;

            // Store all the data
            tileName = txtTileName.Text;
            tileWidth = (int)numTileWidth.Value;
            tileHeight = (int)numTileHeight.Value;
            horizSpace = (int)numHorizSpace.Value;
            verticalSpace = (int)numVerticalSpace.Value;
            leftClip = (int)numClipLeft.Value;
            topClip = (int)numClipTop.Value;

            // Calculate the size of the tileset
            tileSize = new Point(
                image.Size.Width / (tileWidth + (horizSpace * 2) + leftClip),
                image.Size.Height / (tileHeight + (verticalSpace * 2) + topClip));

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}