using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SandTileEngine
{
    /// <summary>
    /// Handles all of the exporting of custom map data
    /// </summary>
    public class Exporter
    {
        #region Exporter Data
        /// <summary>
        /// The Exported file name for the XML Document
        /// </summary>
        string xmlExportedFileName = "testFileName.xml";

        /// <summary>
        /// The Exported file name for the XML Document
        /// </summary>
        public string XmlExportedFileName
        {
            get { return xmlExportedFileName; }
            set { xmlExportedFileName = value; }
        }

        /// <summary>
        /// The namespace of the projects Map Content Reader
        /// </summary>
        string projectDataNamespace = "ProjectsGameData";

        /// <summary>
        /// The namespace of the projects Map Content Reader
        /// </summary>
        public string ProjectDataNamespace
        {
            get { return projectDataNamespace; }
            set { projectDataNamespace = value; }
        }

        /// <summary>
        /// The Class Name of the projects Map Class
        /// </summary>
        string projectMapClassName = "MapClassName";

        /// <summary>
        /// The Class Name of the projects Map Class
        /// </summary>
        public string ProjectMapClassName
        {
            get { return projectMapClassName; }
            set { projectMapClassName = value; }
        }

        #endregion

        /// <summary>
        /// TODO: Currently this option is un-used. When the time comes
        /// to allow users to customize their export settings, this section
        /// will be implimented
        /// </summary>
        #region Export To Single / Multi Array

        bool exportToSingleDimensional = false;
        bool exportToMultiDimensional = true;

        /// <summary>
        /// Gets / Sets the exporter to export
        /// a Single-Dimensional (int[]) Array
        /// </summary>
        public bool ExportToSingleDimensional
        {
            get { return exportToSingleDimensional; }
            set
            {
                //set array
                exportToSingleDimensional = value;

                //if this array is true, toggle other to false
                if (value == true)
                    exportToMultiDimensional = false;
                else
                    exportToMultiDimensional = true;
            }
        }

        /// <summary>
        /// Gets / Sets the exporter to export
        /// a Multi-Dimensional (int[,]) Array
        /// </summary>
        public bool ExportToMultiDimensional
        {
            get { return exportToMultiDimensional; }
            set
            {
                //set array
                exportToMultiDimensional = value;

                //if this array is true, toggle other to false
                if (value == true)
                    exportToSingleDimensional = false;
                else
                    exportToSingleDimensional = true;
            }
        }

        #endregion

        #region Export Xml 
        /// <summary>
        /// Exports the map data to an XML file
        /// </summary>
        public void ExportXml(string fileName, TileMap tileMap)
        {
            //Splits the 5 layers out of the TileMap and
            //calls the ExportXml method

            //ExportXml(fileName,
            //    tileMap.BaseLayer,
            //    tileMap.MiddleLayer,
            //    tileMap.TopLayer,
            //    tileMap.AtmosphereLayer,
            //    tileMap.CollisionLayer);
        }

        /// <summary>
        /// Exports the map data to an XML file
        /// </summary>
        public void ExportXml(string fileName,
            TileLayer baseLayer,
            TileLayer middleLayer,
            TileLayer topLayer,
            TileLayer atmosphereLayer,
            TileLayer collisionLayer)
        {
            XmlDocument xmlDoc = new XmlDocument();

            //try to write the file, and if things go wrong
            //write an entry in error log
            try
            {
                #region Xml Writer
                XmlTextWriter xmlWriter = new XmlTextWriter(xmlExportedFileName, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                xmlWriter.WriteStartElement("XnaContent");
                xmlWriter.Close();
                xmlDoc.Load(xmlExportedFileName);
                #endregion

                #region Root Element / Asset Node
                XmlNode root = xmlDoc.DocumentElement;
                XmlElement assetNode = xmlDoc.CreateElement("Asset");
                assetNode.SetAttribute("Type", ProjectDataNamespace + "." + ProjectMapClassName);
                root.AppendChild(assetNode);
                #endregion

                #region Map Details
                CreateComment(xmlDoc, assetNode, "Basic Map Details");
                CreateElementMapName(xmlDoc, assetNode);
                CreateElementMapDimensions(xmlDoc, assetNode);
                CreateElementTileSheet(xmlDoc, assetNode);
                CreateElementTileDimensions(xmlDoc, assetNode);
                #endregion

                #region Map Layers
                //Map Layers comment
                CreateComment(xmlDoc, assetNode, "Map Layers");

                //comment "Map Layers"
                CreateElementLayerInformation(xmlDoc, assetNode,
                    "BaseLayer", baseLayer);

                CreateElementLayerInformation(xmlDoc, assetNode,
                    "MiddleLayer", middleLayer);

                CreateElementLayerInformation(xmlDoc, assetNode,
                    "TopLayer", topLayer);

                CreateElementLayerInformation(xmlDoc, assetNode,
                    "AtmosphereLayer", atmosphereLayer);

                CreateElementLayerInformation(xmlDoc, assetNode,
                    "CollisionLayer", collisionLayer);
                #endregion

                xmlDoc.Save(xmlExportedFileName);
            }
            catch (Exception ex)
            {
                WriteError(ex.ToString());
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Writes an error message to a debug log file
        /// </summary>        
        private void WriteError(string error)
        {
            //Writes the error message to a log file.
            ErrorLog.WriteErrorMessage(error);
        }

        /// <summary>
        /// Creates a comment line in the XML file
        /// </summary>
        private void CreateComment(XmlDocument xmlDoc, XmlElement assetNode,
                                                      string comment)
        {
            XmlComment commentElement = xmlDoc.CreateComment(comment);
            assetNode.AppendChild(commentElement);
        }


        /// <summary>
        /// Creates the XML Element for the Map Name
        /// </summary>
        private void CreateElementMapName(XmlDocument xmlDoc, XmlElement assetNode)
        {
            XmlElement mapName = xmlDoc.CreateElement("Name");
            mapName.InnerText = "InsertMapName";
            assetNode.AppendChild(mapName);
        }

        /// <summary>
        /// Creates the XML Element for the Map Dimensions
        /// </summary>
        private void CreateElementMapDimensions(XmlDocument xmlDoc, XmlElement assetNode)
        {
            XmlElement mapDimensions = xmlDoc.CreateElement("MapDimensions");
            mapDimensions.InnerText = "X Y";
            assetNode.AppendChild(mapDimensions);
        }

        /// <summary>
        /// Creates the XML Element for the TileSheet
        /// </summary>
        private void CreateElementTileSheet(XmlDocument xmlDoc, XmlElement assetNode)
        {
            XmlElement tileSheetContentName = xmlDoc.CreateElement("TileSheetContentName");
            tileSheetContentName.InnerText = "TextureDirectoryAndPath";
            assetNode.AppendChild(tileSheetContentName);
        }

        /// <summary>
        /// Creates the XML Element for the Tile Dimensions
        /// </summary>
        private void CreateElementTileDimensions(XmlDocument xmlDoc, XmlElement assetNode)
        {
            XmlElement tileDimensions = xmlDoc.CreateElement("TileDimensions");
            tileDimensions.InnerText = "X Y";
            assetNode.AppendChild(tileDimensions);
        }

        /// <summary>
        /// Creates the XML Element for a tile layer
        /// </summary>
        private void CreateElementLayerInformation(XmlDocument xmlDoc, XmlElement assetNode,
                                                          string layerName, TileLayer tileLayer)
        {
            XmlElement layerElement = xmlDoc.CreateElement(layerName);
            layerElement.InnerText = "InsertLayerInformationHere";
            assetNode.AppendChild(layerElement);
        }
        #endregion
    }
}
