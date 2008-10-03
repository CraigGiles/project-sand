using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;

namespace SandTileEngine
{
    public enum ExportDataStyle
    {
        Point,
        Vector2,
        Custom,
    }

    /// <summary>
    /// Handles all of the exporting of custom map data
    /// </summary>
    public class Exporter
    {
        /* * * * * * * * *
         * All names associated with the current map
         * that needs to be exported to the XML file
         * * * * * * * * */

        #region XML File Name 
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
        #endregion

        #region Project Namespace / Class Name
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

        #region Map Name

        /// <summary>
        /// Should the exported XML file contain the Map Name
        /// </summary>
        bool exportMapName = true;

        /// <summary>
        /// Should the exported XML file contain the Map Name
        /// </summary>
        public bool ExportMapName
        {
            get { return exportMapName; }
            set { exportMapName = value; }
        }

        /// <summary>
        /// Name of map being exported
        /// </summary>
        string mapNameElementName = string.Empty;

        /// <summary>
        /// Name of map being exported
        /// </summary>
        public string MapNameElementName
        {
            get { return mapNameElementName; }
            set { mapNameElementName = value; }
        }
        #endregion

        #region Map Dimensions
        /// <summary>
        /// How is this data going to be exported to the XML document
        /// </summary>
        ExportDataStyle mapDimensionsExportStyle = ExportDataStyle.Point;

        /// <summary>
        /// How is this data going to be exported to the XML document
        /// </summary>
        public ExportDataStyle MapDimensionsExportStyle
        {
            get { return mapDimensionsExportStyle; }
            set { mapDimensionsExportStyle = value; }
        }

        /// <summary>
        /// Should the exported XML file contain the Map Dimensions
        /// </summary>
        bool exportMapDimensions = true;

        /// <summary>
        /// Should the exported XML file contain the Map Dimensions
        /// </summary>
        public bool ExportMapDimensions
        {
            get { return exportMapDimensions; }
            set { exportMapDimensions = value; }
        }

        /// <summary>
        /// Element name of the Map Dimensions element
        /// </summary>
        string mapDimensionsElementName = string.Empty;

        /// <summary>
        /// Element name of hte Map Dimensions element
        /// </summary>
        public string MapDimensionsElementName
        {
            get { return mapDimensionsElementName; }
            set { mapDimensionsElementName = value; }
        }

        /// <summary>
        /// Element name of the Map Dimensions > Width element
        /// </summary>
        string mapDimensionsWidthName = string.Empty;

        /// <summary>
        /// Element name of the Map Dimensions > Width element
        /// </summary>
        public string MapDimensionsWidthName
        {
            get { return mapDimensionsWidthName; }
            set { mapDimensionsWidthName = value; }
        }

        /// <summary>
        /// Element name of the Map Dimensions > Height element
        /// </summary>
        string mapDimensionsHeightName = string.Empty;

        /// <summary>
        /// Element name of the Map Dimensions > Height element
        /// </summary>
        public string MapDimensionsHeightName
        {
            get { return mapDimensionsHeightName; }
            set { mapDimensionsHeightName = value; }
        }

        #endregion

        #region Tile Sheet

        /// <summary>
        /// Should the exported XML file contain the Tile Sheet
        /// </summary>
        bool exportTileSheet = true;

        /// <summary>
        /// Should the exported XML file contain the Tile Sheet
        /// </summary>
        public bool ExportTileSheet
        {
            get { return exportTileSheet; }
            set { exportTileSheet = value; }
        }

        /// <summary>
        /// Element name used for the Tile Sheet element
        /// </summary>
        string tileSheetElementName = String.Empty;

        /// <summary>
        /// Element name used for the Tile Sheet element
        /// </summary>
        public string TileSheetElementName
        {
            get { return tileSheetElementName; }
            set { tileSheetElementName = value; }
        }

        #endregion
                
        #region Tile Dimensions
        /// <summary>
        /// How is this data going to be exported to the XML document
        /// </summary>
        ExportDataStyle tileDimensionsExportStyle = ExportDataStyle.Point;

        /// <summary>
        /// How is this data going to be exported to the XML document
        /// </summary>
        public ExportDataStyle TileDimensionsExportStyle
        {
            get { return tileDimensionsExportStyle; }
            set { tileDimensionsExportStyle = value; }
        }

        /// <summary>
        /// Should the exported XML file contain the Tile DImensions
        /// </summary>
        bool exportTileDimensions = true;

        /// <summary>
        /// Should the exported XML file contain the Tile Dimensions
        /// </summary>
        public bool ExportTileDimensions
        {
            get { return exportTileDimensions; }
            set { exportTileDimensions = value; }
        }

        /// <summary>
        /// The dimensions of a given tile on the map in pixels
        /// </summary>
        string tileDimensionsElementName = string.Empty;

        /// <summary>
        /// The dimensions of a given tile on the map in pixels
        /// </summary>
        public string TileDimensionsElementName
        {
            get { return tileDimensionsElementName; }
            set { tileDimensionsElementName = value; }
        }

        /// <summary>
        /// The dimensions of a given tile on the map in pixels
        /// </summary>
        string tileDimensionsWidthElementName = string.Empty;

        /// <summary>
        /// The dimensions of a given tile on the map in pixels
        /// </summary>
        public string TileDimensionsWidthElementName
        {
            get { return tileDimensionsWidthElementName; }
            set { tileDimensionsWidthElementName = value; }
        }

        /// <summary>
        /// The dimensions of a given tile on the map in pixels
        /// </summary>
        string tileDimensionsHeightElementName = string.Empty;

        /// <summary>
        /// The dimensions of a given tile on the map in pixels
        /// </summary>
        public string TileDimensionsHeightElementName
        {
            get { return tileDimensionsHeightElementName; }
            set { tileDimensionsHeightElementName = value; }
        }


        #endregion

        #region Layer Information

        /// <summary>
        /// Should the exported XML file contain the Base Layer
        /// </summary>
        bool exportBaseLayer = true;

        /// <summary>
        /// Should the exported XML file contain the Base Layer
        /// </summary>
        public bool ExportBaseLayer
        {
            get { return exportBaseLayer; }
            set { exportBaseLayer = value; }
        }

        /// <summary>
        /// Should the exported XML file contain the Middle Layer
        /// </summary>
        bool exportMiddleLayer = true;

        /// <summary>
        /// Should the exported XML file contain the Middle Layer
        /// </summary>
        public bool ExportMiddleLayer
        {
            get { return exportMiddleLayer; }
            set { exportMiddleLayer = value; }
        }

        /// <summary>
        /// Should the exported XML file contain the Top Layer
        /// </summary>
        bool exportTopLayer = true;

        /// <summary>
        /// Should the exported XML file contain the Top Layer
        /// </summary>
        public bool ExportTopLayer
        {
            get { return exportTopLayer; }
            set { exportTopLayer = value; }
        }

        /// <summary>
        /// Should the exported XML file contain the Atmosphere Layer
        /// </summary>
        bool exportAtmosphereLayer = true;

        /// <summary>
        /// Should the exported XML file contain the Atmosphere Layer
        /// </summary>
        public bool ExportAtmosphereLayer
        {
            get { return exportAtmosphereLayer; }
            set { exportAtmosphereLayer = value; }
        }

        /// <summary>
        /// Should the exported XML file contain the Collision Layer
        /// </summary>
        bool exportCollisionLayer = true;

        /// <summary>
        /// Should the exported XML file contain the Collision Layer
        /// </summary>
        public bool ExportCollisionLayer
        {
            get { return exportCollisionLayer; }
            set { exportCollisionLayer = value; }
        }

        /// <summary>
        /// Xml Element Name used for Base Layer
        /// </summary>
        string baseLayerElementName = String.Empty;

        /// <summary>
        /// Xml Element Name used for Base Layer
        /// </summary>
        public string BaseLayerElementName
        {
            get { return baseLayerElementName; }
            set { baseLayerElementName = value; }
        }

        /// <summary>
        /// Xml Element Name used for Middle Layer
        /// </summary>
        string middleLayerElementName = String.Empty;

        /// <summary>
        /// Xml Element Name used for Middle Layer
        /// </summary>
        public string MiddleLayerElementName
        {
            get { return middleLayerElementName; }
            set { middleLayerElementName = value; }
        }

        /// <summary>
        /// Xml Element Name used for Top Layer
        /// </summary>
        string topLayerElementName = String.Empty;

        /// <summary>
        /// Xml Element Name used for Top Layer
        /// </summary>
        public string TopLayerElementName
        {
            get { return topLayerElementName; }
            set { topLayerElementName = value; }
        }

        /// <summary>
        /// Xml Element Name used for Atmosphere Layer
        /// </summary>
        string atmosphereLayerElementName = String.Empty;

        /// <summary>
        /// Xml Element Name used for Atmosphere Layer
        /// </summary>
        public string AtmosphereLayerElementName
        {
            get { return atmosphereLayerElementName; }
            set { atmosphereLayerElementName = value; }
        }

        /// <summary>
        /// Xml Element Name used for Collision Layer
        /// </summary>
        string collisionLayerElementName = String.Empty;

        /// <summary>
        /// Xml Element Name used for Collision Layer
        /// </summary>
        public string CollisionLayerElementName
        {
            get { return collisionLayerElementName; }
            set { collisionLayerElementName = value; }
        }

        #endregion
        
        /* * * * * * * * *
         * Handles all of the exporting logic for writing
         * the map to an XML file.
         * * * * * * * * */
        
        #region Export Xml

        public void ExportXml(TileMap tileMap)
        {
            XmlDocument doc = new XmlDocument();

            //try to write the file, and if things go wrong
            //write an entry in error log
            try
            {
                #region Xml Writer
                //generate a new XML Writer with correct formatting
                XmlTextWriter xmlWriter = new XmlTextWriter(xmlExportedFileName, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");

                //We want to be able to use this in the XNA Content Pipeline
                xmlWriter.WriteStartElement("XnaContent");
                xmlWriter.Close();

                //load your newly created xml file
                doc.Load(xmlExportedFileName);
                #endregion

                #region Root Element / Asset Node
                //create the root element
                XmlNode root = doc.DocumentElement;

                //The asset describes the type of object being imported
                //through the content pipeline. 
                XmlElement assetNode = doc.CreateElement("Asset");
                assetNode.SetAttribute("Type", ProjectDataNamespace + "." + ProjectMapClassName);
                root.AppendChild(assetNode);
                #endregion

                //Creates a comment displaying which section of the
                //map is being exported. This helps the XML readability.
                CreateComment(doc, assetNode, "Basic Map Details");

                if (exportMapName)
                {
                    ExportStringData(doc, assetNode, MapNameElementName, tileMap.MapName);
                }

                //if user wishes to export map dimensions;
                if (exportMapDimensions)
                {
                    //if user sets exporting map dimensions as point data
                    if (MapDimensionsExportStyle == ExportDataStyle.Point)
                        ExportPointData(doc, assetNode, MapDimensionsElementName, 
                            new Point(tileMap.MapWidth, tileMap.MapHeight));

                    //if user sets exporting map dimensions as custom data
                    else if (MapDimensionsExportStyle == ExportDataStyle.Custom)
                        ExportCustomData(doc, assetNode, TileDimensionsElementName,
                            TileDimensionsWidthElementName, TileDimensionsHeightElementName,
                            new Point(tileMap.MapWidth, tileMap.MapHeight)); 
                }

                if (exportTileSheet)
                {
                    ExportStringData(doc, assetNode, TileSheetElementName, tileMap.TileSheet.FullFileName);
                }

                //if user wishes to export tile dimensions
                if (exportTileDimensions)
                {
                    //if user sets exporting tile dimensions as point data
                    if (TileDimensionsExportStyle == ExportDataStyle.Point)
                        ExportPointData(doc, assetNode, TileDimensionsElementName, 
                            new Point(TileLayer.TileWidth, TileLayer.TileHeight));

                    //if user sets exporting tile dimensions as custom data
                    else if (TileDimensionsExportStyle == ExportDataStyle.Custom)
                        ExportCustomData(doc, assetNode, TileDimensionsElementName,
                            TileDimensionsWidthElementName, TileDimensionsHeightElementName,
                            new Point(
                                tileMap[0].WidthInPixels / tileMap[0].Width,
                                tileMap[0].HeightInPixels / tileMap[0].Height)); 
                }

                //Creates a comment displaying which section of the
                //map is being exported. This helps the XML readability.
                CreateComment(doc, assetNode, "Map Layer Information");

                if (exportBaseLayer)
                {
                    ExportIntData(doc, assetNode, baseLayerElementName,
                        ArrayHelper.ConvertMultiArrayToSingle(tileMap[(int)Layer.BaseLayer].Map));
                }

                if (exportMiddleLayer)
                {
                    ExportIntData(doc, assetNode, middleLayerElementName,
                       ArrayHelper.ConvertMultiArrayToSingle(tileMap[(int)Layer.MiddleLayer].Map));
                }

                if (exportTopLayer)
                {
                    ExportIntData(doc, assetNode, topLayerElementName,
                       ArrayHelper.ConvertMultiArrayToSingle(tileMap[(int)Layer.TopLayer].Map));
                }

                if (exportAtmosphereLayer)
                {
                    ExportIntData(doc, assetNode, atmosphereLayerElementName,
                        ArrayHelper.ConvertMultiArrayToSingle(tileMap[(int)Layer.Atmosphere].Map));
                }

                if (exportCollisionLayer)
                {
                    ExportIntData(doc, assetNode, collisionLayerElementName, 
                        ArrayHelper.ConvertMultiArrayToSingle(tileMap[(int)Layer.CollisionLayer].Map));
                }

                //save the XML document
                doc.Save(xmlExportedFileName);
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
        public void ExportPointData(XmlDocument xmlDoc, XmlElement assetNode,
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

        /// <summary>
        /// Exports a list of individual points to the Xml Document
        /// </summary>
        public void ExportPointData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, params Point[] points)
        {
            List<Point> listOfPoints = new List<Point>();

            foreach (Point point in points)
            {
                listOfPoints.Add(point);
            }

            ExportPointData(xmlDoc, assetNode, elementName, listOfPoints);
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

        /// <summary>
        /// Exports a list of individual Vector2s to the Xml Document
        /// </summary>
        public void ExportVectorData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, params Vector2[] vectors)
        {
            List<Vector2> list = new List<Vector2>();

            foreach (Vector2 vector in vectors)
            {
                list.Add(vector);
            }

            ExportVectorData(xmlDoc, assetNode, elementName, list);
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

        /// <summary>
        /// Exports a list of individual Vector3s to the Xml Document
        /// </summary>
        public void ExportVectorData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, params Vector3[] vectors)
        {
            List<Vector3> list = new List<Vector3>();

            foreach (Vector3 vector in vectors)
            {
                list.Add(vector);
            }

            ExportVectorData(xmlDoc, assetNode, elementName, list);
        }

        #endregion

        #region Rectangle
        /// <summary>
        /// Exports Rectangle data to the Xml Document
        /// </summary>
        public void ExportRectangleData(XmlDocument xmlDoc, XmlElement assetNode,
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
        public static void ExportRectangleData(XmlDocument xmlDoc, XmlElement assetNode,
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

        /// <summary>
        /// Exports a list of individual rectangles to the Xml Document
        /// </summary>
        public void ExportRectangleData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, params Rectangle[] rectangles)
        {
            List<Rectangle> list = new List<Rectangle>();

            foreach (Rectangle rect in rectangles)
            {
                list.Add(rect);
            }

            ExportRectangleData(xmlDoc, assetNode, elementName, list);
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

        /// <summary>
        /// Exports a list of individual bools to the Xml Document
        /// </summary>
        public void ExportBoolData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, params bool[] bools)
        {
            List<bool> list = new List<bool>();

            foreach (bool newBool in bools)
            {
                list.Add(newBool);
            }

            ExportBoolData(xmlDoc, assetNode, elementName, list);
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

        /// <summary>
        /// Exports a list of individual Strings to the Xml Document
        /// </summary>
        public void ExportStringData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, params string[] strings)
        {
            List<string> list = new List<string>();

            foreach (string newString in strings)
            {
                list.Add(newString);
            }

            ExportStringData(xmlDoc, assetNode, elementName, list);
        }
        #endregion

        #region Custom Data Type
        public void ExportCustomData(XmlDocument doc, XmlElement assetNode, 
            string mainElementName, string subElementName1, string subElementName2,
            Point values)
        {
        }
        #endregion
    }
}
