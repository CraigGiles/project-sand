using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;

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

        #region Export Xml 
        /// <summary>
        /// Exports the map data to an XML file
        /// </summary>
        public void ExportXml(string fileName, TileMap tileMap)
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

                CreateElementMapName(xmlDoc, assetNode, tileMap.Name);

                CreateElementMapDimensions(xmlDoc, assetNode, 
                    tileMap.MapWidth, tileMap.MapHeight);

                CreateElementTileSheet(xmlDoc, assetNode);

                CreateElementTileDimensions(xmlDoc, assetNode,
                    tileMap[0].Width, tileMap[0].Height);
                #endregion

                #region Map Layers
                //Map Layers comment
                CreateComment(xmlDoc, assetNode, "Map Layers");
                
                //comment "Map Layers"
                //CreateElementLayerInformation(xmlDoc, assetNode,
                //    "BaseLayer", tileMap[0].Matrix);

                //CreateElementLayerInformation(xmlDoc, assetNode,
                //    "MiddleLayer", tileMap[1].Matrix);

                //CreateElementLayerInformation(xmlDoc, assetNode,
                //    "TopLayer", tileMap[2].Matrix);

                //CreateElementLayerInformation(xmlDoc, assetNode,
                //    "AtmosphereLayer", tileMap[3].Matrix);

                //CreateElementLayerInformation(xmlDoc, assetNode,
                //    "CollisionLayer", tileMap[4].Matrix);
                #endregion

                xmlDoc.Save(xmlExportedFileName);
            }
            catch (Exception ex)
            {
                WriteError(ex.ToString());
            }
        }

        #endregion

        #region Write To Error Log
        /// <summary>
        /// Writes an error message to a debug log file
        /// </summary>        
        private void WriteError(string error)
        {
            //Writes the error message to a log file.
            ErrorLog.WriteErrorMessage(error);
        }
        #endregion

        #region Comment
        /// <summary>
        /// Creates a comment line in the XML file
        /// </summary>
        private void CreateComment(XmlDocument xmlDoc, XmlElement assetNode,
                                                      string comment)
        {
            XmlComment commentElement = xmlDoc.CreateComment(comment);
            assetNode.AppendChild(commentElement);
        }
        #endregion

        #region Map Name

        /// <summary>
        /// The Tag used for the Map Name element
        /// </summary>
        string elementNameMapName = "Name";

        /// <summary>
        /// The Tag used for the Map Name element
        /// </summary>
        public string ElementNameMapName
        {
            get { return elementNameMapName; }
            set { elementNameMapName = value; }
        }

        /// <summary>
        /// Creates the XML Element for the Map Name
        /// </summary>
        private void CreateElementMapName(XmlDocument xmlDoc, XmlElement assetNode,
                                                        string mapName)
        {
            XmlElement nameElement = xmlDoc.CreateElement(ElementNameMapName);
            nameElement.InnerText = mapName;
            assetNode.AppendChild(nameElement);
        }
        #endregion

        #region Map Dimensions

        /// <summary>
        /// The Tag used for the Map Dimensions element
        /// </summary>
        string elementNameMapDimensions = "MapDimensions";

        /// <summary>
        /// The Tag used for the Map Dimensions element
        /// </summary>
        public string ElementNameMapDimensions
        {
            get { return elementNameMapDimensions; }
            set { elementNameMapDimensions = value; }
        }

        /// <summary>
        /// Creates the XML Element for the Map Dimensions
        /// </summary>
        private void CreateElementMapDimensions(XmlDocument xmlDoc, XmlElement assetNode,
                                                int width, int height)
        {
            XmlElement mapDimensions = xmlDoc.CreateElement(ElementNameMapDimensions);
            mapDimensions.InnerText = width.ToString() + " " + height.ToString();
            assetNode.AppendChild(mapDimensions);
        }

        #endregion

        #region Tile Sheet

        /// <summary>
        /// The Tag used for the TileSheet element
        /// </summary>
        string elementNameTileSheet = "TileSheetContentName";

        /// <summary>
        /// The Tag used for the TileSheet element
        /// </summary>
        public string ElementNameTileSheet
        {
            get { return elementNameTileSheet; }
            set { elementNameTileSheet = value; }
        }

        /// <summary>
        /// Creates the XML Element for the TileSheet
        /// </summary>
        private void CreateElementTileSheet(XmlDocument xmlDoc, XmlElement assetNode)
        {
            XmlElement tileSheetContentName = xmlDoc.CreateElement(ElementNameTileSheet);
            tileSheetContentName.InnerText = "TextureDirectoryAndPath";
            assetNode.AppendChild(tileSheetContentName);
        }

        #endregion

        #region Tile Dimensions

        /// <summary>
        /// The Tag used for the Tile Dimensions element
        /// </summary>
        string elementNameTileDimensions = "TileDimensions";

        /// <summary>
        /// The Tag used for the Tile Dimensions element
        /// </summary>
        public string ElementNameTileDimensions
        {
            get { return elementNameTileDimensions; }
            set { elementNameTileDimensions = value; }
        }

        /// <summary>
        /// Creates the XML Element for the Tile Dimensions
        /// </summary>
        private void CreateElementTileDimensions(XmlDocument xmlDoc, XmlElement assetNode,
                                                 int tileWidth, int tileHeight)
        {
            XmlElement tileDimensions = xmlDoc.CreateElement(ElementNameTileDimensions);
            tileDimensions.InnerText = tileWidth.ToString() + " " + tileHeight.ToString();
            assetNode.AppendChild(tileDimensions);
        }

        #endregion

        #region Layer Information

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
        
        #region Export Value Specific Data

        #region Point

        /// <summary>
        /// Exports Point data to the Xml Document
        /// </summary>
        public void ExportPointData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, Point point)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = point.X.ToString() + " " + point.Y.ToString();
            assetNode.AppendChild(element);
        }

        /// <summary>
        /// Exports a list of points to the Xml Document
        /// </summary>
        public static void ExportPointData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, List<Point> points)
        {
            string data = "\n";
            foreach (Point point in points)
            {
                data += point.X.ToString() + " " + point.Y.ToString() + '\n';
            }

            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = data;
            assetNode.AppendChild(element);
        }

        #endregion

        #region Int

        /// <summary>
        /// Exports an int32 data to the Xml Document
        /// </summary>
        public void ExportIntData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, int value)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = value.ToString();
            assetNode.AppendChild(element);
        }

        /// <summary>
        /// Exports a list of Int32s to the Xml Document
        /// </summary>
        public void ExportIntData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, List<int> values)
        {
            string data = "\n";
            foreach (int value in values)
            {
                data += value.ToString() + "\n";
            }

            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = data;
            assetNode.AppendChild(element);
        }

        /// <summary>
        /// Exports an int array to the Xml Document
        /// </summary>
        public void ExportIntData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, int[] value)
        {
            string data = string.Empty;

            for (int i = 0; i < value.Length; i++)
            {
                data += value[i].ToString() + " ";
            }

            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = value.ToString();
            assetNode.AppendChild(element);
        }
        #endregion

        #region Vector2
        /// <summary>
        /// Exports Vector2 data to the Xml Document
        /// </summary>
        public void ExportVectorData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, Vector2 vector)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = vector.X.ToString() + " " + vector.Y.ToString();
            assetNode.AppendChild(element);
        }

        /// <summary>
        /// Exports a list of Vector2s to the Xml Document
        /// </summary>
        public static void ExportVectorData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, List<Vector2> vectors)
        {
            string data = "\n";
            foreach (Vector2 vector in vectors)
            {
                data += vector.X.ToString() + " " + vector.Y.ToString() + '\n';
            }

            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = data;
            assetNode.AppendChild(element);
        }
        #endregion

        #region Vector3

        /// <summary>
        /// Exports Vector3 data to the Xml Document
        /// </summary>
        public void ExportVectorData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, Vector3 vector)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = vector.X.ToString() + " " + vector.Y.ToString() +
                vector.Z.ToString();
            assetNode.AppendChild(element);
        }

        /// <summary>
        /// Exports a list of Vector3s to the Xml Document
        /// </summary>
        public static void ExportVectorData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, List<Vector3> vectors)
        {
            string data = "\n";
            foreach (Vector3 vector in vectors)
            {
                data += vector.X.ToString() + " " + vector.Y.ToString() + vector.Z.ToString() + '\n';
            }

            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = data;
            assetNode.AppendChild(element);
        }

        #endregion

        #region Rectangle
        /// <summary>
        /// Exports Rectangle data to the Xml Document
        /// </summary>
        public void ExportVectorData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, Rectangle rectangle)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText =
                rectangle.X.ToString() + " " +
                rectangle.Y.ToString() + " " +
                rectangle.Width.ToString() + " " +
                rectangle.Height.ToString() + " ";

            assetNode.AppendChild(element);
        }

        /// <summary>
        /// Exports a list of Rectangles to the Xml Document
        /// </summary>
        public static void ExportVectorData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, List<Rectangle> rectangles)
        {
            string data = "\n";
            foreach (Rectangle rectangle in rectangles)
            {
                data +=
                    rectangle.X.ToString() + " " +
                    rectangle.Y.ToString() + " " +
                    rectangle.Width.ToString() + " " +
                    rectangle.Height.ToString() + " " + "\n";
            }

            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = data;
            assetNode.AppendChild(element);
        }
        #endregion

        #region Bool
        /// <summary>
        /// Exports an bool statement to the Xml Document
        /// </summary>
        public void ExportBoolData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, bool value)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = value.ToString();
            assetNode.AppendChild(element);
        }

        /// <summary>
        /// Exports a list of Bools to the Xml Document
        /// </summary>
        public void ExportBoolData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, List<bool> values)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);

            foreach (bool value in values)
            {
                XmlElement node = xmlDoc.CreateElement("Item");
                node.InnerText = value.ToString();
                element.AppendChild(node);
            }

            assetNode.AppendChild(element);
        }
        #endregion

        #region String
        /// <summary>
        /// Exports an string statement to the Xml Document
        /// </summary>
        public void ExportStringData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, string value)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = value;
            assetNode.AppendChild(element);
        }

        /// <summary>
        /// Exports a list of string to the Xml Document
        /// </summary>
        public void ExportStringData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, List<string> values)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);

            foreach (string value in values)
            {
                XmlElement node = xmlDoc.CreateElement("Item");
                node.InnerText = value;
                element.AppendChild(node);
            }

            assetNode.AppendChild(element);
        }
        #endregion

        #endregion
    }
}
