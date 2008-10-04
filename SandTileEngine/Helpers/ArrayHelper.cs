using System;
using System.Collections.Generic;
using System.Text;

namespace SandTileEngine
{
    /// <summary>
    /// Various methods used to help with the manipulation of arrays
    /// </summary>
    public class ArrayHelper
    {
        /// <summary>
        /// Converts a multi dimensional array to a single
        /// dimensional array.
        /// </summary>
        /// <param name="array">multi dimension array to convert</param>
        /// <returns>int[]</returns>
        public static int[] ConvertMultiToSingle(int[,] array)
        {
            //create a list to hold the values
            List<int> list = new List<int>();

            //cycle through each value in the multi-dimensional
            //array. This cycles through left to right, top to
            //bottom. Each vlue is added to the list
            foreach (int i in array)
            {
                list.Add(i);
            }

            //return the list as a single dimensional array.
            return list.ToArray();
        }

        /// <summary>
        /// Converts a single dimensional array to a
        /// multi dimensional array
        /// </summary>
        /// <param name="array">Single dimensional array to convert</param>
        /// <param name="width">The width of the new multi dimensional array</param>
        /// <param name="height">The height of the multi dimensional array</param>
        /// <returns>int[,]</returns>
        public static int[,] ConvertSingleToMulti(int[] array, int width, int height)
        {
            //Create a new multi dimensional array
            // with the specified width and height.
            int[,] newArray = new int[height, width];

            //initialize the array with 2 for loops
            //cycling through the width and height
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //sets the cell of the array to
                    //the correct value based on the position in
                    //the single dimensional array
                    newArray[y, x] = array[y * width + x];
                }
            }

            //returns the new array
            return newArray;
        }
    }
}
