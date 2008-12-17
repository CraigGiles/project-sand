#region File Description
//-----------------------------------------------------------------------------
// TileGrid.cs
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
    /// EDUCATIONAL: Class used to align tiles to a regular grid.
    /// This represents a tiling "layer" in this sample
    /// </summary>
    public class TileLayer : BaseLayer
    {

        #region Fields

        // Name of the layer displayed on the editor and in a dictionary
        private string layerName;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that loads a tile layer with the specified width and height
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        public TileLayer(int width, int height)
            :base(width, height)
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Prints out the grid of corresponding tiles.
        /// </summary>
        public void debugPrint()
        {
            Console.WriteLine("-=- " + layerName + "-=-\n");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Extra space after everything is written
            Console.WriteLine();
        }

        #endregion

        #region Drawing

        public override void Draw(SpriteBatch batch)
        {
            if (visibilityChanged) DetermineVisibility();
            
            float scaledTileWidth = (float)tileWidth * scaleValue.X;
            float scaledTileHeight = (float)tileHeight * scaleValue.Y;

            //begin a batch of sprites to be drawn all at once
            batch.Begin(SpriteBlendMode.AlphaBlend);

            Rectangle sourceRect = new Rectangle();
            Vector2 scale = Vector2.One;
            bool validTile;

            for (int r = visibleTiles.Top; r < visibleTiles.Bottom; r++)
            {
                for (int c = visibleTiles.Left; c < visibleTiles.Right; c++)   
                {
                    if (map[r,c] != cNoTile)
                    {
                        //Get the tile's position from the grid
                        //in this section we're using reference methods
                        //for the high frequency math functions
                        Vector2 position = Vector2.Zero;
                        position.X = (float)c * scaledTileWidth;
                        position.Y = (float)r * scaledTileHeight;

                        //Now, we get the camera position relative to the tile's position
                        Vector2.Subtract(ref position, ref cameraPostionValue,
                            out position);
                        
                        //get the tile's final size (note that scaling is done after 
                        //determining the position)
                        Vector2.Multiply(ref scaleValue, zoomValue, out scale);

                        //get the source rectangle that defines the tile
                        validTile = sheet.GetRectangle(ref map[r, c], out sourceRect);

                        //Draw the tile.  Notice that position is used as the offset and
                        //the screen center is used as a position.  This is required to
                        //enable scaling and rotation about the center of the screen by
                        //drawing tiles as an offset from the center coordinate
                        // Note that if the tile isn't valid (i.e., there's no tile in that
                        // spot for that layer), don't render anything
                        if (validTile)
                            batch.Draw(sheet.Texture, position, sourceRect,
                                new Color(255, 255, 255, (byte)(255 * alpha)),
                                0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
                    }
                }
            }

            batch.End();
        }

        #endregion
    }
}

