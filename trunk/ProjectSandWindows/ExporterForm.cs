using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SandTileEngine;

namespace ProjectSandWindows
{
    public partial class ExporterForm : Form
    {
        #region Constructor(s)
        /// <summary>
        /// Creates a new ExporterForm object
        /// </summary>
        public ExporterForm()
        {
            InitializeComponent();
            Form.ActiveForm.AutoScroll = true;
        }

        public ExporterForm(TileMap map)
        {
            InitializeComponent();
            Form.ActiveForm.AutoScroll = true;
        }

        public ExporterForm(List<TileMap> maps)
        {
            InitializeComponent();
            Form.ActiveForm.AutoScroll = true;
        }

        #endregion

        #region Map Name
        private void mapNameInput_TextChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<" + mapNameInput.Text + ">");
            sb.Append("MapName");
            sb.Append("</" + mapNameInput.Text + ">");

            mapNameOutput.Text = sb.ToString();
        }
        #endregion

        #region Map Dimensions
        private void ChangeMapDimensionsOutputText()
        {
            StringBuilder sb = new StringBuilder();

            if (mapDimensionsPointButton.Checked)
            {
                sb.Append("<" + mapDimensionsInput.Text + ">");
                sb.Append("X Y");
                sb.Append("</" + mapDimensionsInput.Text + ">");
            }
            else if (mapDimensionsCustomButton.Checked)
            {
                sb.Append("<" + mapDimensionsInput.Text + ">");
                sb.Append("\n     <" + mapDimensionsWidthInput.Text + ">");
                sb.Append("X");
                sb.Append("</" + mapDimensionsWidthInput.Text + ">");
                sb.Append("\n     <" + mapDimensionsHeightInput.Text + ">");
                sb.Append("Y");
                sb.Append("</" + mapDimensionsHeightInput.Text + ">\n");
                sb.Append("<" + mapDimensionsInput.Text + ">");
            }

            mapDimensionsOutput.Text = sb.ToString();
        }

        private void mapDimensionsInput_TextChanged(object sender, EventArgs e)
        {
            ChangeMapDimensionsOutputText();
        }
        

        private void mapDimensionsPointButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeMapDimensionsOutputText();
        }

        private void mapDimensionsCustomButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeMapDimensionsOutputText();
        }

        private void mapDimensionsWidthInput_TextChanged(object sender, EventArgs e)
        {
            ChangeMapDimensionsOutputText();
        }

        private void mapDimensionsHeightInput_TextChanged(object sender, EventArgs e)
        {
            ChangeMapDimensionsOutputText();
        }
        #endregion

        #region Tile Sheet
        private void tileSheetContentInput_TextChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<" + tileSheetContentInput.Text + ">");
            sb.Append("ProjectsContentPath//TileSheet");
            sb.Append("</" + tileSheetContentInput.Text + ">");

            tileSheetOutput.Text = sb.ToString();
        }
        #endregion

        #region Tile Dimensions
        private void ChangeTileDimensionsOutputText()
        {
            StringBuilder sb = new StringBuilder();

            if (tileDimensionsPointButton.Checked)
            {
                sb.Append("<" + tileDimensionsInput.Text + ">");
                sb.Append("X Y");
                sb.Append("</" + tileDimensionsInput.Text + ">");
            }
            else if (tileDimensionsCustomButton.Checked)
            {
                sb.Append("<" + tileDimensionsInput.Text + ">");
                sb.Append("\n     <" + tileDimensionsWidthInput.Text + ">");
                sb.Append("X");
                sb.Append("</" + tileDimensionsWidthInput.Text + ">");
                sb.Append("\n     <" + tileDimensionsHeightInput.Text + ">");
                sb.Append("Y");
                sb.Append("</" + tileDimensionsHeightInput.Text + ">\n");
                sb.Append("<" + tileDimensionsInput.Text + ">");
            }

            tileDimensionsOutput.Text = sb.ToString();
        }

        private void tileDimensionsPointButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeTileDimensionsOutputText();
        }

        private void tileDimensionsCustomButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeTileDimensionsOutputText();
        }

        private void tileDimensionsInput_TextChanged(object sender, EventArgs e)
        {
            ChangeTileDimensionsOutputText();
        }

        private void tileDimensionsWidthInput_TextChanged(object sender, EventArgs e)
        {
            ChangeTileDimensionsOutputText();
        }

        private void tileDimensionsHeightInput_TextChanged(object sender, EventArgs e)
        {
            ChangeTileDimensionsOutputText();
        }
        #endregion

        #region Map Layers
        private void mapLayersGroupedButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeMapLayersOutput();
        }

        private void mapLayersIndividualButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeMapLayersOutput();
        }

        private void ChangeMapLayersOutput()
        {
            StringBuilder sb = new StringBuilder();

            if (mapLayersGroupedButton.Checked)
            {
                sb.Append("<" + mapLayersBaseElement.Text + ">\n");
                GetMapLayerOutput(sb);
                sb.Append("</" + mapLayersBaseElement.Text + ">\n");
            }
            else
            {
                GetMapLayerOutput(sb);
            }
            

            mapLayerOutput.Text = sb.ToString();
        }

        private void GetMapLayerOutput(StringBuilder sb)
        {
            if (mapLayerCheckBoxBaseLayer.Checked)
            {
                sb.Append("     <" + baseLayerInput.Text + ">");
                sb.Append("BaseLayerInfo");
                sb.Append("</" + baseLayerInput.Text + ">\n");
            }

            if (mapLayerCheckBoxMiddleLayer.Checked)
            {
                sb.Append("     <" + middleLayerInput.Text + ">");
                sb.Append("MiddleLayer");
                sb.Append("</" + middleLayerInput.Text + ">\n");
            }

            if (mapLayerCheckBoxTopLayer.Checked)
            {
                sb.Append("     <" + topLayerInput.Text + ">");
                sb.Append("TopLayerInfo");
                sb.Append("</" + topLayerInput.Text + ">\n");
            }

            if (mapLayerCheckBoxAtmosphereLayer.Checked)
            {
                sb.Append("     <" + atmosphereLayerInput.Text + ">");
                sb.Append("AtmosphereLayerInfo");
                sb.Append("</" + atmosphereLayerInput.Text + ">\n");
            }

            if (mapLayerCheckBoxCollisionLayer.Checked)
            {
                sb.Append("     <" + collisionLayerInput.Text + ">");
                sb.Append("CollisionLayerInfo");
                sb.Append("</" + collisionLayerInput.Text + ">\n");
            }
        }

        private void mapLayersBaseElement_TextChanged(object sender, EventArgs e)
        {
            ChangeMapLayersOutput();
        }

        private void baseLayerInput_TextChanged(object sender, EventArgs e)
        {
            ChangeMapLayersOutput();
        }

        private void middleLayerInput_TextChanged(object sender, EventArgs e)
        {
            ChangeMapLayersOutput();
        }

        private void topLayerInput_TextChanged(object sender, EventArgs e)
        {
            ChangeMapLayersOutput();
        }

        private void atmosphereLayerInput_TextChanged(object sender, EventArgs e)
        {
            ChangeMapLayersOutput();
        }

        private void collisionLayerInput_TextChanged(object sender, EventArgs e)
        {
            ChangeMapLayersOutput();
        }
        #endregion


        
    }
}