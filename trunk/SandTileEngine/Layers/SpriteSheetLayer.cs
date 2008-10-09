#region File Description
//-----------------------------------------------------------------------------
// SpriteSheetRenderer.cs
//
// Copyright (C) Project Sand
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
    /// Provides a way to render the sprite sheet when drawn on the screen, usually for selection
    /// in the tile editor.
    /// </summary>
    public class SpriteSheetLayer : BaseLayer
    {
        #region Constructors

        /// <summary>
        /// Create a new Sprite Sheet Layer
        /// </summary>
        public SpriteSheetLayer()
            :base()
        { }

        /// <summary>
        /// Create a new Sprite Sheet Layer with the specified Sprite Sheet
        /// </summary>
        /// <param name="sheet">SpriteSheet to render</param>
        public SpriteSheetLayer(int width, int height, SpriteSheet sheet)
            :base(width, height, sheet)
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Changes the sprite sheet this layer uses with the specific width and height and the
        /// new sprite sheet
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        /// <param name="sheet">New SpriteSheet to use</param>
        public void ChangeSpriteSheet(int width, int height, SpriteSheet sheet)
        {
            ResizeLayer(width, height);
            this.sheet = sheet;
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Draws the tilesheet onto the screen
        /// </summary>
        /// <param name="batch">Batch to render with</param>
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
            int index = 0;

            for (int r = visibleTiles.Top; r < visibleTiles.Bottom; r++)
            {
                for (int c = visibleTiles.Left; c < visibleTiles.Right; c++)   
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
                    index = (r * Width) + c;
                    validTile = sheet.GetRectangle(ref index, out sourceRect);

                    //Draw the tile.  Notice that position is used as the offset and
                    //the screen center is used as a position.  This is required to
                    //enable scaling and rotation about the center of the screen by
                    //drawing tiles as an offset from the center coordinate
                    // Note that if the tile isn't valid (i.e., there's no tile in that
                    // spot for that layer), don't render anything
                    if (validTile)
                        batch.Draw(sheet.Texture, position, sourceRect, Color.White,
                            0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
                }
            }

            batch.End();
        }

        #endregion
    }

}