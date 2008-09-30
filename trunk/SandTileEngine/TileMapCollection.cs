#region File Description
//-----------------------------------------------------------------------------
// TileMapCollection.cs
//
// Copyright (C) Project Sand
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace SandTileEngine
{
    /// <summary>
    /// Contains a list of all the maps loaded/created by the editor
    /// </summary>
    public class TileMapCollection
    {
        #region Collection

        // List of loaded maps
        List<TileMap> collection = new List<TileMap>();
        // Dictionary of map name to index number
        Dictionary<string, int> reference = new Dictionary<string, int>();

        /// <summary>
        /// Returns an indexed map from the collection
        /// </summary>
        public TileMap this[int i]
        {
            get { return collection[i]; }
        }

        /// <summary>
        /// Returns the indexed map from the collection based on the name
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public TileMap this[string text]
        {
            get
            {
                if (reference.ContainsKey(text))
                    return collection[reference[text]];
                else
                {
                    throw new Exception("TileMapCollection: Referenced string " + text +
                        " doesn't exist in the dictionary");
                }
            }
        }

        /// <summary>
        /// Returns the number of maps currently in the collection
        /// </summary>
        public int Count
        {
            get { return collection.Count; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a new map to the collection
        /// </summary>
        /// <param name="map">Map to add</param>
        public void AddMap(TileMap map)
        {
            // Adds the map to the list
            collection.Add(map);

            // Adds the map name to the dictionary along with the colleciton position
            int index = collection.Count - 1;
            reference.Add(map.Identifier, index);
        }

        /// <summary>
        /// Removes the specified map from the collection
        /// </summary>
        /// <param name="name"></param>
        public void RemoveMap(string name)
        {
            if (!reference.ContainsKey(name))
            {
                throw new Exception("TileMapCollection: RemoveMap has unknown string " + name);
            }

            // Use the dictionary to find the index to remove from the list
            collection.RemoveAt(reference[name]);

            // Now that the key values are different, clear the dictionary and reread the values
            // from the list
            reference.Clear();
            for (int i = 0; i < collection.Count; i++)
            {
                reference.Add(collection[i].Identifier, i);
            }
        }

        /// <summary>
        /// Clears the collection
        /// </summary>
        public void Clear()
        {
            collection.Clear();
            reference.Clear();
        }

        /// <summary>
        /// Finds the index of the map with the provided name
        /// </summary>
        /// <param name="name">Identifier used by the form</param>
        /// <returns>Index where the map is located</returns>
        public int FindIndex(string name)
        {
            return collection.FindIndex( delegate(TileMap entry)
            {
                return (entry.Identifier == name);
            });
        }

        #endregion
    }
}
