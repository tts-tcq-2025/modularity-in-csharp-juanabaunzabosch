using System;
using System.Diagnostics;
using System.Drawing;
using static TelCo.ColorCoder.Program;

namespace TelCo.ColorCoder.Services
{
    public class AssertService
    {
        internal static void AssertPairNumber(int pairNumber, Color expectedMajor, Color expectedMinor, Color[] colorMapMajor, Color[] colorMapMinor)
        {
            ColorPair testPair = ColorFromPairNumber.GetColorFromPairNumber(pairNumber, colorMapMajor, colorMapMinor);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair);
            Debug.Assert(testPair.majorColor == expectedMajor);
            Debug.Assert(testPair.minorColor == expectedMinor);
        }

        internal static void AssertColorToPairNumber(Color majorColor, Color minorColor, int expectedPairNumber, Color[] colorMapMajor, Color[] colorMapMinor)
        {
            ColorPair testPair = new ColorPair() { majorColor = majorColor, minorColor = minorColor };
            int pairNumber = PairNumberFromColor.GetPairNumberFromColor(testPair, colorMapMajor, colorMapMinor);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair, pairNumber);
            Debug.Assert(pairNumber == expectedPairNumber, $"Pair number mismatch for color pair {testPair}. Expected {expectedPairNumber}, got {pairNumber}.");
        }
    }
}
