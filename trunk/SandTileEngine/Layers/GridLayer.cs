#region File Description
//-----------------------------------------------------------------------------
// GridLayer.cs
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
    /// A special form of the layer that draws the grid and selection box
    /// </summary>
    public class GridLayer : BaseLayer
    {
        #region Fields

        // Highlight color
        Color highlightColor = Color.Gold;
        // Grid color
        Color gridColor = Color.Gray;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a special layer with the specified width and height along with a texture for a grid,
        /// atmosphere, or background
        /// </summary>
        /// <param name="width">Width in tiles</param>
        /// <param name="height">Height in tiles</param>
        /// <param name="tileTexture">Special texture used for a grid, atmosphere, or background</param>
        public GridLayer(int width, int height, Texture2D tileTexture)
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

                    // For a grid, draw a bounding box using the texture provided
                    // (should be a white dot to be stretched into a line)
                    batch.Draw(texture,
                        new Rectangle((int)(position.X + tileWidth), (int)(position.Y),
                            1, tileHeight), gridColor);
                    batch.Draw(texture,
                        new Rectangle((int)(position.X), (int)(position.Y + tileHeight),
                        tileWidth, 1), gridColor);
                }
            }

            batch.End();
        }

        /// <summary>
        /// Draws the highlighted map tile
        /// </summary>
        /// <param name="batch"></param>
        public void DrawHighlight(SpriteBatch batch, int row, int col)
        {
            // Check to see if the highlight is within the map.  If not, don't draw anything
            if (row >= Height || col >= Width)
                return;

            //begin a batch of sprites to be drawn all at once
            batch.Begin(SpriteBlendMode.AlphaBlend);

            float scaledTileWidth = (float)tileWidth * scaleValue.X;
            float scaledTileHeight = (float)tileHeight * scaleValue.Y;
            Vector2 scale = Vector2.One;

            //Get the tile's position from the grid
            //in this section we're using reference methods
            //for the high frequency math functions
            Vector2 position = Vector2.Zero;
            position.X = (float)col * scaledTileWidth;
            position.Y = (float)row * scaledTileHeight;

            //Now, we get the camera position relative to the tile's position
            Vector2.Subtract(ref position, ref cameraPostionValue,
                out position);

            //get the tile's final size (note that scaling is done after 
            //determining the position)
            Vector2.Multiply(ref scaleValue, zoomValue, out scale);

            // For the highlight, draw a bounding box using the texture provided
            // (should be a white dot to be stretched into a line) and color it
            batch.Draw(texture,
                new Rectangle((int)(position.X + tileWidth), (int)(position.Y),
                    1, tileHeight), highlightColor);
            batch.Draw(texture,
                new Rectangle((int)(position.X), (int)(position.Y + tileHeight),
                tileWidth, 1), highlightColor);
            batch.Draw(texture,
                new Rectangle((int)(position.X), (int)(position.Y),
                    1, tileHeight), highlightColor);
            batch.Draw(texture,
                new Rectangle((int)(position.X), (int)(position.Y),
                    tileWidth, 1), highlightColor);

            batch.End();
        }

        /// <summary>
        /// Draws the highlighted map tile based on the rectangle
        /// </summary>
        /// <param name="batch"></param>
        public void DrawHighlight(SpriteBatch batch, Rectangle selection)
        {
            //begin a batch of sprites to be drawn all at once
            batch.Begin(SpriteBlendMode.AlphaBlend);

            float scaledTileWidth = (float)tileWidth * scaleValue.X;
            float scaledTileHeight = (float)tileHeight * scaleValue.Y;
            Vector2 scale = Vector2.One;

            //Get the tile's position from the grid
            //in this section we're using reference methods
            //for the high frequency math functions
            Vector2 position = Vector2.Zero;
            position.X = (float)selection.X * scaledTileWidth;
            position.Y = (float)selection.Y * scaledTileHeight;

            //Now, we get the camera position relative to the tile's position
            Vector2.Subtract(ref position, ref cameraPostionValue,
                out position);

            //get the tile's final size (note that scaling is done after 
            //determining the position)
            Vector2.Multiply(ref scaleValue, zoomValue, out scale);

            // For the highlight, draw a bounding box using the texture provided
            // (should be a white dot to be stretched into a line) and color it
            batch.Draw(texture,
                new Rectangle((int)(position.X + selection.Width), (int)(position.Y),
                    1, selection.Height), highlightColor);
            batch.Draw(texture,
                new Rectangle((int)(position.X), (int)(position.Y + selection.Height),
                selection.Width, 1), highlightColor);
            batch.Draw(texture,
                new Rectangle((int)(position.X), (int)(position.Y),
                    1, selection.Height), highlightColor);
            batch.Draw(texture,
                new Rectangle((int)(position.X), (int)(position.Y),
                    selection.Width, 1), highlightColor);

            batch.End();
        }

        #endregion
    }
}
