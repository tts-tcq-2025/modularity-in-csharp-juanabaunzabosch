using System;
using System.Diagnostics;
using System.Drawing;
using static TelCo.ColorCoder.Program;

namespace TelCo.ColorCoder.Services
{
    public class ColorCoderService
    {
        /// <summary>
        /// Given a pair number function returns the major and minor colors in that order
        /// </summary>
        /// <param name="pairNumber">Pair number of the color to be fetched</param>
        /// <returns></returns>
        internal static ColorPair GetColorFromPairNumber(int pairNumber, Color[] colorMapMajor, Color[] colorMapMinor)
        {
            // The function supports only 1 based index. Pair numbers valid are from 1 to 25
            int minorSize = colorMapMinor.Length;
            int majorSize = colorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            // Find index of major and minor color from pair number
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;

            // Construct the return val from the arrays
            ColorPair pair = new ColorPair()
            {
                majorColor = colorMapMajor[majorIndex],
                minorColor = colorMapMinor[minorIndex]
            };

            // return the value
            return pair;
        }
        /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="pair">Color pair with major and minor color</param>
        /// <returns></returns>
        internal static int GetPairNumberFromColor(ColorPair pair, Color[] colorMapMajor, Color[] colorMapMinor)
        {
            // Find the major color in the array and get the index
            int majorIndex = -1;
            for (int i = 0; i < colorMapMajor.Length; i++)
            {
                if (colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            }

            // Find the minor color in the array and get the index
            int minorIndex = -1;
            for (int i = 0; i < colorMapMinor.Length; i++)
            {
                if (colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            }
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
        internal static void AssertPairNumber(int pairNumber, Color expectedMajor, Color expectedMinor, Color[] colorMapMajor, Color[] colorMapMinor)
        {
            ColorPair testPair = GetColorFromPairNumber(pairNumber, colorMapMajor, colorMapMinor);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair);
            Debug.Assert(testPair.majorColor == expectedMajor);
            Debug.Assert(testPair.minorColor == expectedMinor);
        }

        internal static void AssertColorToPairNumber(Color majorColor, Color minorColor, int expectedPairNumber, Color[] colorMapMajor, Color[] colorMapMinor)
        {
            ColorPair testPair = new ColorPair() { majorColor = majorColor, minorColor = minorColor };
            int pairNumber = GetPairNumberFromColor(testPair, colorMapMajor, colorMapMinor);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair, pairNumber);
            Debug.Assert(pairNumber == expectedPairNumber, $"Pair number mismatch for color pair {testPair}. Expected {expectedPairNumber}, got {pairNumber}.");
        }
    }
}
