using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SandTileEngine
{
    /// <summary>
    /// This class houses the basic settings of all exported content
    /// </summary>
    [Serializable]
    public class ExporterSettings
    {
        #region Singlton
        public static ExporterSettings Settings;

        public static void Initialize()
        {
            Settings = new ExporterSettings();
        }
        #endregion

        public string XmlFileName = "xmlFileName";
        public string ProjectMapClassName = "ProjectMapClassName";
        public string ProjectDataNamespace = "ProjectDataNamespace";

        public bool ExportMapName = true;
        public string ElementMapName = "ProjectDataNamespace";

        public bool ExportMapDimensions = true;
        public ExportDataStyle DataStyleMapDimensions = ExportDataStyle.Point;
        public string ElementMapDimensions = "MapDimensions";
        public string ElementMapWidth = "Width";
        public string ElementMapHeight = "Height";

        public bool ExportTileSheet = true;
        public string ElementTileSheet = "TileSheetContentName";

        public bool ExportTileDimensions = true;
        public ExportDataStyle DataStyleTileDimensions = ExportDataStyle.Point;
        public string ElementTileDimensions = "TileDimensions";
        public string ElementTileWidth = "Width";
        public string ElementTileHeight = "Height";



        public bool ExportBaseLayer = true;
        public bool ExportMiddleLayer = true;
        public bool ExportTopLayer = true;
        public bool ExportAtmosphereLayer = true;
        public bool ExportCollisionLayer = true;

        public ExportDataStyle DataStyleMapLayers = ExportDataStyle.Individual;
        public string ElementMapLayers = "MapLayers";
        public string ElementBaseLayer = "BaseLayer";
        public string ElementMiddleLayer = "MiddleLayer";
        public string ElementTopLayer = "TopLayer";
        public string ElementAtmosphereLayer = "AtmosphereLayer";
        public string ElementCollisionLayer = "CollisionLayer";

        public void SerializeExporterSettings()
        {
            //Try to open the file and write the settings
            //if the file does not exist, create the directory
            //and the file, then write settings
            try
            {
                Stream stream = File.Open("ExporterSettings//Settings.bin", FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, this);
                stream.Close();
            }
            catch
            {
                System.IO.Directory.CreateDirectory("ExporterSettings//");
                Stream stream = File.Open("ExporterSettings//Settings.bin", FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, this);
                stream.Close();
            }
        }

        public ExporterSettings DeSerializeExporterSettings()
        {
            //If the settings.bin exists, open it and return it
            //to the program. If it doesn't exist, create a new one 
            //and return it to the program.
            try
            {
                ExporterSettings settings;
                Stream stream = File.Open("ExporterSettings//Settings.bin", FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                settings =
                   (ExporterSettings)bFormatter.Deserialize(stream);
                stream.Close();
                return settings;
            }
            catch (Exception ex)
            {
                string text = ex.ToString();
                return new ExporterSettings();
            }
        }
    }
}
