using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SandTileEngine
{
    [Serializable]
    class SaveSettings
    {
        #region Singlton
        public static SaveSettings Settings;

        public static void Initialize()
        {
            Settings = new SaveSettings();
        }
        #endregion

        //project name
        string projectName;

        //number of maps created
        int mapsCreated;

        //tileset
        string tileSetPath;
        string tileSetFileName;

        //map data
        int[] baseLayer;
        int[] middleLayer;
        int[] topLayer;
        int[] atmosphereLayer;
        int[] collisionLayer;

        //exporter settings
        ExporterSettings saveSettings = ExporterSettings.Settings;

        /// <summary>
        /// Serializes the save data into the projects SaveSettings folder.
        /// The ProjectName will be passed in as the "ProjectFolder" in order
        /// to create the path if it has not already been created, or simply
        /// save into that path.
        /// </summary>
        /// <param name="projectFolder">Projects Name</param>
        public void SerializeSaveSettings(string projectFolder)
        {
            //Try to open the file and write the settings
            //if the file does not exist, create the directory
            //and the file, then write settings
            try
            {
                Stream stream = File.Open(projectFolder + "//SaveSettings//Settings.bin", FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, this);
                stream.Close();
            }
            catch
            {
                System.IO.Directory.CreateDirectory(projectFolder + "//SaveSettings//");
                Stream stream = File.Open(projectFolder + "//SaveSettings//Settings.bin", FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, this);
                stream.Close();
            }
        }

        public SaveSettings DeSerializeSaveSettings()
        {
            //If the settings.bin exists, open it and return it
            //to the program. If it doesn't exist, create a new one 
            //and return it to the program.
            try
            {
                SaveSettings settings;
                Stream stream = File.Open("//SaveSettings//Settings.bin", FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                settings =
                   (SaveSettings)bFormatter.Deserialize(stream);
                stream.Close();
                return settings;
            }
            catch (Exception ex)
            {
                string text = ex.ToString();
                return new SaveSettings();
            }
        }

    }
}
