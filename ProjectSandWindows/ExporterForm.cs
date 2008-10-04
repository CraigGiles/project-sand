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
            mapNameOutput.Text = "<" + mapNameInput.Text + ">" + 
                                 "MapName" + 
                                 "</" + mapNameInput.Text + ">";
        }
        #endregion

        #region Map Dimensions
        private void ChangeMapDimensionsOutputText()
        {
            if (mapDimensionsPointButton.Checked)
            {
                mapDimensionsOutput.Text =
                    "<" + mapDimensionsInput.Text + ">" +
                    "X Y" +
                    "</" + mapDimensionsInput.Text + ">";
            }
            else if (mapDimensionsCustomButton.Checked)
            {
                mapDimensionsOutput.Text =
                    "<" + mapDimensionsInput.Text + ">\n" +
                        "     <" + mapDimensionsWidthInput.Text + ">" +
                            "X" +
                        "</" + mapDimensionsWidthInput.Text + ">\n" +
                        "     <" + mapDimensionsHeightInput.Text + ">" +
                            "Y" +
                        "</" + mapDimensionsHeightInput.Text + ">\n" +
                    "</" + mapDimensionsInput.Text + ">";
            }
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
            tileSheetOutput.Text = 
                "<" + tileSheetContentInput.Text + ">" +
                "Content//Textures//TextureName" +
                "</" + tileSheetContentInput.Text + ">";
        }
        #endregion

        #region Tile Dimensions
        private void ChangeTileDimensionsOutputText()
        {
            if (tileDimensionsPointButton.Checked)
            {
                tileDimensionsOutput.Text =
                    "<" + tileDimensionsInput.Text + ">" +
                    "X Y" +
                    "</" + tileDimensionsInput.Text + ">";
            }
            else if (tileDimensionsCustomButton.Checked)
            {
                tileDimensionsOutput.Text =
                    "<" + tileDimensionsInput.Text + ">\n" +
                        "     <" + tileDimensionsWidthInput.Text + ">" +
                            "X" +
                        "</" + tileDimensionsWidthInput.Text + ">\n" +
                        "     <" + tileDimensionsHeightInput.Text + ">" +
                            "Y" +
                        "</" + tileDimensionsHeightInput.Text + ">\n" +
                    "</" + tileDimensionsInput.Text + ">";
            }
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
        private void baseLayerInput_TextChanged(object sender, EventArgs e)
        {
            baseLayerOutput.Text = 
                "<" + baseLayerInput.Text + ">" +
                "LayerInformation" +
                "</" + baseLayerInput.Text + ">";
        }

        private void middleLayerInput_TextChanged(object sender, EventArgs e)
        {
            middleLayerOutput.Text =
                "<" + middleLayerInput.Text + ">" +
                "LayerInformation" +
                "</" + middleLayerInput.Text + ">";
        }

        private void topLayerInput_TextChanged(object sender, EventArgs e)
        {
            topLayerOutput.Text =
                "<" + topLayerInput.Text + ">" +
                "LayerInformation" +
                "</" + topLayerInput.Text + ">";
        }

        private void atmosphereLayerInput_TextChanged(object sender, EventArgs e)
        {
            atmosphereLayerOutput.Text =
                "<" + atmosphereLayerInput.Text + ">" +
                "LayerInformation" +
                "</" + atmosphereLayerInput.Text + ">";
        }

        private void collisionLayerInput_TextChanged(object sender, EventArgs e)
        {
            collisionLayerOutput.Text =
                "<" + collisionLayerInput.Text + ">" +
                "LayerInformation" +
                "</" + collisionLayerInput.Text + ">";
        }
        #endregion
    }
}