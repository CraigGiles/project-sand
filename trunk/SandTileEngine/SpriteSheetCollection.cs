#region File Description
//-----------------------------------------------------------------------------
// SpriteSheetCollection.cs
//
// Copyright (C) Project Sand
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace SandTileEngine
{
    /// <summary>
    /// Holds a list of SpriteSheets and handles organizing them
    /// </summary>
    public class SpriteSheetCollection
    {
        #region Collection

        // List of loaded tile textures
        List<SpriteSheet> collection = new List<SpriteSheet>();

        /// <summary>
        /// Returns an indexed sprite sheet from the collection
        /// </summary>
        public SpriteSheet this[int i]
        {
            get { return collection[i]; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add the loaded sprite sheet to the collection
        /// </summary>
        /// <param name="sheet">Fully loaded sprite sheet</param>
        public void AddSpriteSheet(SpriteSheet sheet)
        {
            collection.Add(sheet);
        }

        //TODO:  Any more functions that we need?
        #endregion
    }
}
