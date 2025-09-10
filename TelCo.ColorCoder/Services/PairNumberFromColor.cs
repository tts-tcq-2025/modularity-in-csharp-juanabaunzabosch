using System;
using System.Drawing;
using static TelCo.ColorCoder.Program;

namespace TelCo.ColorCoder.Services
{
    public class PairNumberFromColor
    {
        /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="pair">Color pair with major and minor color</param>
        /// <returns></returns>
        internal static int GetPairNumberFromColor(ColorPair pair, Color[] colorMapMajor, Color[] colorMapMinor)
        {
            // Find the major color in the array and get the index
            int majorIndex = FindColor(pair.majorColor, colorMapMajor);

            // Find the minor color in the array and get the index
            int minorIndex = FindColor(pair.minorColor, colorMapMinor);

            // If colors can not be found throw an exception
            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            // Compute pair number and Return  
            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }

        private static int FindColor(Color color, Color[] colorMap)
        {
            int index = -1;
            for (int i = 0; i < colorMap.Length; i++)
            {
                if (colorMap[i] == color)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
