using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SandTileEngine
{
    /// <summary>
    /// This class houses the basic settings of all exported content
    /// </summary>
    public class ExporterSettings
    {
        #region Singlton
        public static ExporterSettings Settings;

        public static void Initialize()
        {
            Settings = new ExporterSettings();
        }
        #endregion

        public string XmlFileName = string.Empty;
        public string ProjectMapClassName = string.Empty;
        public string ProjectDataNamespace = string.Empty;

        public bool ExportMapName = true;
        public string ElementMapName = string.Empty;

        public bool ExportMapDimensions = true;
        public ExportDataStyle DataStyleMapDimensions = ExportDataStyle.Point;
        public string ElementMapDimensions = string.Empty;
        public string ElementMapWidth = string.Empty;
        public string ElementMapHeight = string.Empty;

        public bool ExportTileSheet = true;
        public string ElementTileSheet = string.Empty;

        public bool ExportTileDimensions = true;
        public ExportDataStyle DataStyleTileDimensions = ExportDataStyle.Point;
        public string ElementTileDimensions = string.Empty;
        public string ElementTileWidth = string.Empty;
        public string ElementTileHeight = string.Empty;



        public bool ExportBaseLayer = true;
        public bool ExportMiddleLayer = true;
        public bool ExportTopLayer = true;
        public bool ExportAtmosphereLayer = true;
        public bool ExportCollisionLayer = true;

        public ExportDataStyle DataStyleMapLayers = ExportDataStyle.Individual;
        public string ElementMapLayers = string.Empty;
        public string ElementBaseLayer = string.Empty;
        public string ElementMiddleLayer = string.Empty;
        public string ElementTopLayer = string.Empty;
        public string ElementAtmosphereLayer = string.Empty;
        public string ElementCollisionLayer = string.Empty;
    }
}
