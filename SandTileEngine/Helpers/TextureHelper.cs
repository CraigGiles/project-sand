#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace SandTileEngine
{
    using Image = System.Drawing.Image;
    using Bitmap = System.Drawing.Bitmap;

    /// <summary>
    /// Helper class to create transparent key tiles based on a provided color key (may not be needed for
    /// XNA 3.0) and provide loading procedures for loading tile sheets from a file.
    /// </summary>
    public class TextureHelper
    {
        #region Fields

        // This is needed in order to create Texture2D.  Should be initialized from the main form.
        private static GraphicsDevice graphics;

        #endregion

        /// <summary>
        /// Sets the graphics device for this class.  Should be set in the main form when initializing
        /// and is needed to load Texture2D objects.
        /// </summary>
        /// <param name="device">Graphics device to use</param>
        public static void SetGraphics(GraphicsDevice device)
        {
            graphics = device;
        }

        /// <summary>
        /// Sets the colour key to be used for a Texture2D object
        /// </summary>
        /// <param name="texture">Texture to modify</param>
        /// <param name="colourKey">Color to be transparent in the texture</param>
        /// <returns>Texture2D with the specified color transparent</returns>
        public static Texture2D SetColourKey(Texture2D texture, Color colourKey)
        {
            // Make sure the texture has been loaded
            if (texture != null)
            {
                // Get the untouched pixel data
                Color[] pixels = new Color[texture.Height * texture.Width];
                texture.GetData<Color>(pixels);

                // Loop through all rows for the current texture
                for (int i = 0; i < texture.Height; i++)
                {
                    // Iterate through all the columns in the current row
                    for (int j = 0; j < texture.Width; j++)
                    {
                        // Work out what pixel we are working with
                        int offset = ((i * texture.Width) + j);

                        // Set the alpha to zero (transparent) if the colour
                        // of the pixel is the colour we specified as the
                        // colour key
                        if (pixels[offset] == colourKey)
                            pixels[offset] = new Color(0, 0, 0, 0);
                    }
                }

                // Apply the changes to the textures pixel data
                texture.SetData<Color>(pixels);
             }

            // Return the results
            return texture;
        }

        /// <summary>
        /// Creates a sprite sheet with the provided filename of the texture and
        /// the transparency color
        /// </summary>
        /// <param name="filename">Location of the texture file</param>
        /// <param name="transparentColor">Color to be transparent in the tile set</param>
        /// <returns>SpriteSheet from the provided information</returns>
        public static SpriteSheet CreateTileSheet(string filename, Color transparentColor)
        {
            // Note that if the graphics device hasn't been set yet, don't do anything
            if (graphics == null)
            {
                Console.WriteLine("[TextureHelper::CreateTileSheet]-> Graphics device hasn't been set.  Not doing anything!");
                return null;
            }

            // Loads a bitmap from the file to get the dimensions
            Bitmap image = (Bitmap)Image.FromFile(filename);

            // Set the color key parameter
            // NOTE:  This method will only make one color transparent.  Do we want multiple color support?
            TextureCreationParameters textureParam = new TextureCreationParameters();
            textureParam.Width = image.Width;
            textureParam.Height = image.Height;
            textureParam.Depth = 0;
            textureParam.MipLevels = 0;
            textureParam.MipFilter = FilterOptions.None;
            textureParam.Filter = FilterOptions.None;
            textureParam.Format = SurfaceFormat.Unknown;
            textureParam.TextureUsage = TextureUsage.None;
            textureParam.ColorKey = transparentColor;

            Texture2D texture = Texture2D.FromFile(graphics, filename, textureParam);

            // Create a new sheet
            return new SpriteSheet(texture, filename);
        }
    }
}
