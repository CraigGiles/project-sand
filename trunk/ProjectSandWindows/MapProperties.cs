#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
#endregion

namespace ProjectSandWindows
{
    public partial class frmMapProperties : Form
    {
        #region Properties

        /// <summary>
        /// Name of the map used in the editor
        /// </summary>
        string identifier = "Map1";

        /// <summary>
        /// Name of the map used in the editor
        /// </summary>
        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
        }

        /// <summary>
        /// Number of horizontal tiles
        /// </summary>
        int horizontalTiles = 1;

        /// <summary>
        /// Number of horizontal tiles
        /// </summary>
        public int HorizontalTiles
        {
            get { return horizontalTiles; }
            set { horizontalTiles = value; }
        }

        /// <summary>
        /// Number of vertical tiles
        /// </summary>
        int verticalTiles = 1;

        /// <summary>
        /// Number of vertical tiles
        /// </summary>
        public int VerticalTiles
        {
            get { return verticalTiles; }
            set { verticalTiles = value; }
        }

        /// <summary>
        /// Map name used in the game
        /// </summary>
        string mapName;

        /// <summary>
        /// Map name used in the game
        /// </summary>
        public string MapName
        {
            get { return mapName; }
            set { mapName = value; }
        }

        #endregion

        #region Form Events

        public frmMapProperties()
        {
            InitializeComponent();

            this.Shown += new EventHandler(frmMapProperties_Shown);
        }

        void frmMapProperties_Shown(object sender, EventArgs e)
        {
            txtIdentifier.Text = identifier;
            numHorizontal.Value = horizontalTiles;
            numVertical.Value = verticalTiles;
            txtMapName.Text = mapName;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Resets the values on the form
        /// </summary>
        public void ClearForm()
        {
            txtIdentifier.Text = identifier = "";
            numHorizontal.Value = horizontalTiles = 1;
            numVertical.Value = verticalTiles = 1;
            txtMapName.Text = mapName = "";
        }

        #endregion

        #region Button Events

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            
            // Set the properties to the entered values
            identifier = txtIdentifier.Text;
            horizontalTiles = (int)numHorizontal.Value;
            verticalTiles = (int)numVertical.Value;
            mapName = txtMapName.Text;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Closes the dialog
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}