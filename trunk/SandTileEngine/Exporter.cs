using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;

namespace SandTileEngine
{
    #region ExportDataStyle enum
    /// <summary>
    /// Styles that can be exported in multiple variations to
    /// the XML document. IE: Point can be exported as a
    /// Vector2, or custom data. Vector2 can be exported as
    /// a point, or custom data.
    /// </summary>
    public enum ExportDataStyle
    {
        /// <summary>
        /// Exports as a point (X Y)
        /// </summary>
        Point,

        /// <summary>
        /// Exports as a vector (X Y)
        /// </summary>
        Vector2,

        /// <summary>
        /// Exports as custom data
        /// </summary>
        Custom,

        /// <summary>
        /// Exports all sub-nodes as grouped nodes
        /// </summary>
        Grouped,

        /// <summary>
        /// Exports all nodes as individual nodes
        /// </summary>
        Individual,
    }
    #endregion

    /// <summary>
    /// Handles all of the exporting of custom map data
    /// </summary>
    public class Exporter
    {
        ///* * * * * * * * *
        // * All names associated with the current map
        // * that needs to be exported to the XML file
        // * * * * * * * * */

        //#region XML File Name 
        ///// <summary>
        ///// The Exported file name for the XML Document
        ///// </summary>
        //string xmlExportedFileName = "testFileName.xml";

        ///// <summary>
        ///// The Exported file name for the XML Document
        ///// </summary>
        //public string XmlExportedFileName
        //{
        //    get { return xmlExportedFileName; }
        //    set { xmlExportedFileName = value; }
        //}
        //#endregion

        //#region Project Namespace / Class Name
        ///// <summary>
        ///// The namespace of the projects Map Content Reader
        ///// </summary>
        //string projectDataNamespace = "ProjectsGameData";

        ///// <summary>
        ///// The namespace of the projects Map Content Reader
        ///// </summary>
        //public string ProjectDataNamespace
        //{
        //    get { return projectDataNamespace; }
        //    set { projectDataNamespace = value; }
        //}

        ///// <summary>
        ///// The Class Name of the projects Map Class
        ///// </summary>
        //string projectMapClassName = "MapClassName";

        ///// <summary>
        ///// The Class Name of the projects Map Class
        ///// </summary>
        //public string ProjectMapClassName
        //{
        //    get { return projectMapClassName; }
        //    set { projectMapClassName = value; }
        //}
        //#endregion

        //#region Map Name
        ///// <summary>
        ///// Should the exported XML file contain the Map Name
        ///// </summary>
        //bool exportMapName = true;

        ///// <summary>
        ///// Should the exported XML file contain the Map Name
        ///// </summary>
        //public bool ExportMapName
        //{
        //    get { return exportMapName; }
        //    set { exportMapName = value; }
        //}

        ///// <summary>
        ///// Name of map being exported
        ///// </summary>
        //string mapNameElementName = string.Empty;

        ///// <summary>
        ///// Name of map being exported
        ///// </summary>
        //public string MapNameElementName
        //{
        //    get { return mapNameElementName; }
        //    set { mapNameElementName = value; }
        //}
        //#endregion

        //#region Map Dimensions
        ///// <summary>
        ///// How is this data going to be exported to the XML document
        ///// </summary>
        //ExportDataStyle mapDimensionsExportStyle = ExportDataStyle.Point;

        ///// <summary>
        ///// How is this data going to be exported to the XML document
        ///// </summary>
        //public ExportDataStyle MapDimensionsExportStyle
        //{
        //    get { return mapDimensionsExportStyle; }
        //    set { mapDimensionsExportStyle = value; }
        //}

        ///// <summary>
        ///// Should the exported XML file contain the Map Dimensions
        ///// </summary>
        //bool exportMapDimensions = true;

        ///// <summary>
        ///// Should the exported XML file contain the Map Dimensions
        ///// </summary>
        //public bool ExportMapDimensions
        //{
        //    get { return exportMapDimensions; }
        //    set { exportMapDimensions = value; }
        //}

        ///// <summary>
        ///// Element name of the Map Dimensions element
        ///// </summary>
        //string mapDimensionsElementName = string.Empty;

        ///// <summary>
        ///// Element name of hte Map Dimensions element
        ///// </summary>
        //public string MapDimensionsElementName
        //{
        //    get { return mapDimensionsElementName; }
        //    set { mapDimensionsElementName = value; }
        //}

        ///// <summary>
        ///// Element name of the Map Dimensions > Width element
        ///// </summary>
        //string mapDimensionsWidthName = string.Empty;

        ///// <summary>
        ///// Element name of the Map Dimensions > Width element
        ///// </summary>
        //public string MapDimensionsWidthName
        //{
        //    get { return mapDimensionsWidthName; }
        //    set { mapDimensionsWidthName = value; }
        //}

        ///// <summary>
        ///// Element name of the Map Dimensions > Height element
        ///// </summary>
        //string mapDimensionsHeightName = string.Empty;

        ///// <summary>
        ///// Element name of the Map Dimensions > Height element
        ///// </summary>
        //public string MapDimensionsHeightName
        //{
        //    get { return mapDimensionsHeightName; }
        //    set { mapDimensionsHeightName = value; }
        //}

        //#endregion

        //#region Tile Sheet

        ///// <summary>
        ///// Should the exported XML file contain the Tile Sheet
        ///// </summary>
        //bool exportTileSheet = true;

        ///// <summary>
        ///// Should the exported XML file contain the Tile Sheet
        ///// </summary>
        //public bool ExportTileSheet
        //{
        //    get { return exportTileSheet; }
        //    set { exportTileSheet = value; }
        //}

        ///// <summary>
        ///// Element name used for the Tile Sheet element
        ///// </summary>
        //string tileSheetElementName = String.Empty;

        ///// <summary>
        ///// Element name used for the Tile Sheet element
        ///// </summary>
        //public string TileSheetElementName
        //{
        //    get { return tileSheetElementName; }
        //    set { tileSheetElementName = value; }
        //}

        //#endregion
                
        //#region Tile Dimensions
        ///// <summary>
        ///// How is this data going to be exported to the XML document
        ///// </summary>
        //ExportDataStyle tileDimensionsExportStyle = ExportDataStyle.Point;

        ///// <summary>
        ///// How is this data going to be exported to the XML document
        ///// </summary>
        //public ExportDataStyle TileDimensionsExportStyle
        //{
        //    get { return tileDimensionsExportStyle; }
        //    set { tileDimensionsExportStyle = value; }
        //}

        ///// <summary>
        ///// Should the exported XML file contain the Tile DImensions
        ///// </summary>
        //bool exportTileDimensions = true;

        ///// <summary>
        ///// Should the exported XML file contain the Tile Dimensions
        ///// </summary>
        //public bool ExportTileDimensions
        //{
        //    get { return exportTileDimensions; }
        //    set { exportTileDimensions = value; }
        //}

        ///// <summary>
        ///// The dimensions of a given tile on the map in pixels
        ///// </summary>
        //string tileDimensionsElementName = string.Empty;

        ///// <summary>
        ///// The dimensions of a given tile on the map in pixels
        ///// </summary>
        //public string TileDimensionsElementName
        //{
        //    get { return tileDimensionsElementName; }
        //    set { tileDimensionsElementName = value; }
        //}

        ///// <summary>
        ///// The dimensions of a given tile on the map in pixels
        ///// </summary>
        //string tileDimensionsWidthName = string.Empty;

        ///// <summary>
        ///// The dimensions of a given tile on the map in pixels
        ///// </summary>
        //public string TileDimensionsWidthName
        //{
        //    get { return tileDimensionsWidthName; }
        //    set { tileDimensionsWidthName = value; }
        //}

        ///// <summary>
        ///// The dimensions of a given tile on the map in pixels
        ///// </summary>
        //string tileDimensionsHeightName = string.Empty;

        ///// <summary>
        ///// The dimensions of a given tile on the map in pixels
        ///// </summary>
        //public string TileDimensionsHeightName
        //{
        //    get { return tileDimensionsHeightName; }
        //    set { tileDimensionsHeightName = value; }
        //}


        //#endregion

        //#region Layer Information

        //#region Base Layer
        ///// <summary>
        ///// Should the exported XML file contain the Base Layer
        ///// </summary>
        //bool exportBaseLayer = true;

        ///// <summary>
        ///// Should the exported XML file contain the Base Layer
        ///// </summary>
        //public bool ExportBaseLayer
        //{
        //    get { return exportBaseLayer; }
        //    set { exportBaseLayer = value; }
        //}

        ///// <summary>
        ///// Xml Element Name used for Base Layer
        ///// </summary>
        //string baseLayerElementName = String.Empty;

        ///// <summary>
        ///// Xml Element Name used for Base Layer
        ///// </summary>
        //public string BaseLayerElementName
        //{
        //    get { return baseLayerElementName; }
        //    set { baseLayerElementName = value; }
        //}
        //#endregion

        //#region Middle Layer
        ///// <summary>
        ///// Should the exported XML file contain the Middle Layer
        ///// </summary>
        //bool exportMiddleLayer = true;

        ///// <summary>
        ///// Should the exported XML file contain the Middle Layer
        ///// </summary>
        //public bool ExportMiddleLayer
        //{
        //    get { return exportMiddleLayer; }
        //    set { exportMiddleLayer = value; }
        //}

        ///// <summary>
        ///// Xml Element Name used for Middle Layer
        ///// </summary>
        //string middleLayerElementName = String.Empty;

        ///// <summary>
        ///// Xml Element Name used for Middle Layer
        ///// </summary>
        //public string MiddleLayerElementName
        //{
        //    get { return middleLayerElementName; }
        //    set { middleLayerElementName = value; }
        //}
        //#endregion
        
        //#region Top Layer
        ///// <summary>
        ///// Should the exported XML file contain the Top Layer
        ///// </summary>
        //bool exportTopLayer = true;

        ///// <summary>
        ///// Should the exported XML file contain the Top Layer
        ///// </summary>
        //public bool ExportTopLayer
        //{
        //    get { return exportTopLayer; }
        //    set { exportTopLayer = value; }
        //}

        ///// <summary>
        ///// Xml Element Name used for Top Layer
        ///// </summary>
        //string topLayerElementName = String.Empty;

        ///// <summary>
        ///// Xml Element Name used for Top Layer
        ///// </summary>
        //public string TopLayerElementName
        //{
        //    get { return topLayerElementName; }
        //    set { topLayerElementName = value; }
        //}
        //#endregion
        
        //#region Atmosphere Layer
        ///// <summary>
        ///// Should the exported XML file contain the Atmosphere Layer
        ///// </summary>
        //bool exportAtmosphereLayer = true;

        ///// <summary>
        ///// Should the exported XML file contain the Atmosphere Layer
        ///// </summary>
        //public bool ExportAtmosphereLayer
        //{
        //    get { return exportAtmosphereLayer; }
        //    set { exportAtmosphereLayer = value; }
        //}

        ///// <summary>
        ///// Xml Element Name used for Atmosphere Layer
        ///// </summary>
        //string atmosphereLayerElementName = String.Empty;

        ///// <summary>
        ///// Xml Element Name used for Atmosphere Layer
        ///// </summary>
        //public string AtmosphereLayerElementName
        //{
        //    get { return atmosphereLayerElementName; }
        //    set { atmosphereLayerElementName = value; }
        //}
        //#endregion
        
        //#region Collision Layer
        ///// <summary>
        ///// Should the exported XML file contain the Collision Layer
        ///// </summary>
        //bool exportCollisionLayer = true;

        ///// <summary>
        ///// Should the exported XML file contain the Collision Layer
        ///// </summary>
        //public bool ExportCollisionLayer
        //{
        //    get { return exportCollisionLayer; }
        //    set { exportCollisionLayer = value; }
        //}

        ///// <summary>
        ///// Xml Element Name used for Collision Layer
        ///// </summary>
        //string collisionLayerElementName = String.Empty;

        ///// <summary>
        ///// Xml Element Name used for Collision Layer
        ///// </summary>
        //public string CollisionLayerElementName
        //{
        //    get { return collisionLayerElementName; }
        //    set { collisionLayerElementName = value; }
        //}
        //#endregion
        
        //#endregion
        
        /* * * * * * * * *
         * Handles all of the exporting logic for writing
         * the map to an XML file.
         * * * * * * * * */
        
        #region Export Xml


        /// <summary>
        /// Builds an XML file with all Map data ready to plug
        /// into your XNA's Project Content Pipeline
        /// </summary>
        public void ExportXml(TileMap tileMap)
        {
            XmlDocument doc = new XmlDocument();

            //try to write the file, and if things go wrong
            //write an entry in error log
            try
            {
                #region Xml Writer
                //generate a new XML Writer with correct formatting
                XmlTextWriter xmlWriter = new XmlTextWriter(ExporterSettings.Settings.XmlFileName, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");

                //We want to be able to use this in the XNA Content Pipeline
                xmlWriter.WriteStartElement("XnaContent");
                xmlWriter.Close();

                //load your newly created xml file
                doc.Load(ExporterSettings.Settings.XmlFileName);
                #endregion

                #region Root Element / Asset Node
                //create the root element
                XmlNode root = doc.DocumentElement;

                XmlElement assetNode = CreateAssetNode(doc, root);
                #endregion

                #region Export Information
                //Creates a comment displaying which section of the
                //map is being exported. This helps the XML readability.
                CreateComment(doc, assetNode, "Basic Map Details");

                ExportMapData(tileMap, doc, assetNode);         //Map Name / Map Dimensions
                
                ExportTileInformation(tileMap, doc, assetNode); //TileSheet / Tile Dimensions

                //Creates a comment displaying which section of the
                //map is being exported. This helps the XML readability.
                CreateComment(doc, assetNode, "Map Layer Information");
                
                ExportLayerInformation(tileMap, doc, assetNode);
                #endregion

                //save the XML document
                doc.Save(ExporterSettings.Settings.XmlFileName);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorMessage(ex.ToString());
            }
        }

        /// <summary>
        /// Creates the asset node for the XNA Content Pipeline
        /// </summary>
        /// <remarks>
        /// The asset describes the type of object being imported
        /// through the content pipeline. XNA uses this format;
        /// Asset Type="ProjectNamespace.ProjectClass"
        /// so we will use the same format in our exported file.
        /// If these values are changed, chances are you may have to re-work
        /// how your content pipeline reads XML files
        /// </remarks>
        private XmlElement CreateAssetNode(XmlDocument doc, XmlNode root)
        {
            XmlElement assetNode = doc.CreateElement("Asset");
            assetNode.SetAttribute("Type", ExporterSettings.Settings.ProjectDataNamespace + 
                "." + ExporterSettings.Settings.ProjectMapClassName);
            root.AppendChild(assetNode);
            return assetNode;
        }

        /// <summary>
        /// Exports basic map data (MapName, MapDimensions) to the XML file
        /// </summary>
        /// <remarks>
        /// The MapName node houses the 'Area Name' of the map and 
        /// not the file name or asset name. For example, an asset name
        /// could be "Map001" and read through the content pipeline that way, 
        /// but when in-game characters refer to Map001 as the "Enchanted Forrest.
        /// 
        /// Map Dimensions can be exported in two different ways, and it is up
        /// to the user which way works best for them. Some projets may choose to 
        /// import Point data directly into their TileMap class, while other
        /// projects wish to import each data type individually.
        /// </remarks>
        private void ExportMapData(TileMap tileMap, XmlDocument doc, XmlElement assetNode)
        {
            //If the user wishes to export the MapName node to XML
            if (ExporterSettings.Settings.ExportMapName)
            {
                ExportStringData(doc, assetNode, ExporterSettings.Settings.ElementMapName, tileMap.MapName);
            }

            //if user wishes to export MapDimensions node to XML
            if (ExporterSettings.Settings.ExportMapDimensions)
            {
                //if user sets exporting map dimensions as point data
                if (ExporterSettings.Settings.DataStyleMapDimensions == ExportDataStyle.Point)
                    ExportPointData(doc, assetNode, ExporterSettings.Settings.ElementMapDimensions,
                        new Point(tileMap.MapWidth, tileMap.MapHeight));

                //if user sets exporting map dimensions as custom data
                else if (ExporterSettings.Settings.DataStyleMapDimensions == ExportDataStyle.Custom)
                    ExportCustomData(doc, assetNode, ExporterSettings.Settings.ElementMapDimensions,
                        ExporterSettings.Settings.ElementMapWidth, ExporterSettings.Settings.ElementMapHeight,
                        new Point(tileMap.MapWidth, tileMap.MapHeight));
            }
        }

        /// <summary>
        /// Exports Tile Information to the XML file
        /// </summary>
        /// <remarks>
        /// When exporting tile sheet, the ContentPath + ContentFileName are exported
        /// making it easy to plug both files into your project. The full file
        /// name would typically be "Content//YourTexturesFolder//TileSheetName"
        /// 
        /// Tile Dimensions can be exported in two different ways, and it is up
        /// to the user which way works best for them. Some projets may choose to 
        /// import Point data directly into their TileMap class, while other
        /// projects wish to import each data type individually.
        /// </remarks>
        private void ExportTileInformation(TileMap tileMap, XmlDocument doc, XmlElement assetNode)
        {
            if (ExporterSettings.Settings.ExportTileSheet)
            {
                ExportStringData(doc, assetNode, ExporterSettings.Settings.ElementTileSheet, 
                    tileMap.TileSheet.FullFileName);
            }

            //if user wishes to export tile dimensions
            if (ExporterSettings.Settings.ExportTileDimensions)
            {
                //if user sets exporting tile dimensions as point data
                if (ExporterSettings.Settings.DataStyleTileDimensions == ExportDataStyle.Point)
                    ExportPointData(doc, assetNode, ExporterSettings.Settings.ElementTileDimensions,
                        new Point(TileLayer.TileWidth, TileLayer.TileHeight));

                //if user sets exporting tile dimensions as custom data
                else if (ExporterSettings.Settings.DataStyleTileDimensions == ExportDataStyle.Custom)
                    ExportCustomData(doc, assetNode, ExporterSettings.Settings.ElementTileDimensions,
                        ExporterSettings.Settings.ElementTileWidth, ExporterSettings.Settings.ElementTileHeight,
                        new Point(
                            tileMap[0].WidthInPixels / tileMap[0].Width,
                            tileMap[0].HeightInPixels / tileMap[0].Height));
            }
        }

        /// <summary>
        /// Exports map layer information to the XML file
        /// </summary>
        /// <remarks>
        /// Through testing we found that XNA will not serialize a multi-dimensional
        /// array and still be able to plug right into the content pipeline. Because
        /// of this, we had to export the layers as an int[] array. If your project
        /// requires int[,] arrays, it can be modified back inside your ContentReader.
        /// Look in the documentation at the ArrayHelper class for converting a single
        /// dimensional array to multi dimensional array.
        /// 
        /// Also of note, TileMaps created with this editor only support 5 layers;
        /// Base - Ground level textures such as grass
        /// Middle - Objects placed on top of base level - Subject to depth
        /// Top - Objects always drawn on top of in-game characters
        /// Atmosphere - Fog / Rain / Snow / etc
        /// Collision - Layer transparent to the user but controls the bounds of game objects
        /// </remarks>
        private void ExportLayerInformation(TileMap tileMap, XmlDocument doc, XmlElement assetNode)
        {
            if (ExporterSettings.Settings.ExportBaseLayer)
            {
                ExportIntData(doc, assetNode, ExporterSettings.Settings.ElementBaseLayer,
                    ArrayHelper.ConvertMultiToSingle(tileMap[(int)Layer.BaseLayer].Map));
            }

            if (ExporterSettings.Settings.ExportMiddleLayer)
            {
                ExportIntData(doc, assetNode, ExporterSettings.Settings.ElementMiddleLayer,
                   ArrayHelper.ConvertMultiToSingle(tileMap[(int)Layer.MiddleLayer].Map));
            }

            if (ExporterSettings.Settings.ExportTopLayer)
            {
                ExportIntData(doc, assetNode, ExporterSettings.Settings.ElementTopLayer,
                   ArrayHelper.ConvertMultiToSingle(tileMap[(int)Layer.TopLayer].Map));
            }

            if (ExporterSettings.Settings.ExportAtmosphereLayer)
            {
                ExportIntData(doc, assetNode, ExporterSettings.Settings.ElementAtmosphereLayer,
                    ArrayHelper.ConvertMultiToSingle(tileMap[(int)Layer.Atmosphere].Map));
            }

            if (ExporterSettings.Settings.ExportCollisionLayer)
            {
                ExportIntData(doc, assetNode, ExporterSettings.Settings.ElementCollisionLayer,
                    ArrayHelper.ConvertMultiToSingle(tileMap[(int)Layer.CollisionLayer].Map));
            }
        }


        #endregion

        #region Comment
        /// <summary>
        /// Creates a comment line in the XML file
        /// </summary>
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="comment">Comment to insert into the doc</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="point">Point data being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="points">List of point data being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="points">Array of points data being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="value">int value being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="values">int values being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="value">int values being exported</param>
        public void ExportIntData(XmlDocument xmlDoc, XmlElement assetNode,
            string elementName, int[] value)
        {
            string data = string.Empty;

            for (int i = 0; i < value.Length; i++)
            {
                data += value[i].ToString() + " ";
            }

            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = data;
            assetNode.AppendChild(element);
        }

        #endregion

        #region Vector2
        /// <summary>
        /// Exports Vector2 data to the Xml Document
        /// </summary>
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="vector">vector value being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="vectors">list of vector values being exported</param>
        public void ExportVectorData(XmlDocument xmlDoc, XmlElement assetNode,
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="vectors">list of vector values being exported</param>
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
        /// Exports a list of individual Vector2s to the Xml Document
        /// </summary>
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="vector">vector value being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="vectors">list of vector values being exported</param>
        public void ExportVectorData(XmlDocument xmlDoc, XmlElement assetNode,
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="vectors">list of vector values being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="rectangle">rectangle value being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="rectangles">list of rectangles being exported</param>
        public void ExportRectangleData(XmlDocument xmlDoc, XmlElement assetNode,
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="rectangles">list of rectangles being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="value">bool being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="values">list of bools being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="bools">list of bools being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="value">string being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="values">strings being exported</param>
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
        /// <param name="xmlDoc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="elementName">XmlNode's name</param>
        /// <param name="values">strings being exported</param>
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
        /// <summary>
        /// Exports point data in a custom format to the XML document
        /// </summary>
        /// <param name="doc">XML Document being edited</param>
        /// <param name="assetNode">The XNA Asset Node created by the editor</param>
        /// <param name="mainElementName">Main XmlNode's name</param>
        /// <param name="subElementName1">Child XmlNode of MainElementName</param>
        /// <param name="subElementName2">Child XmlNode of MainElementName</param>
        /// <param name="values">Point values being exported</param>
        public void ExportCustomData(XmlDocument doc, XmlElement assetNode, 
            string mainElementName, string subElementName1, string subElementName2,
            Point values)
        {
            //create the main element
            XmlElement element = doc.CreateElement(mainElementName);

            //create two sub elements (nodes)
            XmlElement subElement1 = doc.CreateElement(subElementName1);
            XmlElement subElement2 = doc.CreateElement(subElementName2);

            //set the sub elements inner text to the value
            subElement1.InnerText = values.X.ToString();
            subElement2.InnerText = values.Y.ToString();

            //append the sub elements into the main element
            element.AppendChild(subElement1);
            element.AppendChild(subElement2);

            //append the main element into the document
            assetNode.AppendChild(element);
        }
        #endregion
    }
}
