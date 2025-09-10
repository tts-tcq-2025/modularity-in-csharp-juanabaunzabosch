using System;
using System.Diagnostics;
using System.Drawing;
using TelCo.ColorCoder.Services;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// The 25-pair color code, originally known as even-count color code, 
    /// is a color code used to identify individual conductors in twisted-pair 
    /// wiring for telecommunications.
    /// This class provides the color coding and 
    /// mapping of pair number to color and color to pair number.
    /// </summary>
    class Program
    {
        private static Color[] colorMapMajor;
        private static Color[] colorMapMinor;
        internal class ColorPair
        {
            internal Color majorColor;
            internal Color minorColor;
            public override string ToString()
            {
                return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
            }
        }
        /// <summary>
        /// Static constructor required to initialize static variable
        /// </summary>
        static Program()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }
        /// <summary>
        /// Test code for the class
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            AssertService.AssertPairNumber(4, Color.White, Color.Brown, colorMapMajor, colorMapMinor);
            AssertService.AssertPairNumber(5, Color.White, Color.SlateGray, colorMapMajor, colorMapMinor);
            AssertService.AssertPairNumber(23, Color.Violet, Color.Green, colorMapMajor, colorMapMinor);
            AssertService.AssertColorToPairNumber(Color.Yellow, Color.Green, 18, colorMapMajor, colorMapMinor);
            AssertService.AssertColorToPairNumber(Color.Red, Color.Blue, 6, colorMapMajor, colorMapMinor);
        }
    }
}