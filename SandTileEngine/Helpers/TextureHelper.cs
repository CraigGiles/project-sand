#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace SandTileEngine
{
    /// <summary>
    /// Helper class to create transparent key tiles based on a provided color key.  Note that supposedly,
    /// XNA 3.0 has this support built in so this will not be necessary when we upgrade, but will be useful
    /// for XNA 2.0 functions.
    /// </summary>
    public class TextureHelper
    {
        // Sets the colour key to be used for a Texture2D object
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
    }
}
