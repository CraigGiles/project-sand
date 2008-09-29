#region File Description
//-----------------------------------------------------------------------------
// SpriteSheet.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace SandTileEngine
{

    /// <summary>
    /// Stores entries for individual sprites on a single texture.
    /// </summary>
    public class SpriteSheet
    {
        #region Fields

        // Full path to the filename that contained the texture
        string fullFileName;

        private Texture2D texture;
        private Dictionary<int, Rectangle> spriteDefinitions;

        #endregion

        #region Constants
        private const int noTile = -1;
        #endregion

        #region Properties

        /// <summary>
        /// Full path to the filename that contained the texture
        /// </summary>
        public string FullFileName
        {
            get { return fullFileName; }
            set { fullFileName = value; }
        }

        /// <summary>
        /// Get the source sprite texture
        /// </summary>
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        /// <summary>
        /// Get the rectangle that defines the source sprite
        /// on the sheet.
        /// </summary>
        public Rectangle this[int i]
        {
            get { return spriteDefinitions[i]; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new Sprite Sheet
        /// </summary>
        /// <param name="sheetTexture">Loaded sprite sheet</param>
        public SpriteSheet(Texture2D sheetTexture)
        {
            texture = sheetTexture;
            spriteDefinitions = new Dictionary<int, Rectangle>();
        }

        /// <summary>
        /// Creates a new Sprite Sheet as well as store the filename
        /// </summary>
        /// <param name="sheetTexture">Loaded sprite sheet</param>
        /// <param name="filename">File that the texture was loaded from</param>
        public SpriteSheet(Texture2D sheetTexture, string filename)
            :this(sheetTexture)
        {
            fullFileName = filename;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Add a source sprite for fast retrieval
        /// </summary>
        public void AddSourceSprite(int key, Rectangle rect)
        {
            spriteDefinitions.Add(key, rect);
        }

        /// <summary>
        /// A faster lookup using refs to avoid stack copies.
        /// </summary>
        /// <param name="i">Texture key to get</param>
        /// <param name="rect">Returns the rectangle from the spriteSheet where the key is</param>
        /// <returns>True if the key is valid, False if there is no tile here</returns>
        public bool GetRectangle(ref int i, out Rectangle rect)
        {
            if (i == noTile)
            {
                // A rectangle output is needed, so just fill it with the first rectangle
                rect = spriteDefinitions[0];
                return false;
            }

            rect = spriteDefinitions[i];

            return true;
        }
        #endregion
    }

}