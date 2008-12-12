using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SandTileEngine
{
    [Serializable]
    public class SaveSettings
    {
        #region Singlton
        public static SaveSettings Settings;

        public static void Initialize()
        {
            Settings = new SaveSettings();
        }
        #endregion

        int mapsCreated;

        //---------------------------------------------
        // TileMap
        //---------------------------------------------
        List<string> Identifier = new List<string>();
        List<int[,]> MapBounds = new List<int[,]>();
        List<int[,]> MapCodes = new List<int[,]>();
        List<int> MapHeight = new List<int>();
        List<string> MapName = new List<string>();
        List<int> MapWidth = new List<int>();
        List<bool> MouseInMap = new List<bool>();
        List<bool> ShowCollision = new List<bool>();

        //---------------------------------------------
        // Sprite Sheet
        //---------------------------------------------
        List<int> TileSheetCount = new List<int>();
        List<string> TileSheetFullFileName = new List<string>();


        //exporter settings
        ExporterSettings saveSettings = ExporterSettings.Settings;

        /// <summary>
        /// Serializes the save data into the projects SaveSettings folder.
        /// The ProjectName will be passed in as the "ProjectFolder" in order
        /// to create the path if it has not already been created, or simply
        /// save into that path.
        /// </summary>
        /// <param name="projectFolder">Projects Name</param>
        public void SerializeSaveSettings(string projectFile, TileMapCollection collection)
        {
            mapsCreated = collection.Count;

            for (int i = 0; i < collection.Count; i++)
            {
                Identifier.Add(collection[i].Identifier);
                MapBounds.Add(collection[i].MapBounds);
                MapCodes.Add(collection[i].MapCodes);
                MapHeight.Add(collection[i].MapHeight);
                MapName.Add(collection[i].MapName);
                MapWidth.Add(collection[i].MapWidth);
                MouseInMap.Add(collection[i].MouseInMap);
                ShowCollision.Add(collection[i].ShowCollision);

                if (collection[i].TileSheet == null)
                {
                    TileSheetCount.Add(0);
                    TileSheetFullFileName.Add(string.Empty);
                }
                else
                {
                    TileSheetCount.Add(collection[i].TileSheet.Count);
                    TileSheetFullFileName.Add(collection[i].TileSheet.FullFileName);
                }


            }//end for loop


            //Try to open the file and write the settings
            //if the file does not exist, create the directory
            //and the file, then write settings
            try
            {
                Stream stream = File.Open(projectFile, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, this);
                stream.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorMessage(ex.ToString());
            }

        }
        

        public void DeSerializeSaveSettings(string projectFile, 
                                            TileMapCollection collection)
        {
            //If the settings.bin exists, open it and return it
            //to the program. If it doesn't exist, create a new one 
            //and return it to the program.
            try
            {
                SaveSettings settings;
                Stream stream = File.Open(projectFile, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                SaveSettings.Settings =
                   (SaveSettings)bFormatter.Deserialize(stream);
                stream.Close();

                //This section does not work as intended... so its commented out for now.

                ////put everything back into a new collection
                //for (int i = 0; i < settings.mapsCreated; i++)
                //{
                //    TileMap newMap = new TileMap(SaveSettings.Settings.MapWidth[i],
                //                                SaveSettings.Settings.MapHeight[i]);

                    
                //    newMap.Identifier = SaveSettings.Settings.Identifier[i];
                //    newMap.MapBounds = SaveSettings.Settings.MapBounds[i];
                //    newMap.MapCodes = SaveSettings.Settings.MapCodes[i];
                //    newMap.MapHeight = SaveSettings.Settings.MapHeight[i];
                //    newMap.MapName = SaveSettings.Settings.MapName[i];
                //    newMap.MapWidth = SaveSettings.Settings.MapWidth[i];
                //    newMap.MouseInMap = SaveSettings.Settings.MouseInMap[i];
                //    newMap.ShowCollision = SaveSettings.Settings.ShowCollision[i];


                //    if (collection[i].TileSheet == null)
                //    {
                //        TileSheetCount.Add(0);
                //        TileSheetFullFileName.Add(string.Empty);
                //    }
                //    else
                //    {
                //        TileSheetCount.Add(collection[i].TileSheet.Count);
                //        TileSheetFullFileName.Add(collection[i].TileSheet.FullFileName);
                //    }

                //}
            }
            catch (Exception ex)
            {
                string text = ex.ToString();
            }
        }

    }
}
