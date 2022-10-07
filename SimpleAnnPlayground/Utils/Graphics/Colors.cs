// <copyright file="Colors.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

namespace SimpleAnnPlayground.Utils.Graphics
{
    /// <summary>
    /// Utility task to work with colors.
    /// </summary>
    internal static class Colors
    {
        private const double Gamma = 0.43;

        /// <summary>
        /// Calculates the color gradient between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="ratio">The gradient ratio from 0 to 1.</param>
        /// <returns>The correspondet color from the gradient.</returns>
        public static Color GetGradient(Color start, Color end, double ratio)
        {
            var color1 = FromRgb(start);
            double bright1 = Bright(color1);
            var color2 = FromRgb(end);
            double bright2 = Bright(color2);

            double intensity = Math.Pow(Lerp(bright1, bright2, ratio), 1.0 / Gamma);
            var color = Lerp(color1, color2, ratio);
            double Normalize(double c) => c * intensity / Sum(color);
            (double, double, double) NormalizeIntensity((double, double, double) c) => (Normalize(c.Item1), Normalize(c.Item2), Normalize(c.Item3));
            if (Sum(color) != 0) color = NormalizeIntensity(color);
            return ToRgb(color);
        }

        /// <summary>
        /// Calculates the color gradient between two colors passing for white.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="ratio">The gradient ratio from 0 to 1.</param>
        /// <returns>The correspondet color from the gradient.</returns>
        public static Color WhiteGradient(Color start, Color end, double ratio)
        {
            return ratio < 0.5 ? GetGradient(start, Color.White, ratio * 2) : GetGradient(Color.White, end, (ratio - 0.5) * 2);
        }

        private static Color ToRgb((double, double, double) c)
        {
            static double SrgbF(double c) => c <= 0.0031308 ? 12.92 * c : 1.055 * Math.Pow(c, 1.0 / 2.4) - 0.055;
            static int Srgb(double c) => (int)(255.9999 * SrgbF(c));
            return Color.FromArgb(Srgb(c.Item1), Srgb(c.Item2), Srgb(c.Item3));
        }

        private static double Sum((double, double, double) c) => c.Item1 + c.Item2 + c.Item3;

        private static double Bright((double, double, double) c) => Math.Pow(Sum(c), Gamma);

        private static double Lerp(double color1, double color2, double ratio)
        {
            return color1 * (1.0 - ratio) + color2 * ratio;
        }

        private static (double, double, double) Lerp((double, double, double) color1, (double, double, double) color2, double ratio)
        {
            return (Lerp(color1.Item1, color2.Item1, ratio), Lerp(color1.Item2, color2.Item2, ratio), Lerp(color1.Item3, color2.Item3, ratio));
        }

        private static (double, double, double) FromRgb(Color color)
        {
            static double NormalizeColor(byte value) => value / 255.0;
            static double Linear(byte c)
            {
                double x = NormalizeColor(c);
                return x <= 0.04045 ? x / 12.92 : Math.Pow((x + 0.055) / 1.055, 2.4);
            }

            return (Linear(color.R), Linear(color.G), Linear(color.B));
        }
    }
}
