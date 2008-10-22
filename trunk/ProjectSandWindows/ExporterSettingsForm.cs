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
    public partial class ExporterSettingsForm : Form
    {
        #region Constructor(s)
        public ExporterSettingsForm()
        {
            InitializeComponent();
            LoadExporterSettings();
        }
        #endregion

        #region Load / Save settings
        /// <summary>
        /// Loads the settings already entered for the ExporterForm
        /// if any previous settings have been entered.
        /// </summary>
        private void LoadExporterSettings()
        {
            ExporterSettings settings = ExporterSettings.Settings;
            settings = settings.DeSerializeExporterSettings();

            xmlFileNameInput.Text = settings.XmlFileName.Replace(".xml", "");
            projectDataNamespaceInput.Text = settings.ProjectDataNamespace;
            projectMapClassInput.Text = settings.ProjectMapClassName;

            exportMapNameCheckBox.Checked = settings.ExportMapName;
            mapNameInput.Text = settings.ElementMapName;


            if (settings.DataStyleMapDimensions == ExportDataStyle.Point)
                mapDimensionsPointButton.Checked = true;
            else if (settings.DataStyleMapDimensions == ExportDataStyle.Custom)
                mapDimensionsCustomButton.Checked = true;

            exportMapDimensionsCheckBox.Checked = settings.ExportMapDimensions;
            mapDimensionsInput.Text = settings.ElementMapDimensions;
            mapDimensionsWidthInput.Text = settings.ElementMapWidth;
            mapDimensionsHeightInput.Text = settings.ElementMapHeight;
            exportTileSheetCheckBox.Checked = settings.ExportTileSheet;
            tileSheetContentInput.Text = settings.ElementTileSheet;

            if (settings.DataStyleTileDimensions == ExportDataStyle.Point)
                tileDimensionsPointButton.Checked = true;
            else if (settings.DataStyleTileDimensions == ExportDataStyle.Custom)
                tileDimensionsCustomButton.Checked = true;

            exportTileDimensionsCheckBox.Checked = settings.ExportTileDimensions;
            tileDimensionsInput.Text = settings.ElementTileDimensions;
            tileDimensionsWidthInput.Text = settings.ElementTileWidth;
            tileDimensionsHeightInput.Text = settings.ElementTileHeight;

            if (settings.DataStyleMapLayers == ExportDataStyle.Grouped)
                mapLayersGroupedButton.Checked = true;
            else if (settings.DataStyleMapLayers == ExportDataStyle.Individual)
                mapLayersIndividualButton.Checked = true;

            mapLayerCheckBoxBaseLayer.Checked = settings.ExportBaseLayer;
            mapLayerCheckBoxMiddleLayer.Checked = settings.ExportMiddleLayer;
            mapLayerCheckBoxTopLayer.Checked = settings.ExportTopLayer;
            mapLayerCheckBoxAtmosphereLayer.Checked = settings.ExportAtmosphereLayer;
            mapLayerCheckBoxCollisionLayer.Checked = settings.ExportCollisionLayer;

            baseLayerInput.Text = settings.ElementBaseLayer;
            middleLayerInput.Text = settings.ElementMiddleLayer;
            topLayerInput.Text = settings.ElementTopLayer;
            atmosphereLayerInput.Text = settings.ElementAtmosphereLayer;
            collisionLayerInput.Text = settings.ElementCollisionLayer;

        }

        private void SetExportSettings()
        {
            ExporterSettings settings = ExporterSettings.Settings;


            settings.XmlFileName = xmlFileNameInput.Text + ".xml";
            settings.ProjectDataNamespace = projectDataNamespaceInput.Text;
            settings.ProjectMapClassName = projectMapClassInput.Text;

            settings.ExportMapName = exportMapNameCheckBox.Checked;
            settings.ElementMapName = mapNameInput.Text;



            if (mapDimensionsPointButton.Checked)
                settings.DataStyleMapDimensions = ExportDataStyle.Point;
            else if (mapDimensionsCustomButton.Checked)
                settings.DataStyleMapDimensions = ExportDataStyle.Custom;

            settings.ExportMapDimensions = exportMapDimensionsCheckBox.Checked;
            settings.ElementMapDimensions = mapDimensionsInput.Text;
            settings.ElementMapWidth = mapDimensionsWidthInput.Text;
            settings.ElementMapHeight = mapDimensionsHeightInput.Text;

            settings.ExportTileSheet = exportTileSheetCheckBox.Checked;
            settings.ElementTileSheet = tileSheetContentInput.Text;



            if (tileDimensionsPointButton.Checked)
                settings.DataStyleTileDimensions = ExportDataStyle.Point;
            else if (tileDimensionsCustomButton.Checked)
                settings.DataStyleTileDimensions = ExportDataStyle.Custom;

            settings.ExportTileDimensions = exportTileDimensionsCheckBox.Checked;
            settings.ElementTileDimensions = tileDimensionsInput.Text;
            settings.ElementTileWidth = tileDimensionsWidthInput.Text;
            settings.ElementTileHeight = tileDimensionsHeightInput.Text;


            if (mapLayersGroupedButton.Checked)
                settings.DataStyleMapLayers = ExportDataStyle.Grouped;
            else if (mapLayersIndividualButton.Checked)
                settings.DataStyleMapLayers = ExportDataStyle.Individual;

            settings.ExportBaseLayer = mapLayerCheckBoxBaseLayer.Checked;
            settings.ExportMiddleLayer = mapLayerCheckBoxMiddleLayer.Checked;
            settings.ExportTopLayer = mapLayerCheckBoxTopLayer.Checked;
            settings.ExportAtmosphereLayer = mapLayerCheckBoxAtmosphereLayer.Checked;
            settings.ExportCollisionLayer = mapLayerCheckBoxCollisionLayer.Checked;

            settings.ElementBaseLayer = baseLayerInput.Text;
            settings.ElementMiddleLayer = middleLayerInput.Text;
            settings.ElementTopLayer = topLayerInput.Text;
            settings.ElementAtmosphereLayer = atmosphereLayerInput.Text;
            settings.ElementCollisionLayer = collisionLayerInput.Text;

            settings.SerializeExporterSettings();
        }
        #endregion

        #region Xna Data

        private void ChangeXnaDataOutputText(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Filename: " + xmlFileNameInput.Text + ".xml\n\n");
            sb.Append("<XnaContent>\n");
            sb.Append("     <Asset Type=\"" + projectDataNamespaceInput.Text + ".");
            sb.Append(projectMapClassInput.Text + "\">\n\n");
            sb.Append("     </Asset>\n");
            sb.Append("</XnaContent>\n");
            xnaDataOutput.Text = sb.ToString();
        }
        #endregion

        #region Map Name
        private void ChangeMapNameOutputText(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<" + mapNameInput.Text + ">");
            sb.Append("MapName");
            sb.Append("</" + mapNameInput.Text + ">");

            mapNameOutput.Text = sb.ToString();
        }
        #endregion

        #region Map Dimensions
        private void ChangeMapDimensionsOutputText(object sender, EventArgs e)
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
        #endregion

        #region Tile Sheet
        private void ChangeTileSheetOutputText(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<" + tileSheetContentInput.Text + ">");
            sb.Append("ProjectsContentPath//TileSheet");
            sb.Append("</" + tileSheetContentInput.Text + ">");

            tileSheetOutput.Text = sb.ToString();
        }
        #endregion

        #region Tile Dimensions
        private void ChangeTileDimensionsOutputText(object sender, EventArgs e)
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
        #endregion

        #region Map Layers
        private void ChangeMapLayersOutputText(object sender, EventArgs e)
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
        #endregion    

        #region On Form Closing
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            SetExportSettings();
        }
        #endregion
    }
}