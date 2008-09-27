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
        /// Add the loaded tile set texture into the collection
        /// as well as the full path to the file that contained it
        /// </summary>
        /// <param name="texture">Loaded texture from the file</param>
        /// <param name="filename">Full path to the file that contained the texutre</param>
        public void AddSpriteSheet(Texture2D texture, string filename)
        {
            SpriteSheet sheet = new SpriteSheet(texture, filename);

            // TODO:  More processing?

            collection.Add(sheet);
        }

        //TODO:  Any more functions that we need?
        #endregion
    }
}
