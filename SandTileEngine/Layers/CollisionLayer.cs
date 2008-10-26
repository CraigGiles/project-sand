#region File Description
//-----------------------------------------------------------------------------
// CollisionLayer.cs
//
// Copyright (C) Project Sand
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace SandTileEngine
{
    /// <summary>
    /// A special form of the layer that draws the collision layer
    /// </summary>
    public class CollisionLayer : BaseLayer
    {
        #region Fields

        // Collision color (transparent red)
        Color collisionColor = new Color(255, 0, 0, 50);

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a special layer with the specified width and height along with a texture for a collosion box
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        /// <param name="tileTexture">Special texture used for a grid, atmosphere, or background</param>
        public CollisionLayer(int width, int height, Texture2D tileTexture)
            : base(width, height, tileTexture)
        { }

        #endregion

        #region Drawing

        public override void Draw(SpriteBatch batch)
        {
            if (visibilityChanged) DetermineVisibility();

            float scaledTileWidth = (float)tileWidth * scaleValue.X;
            float scaledTileHeight = (float)tileHeight * scaleValue.Y;

            //begin a batch of sprites to be drawn all at once
            batch.Begin(SpriteBlendMode.AlphaBlend);

            Vector2 scale = Vector2.One;

            for (int r = visibleTiles.Top; r < visibleTiles.Bottom; r++)
            {
                for (int c = visibleTiles.Left; c < visibleTiles.Right; c++)
                {
                    // Check to see if there's a collision box here
                    if (map[r, c] != cNoTile)
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

                        // For a collision box, draw a solid red box
                        batch.Draw(texture,
                            new Rectangle((int)(position.X), (int)(position.Y),
                                tileWidth, tileHeight), collisionColor);
                    }
                }
            }

            batch.End();
        }

        #endregion
    }
}
