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
    class TileMapCollection
    {
        #region Collection

        // List of loaded maps
        List<TileMap> collection = new List<TileMap>();

        /// <summary>
        /// Returns an indexed map from the collection
        /// </summary>
        public TileMap this[int i]
        {
            get { return collection[i]; }
        }

        #endregion

        #region Public Methods

        //TODO: Do we need anything here?

        #endregion
    }
}
