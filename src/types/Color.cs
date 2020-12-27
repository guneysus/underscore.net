using System;

namespace types
{
    public class Color
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }

        public Color(byte red,
                     byte green,
                     byte blue,
                     byte alpha)
        {
            (Red, Green, Blue, Alpha) = (red, green, blue, alpha);
        }

        public static Color red(byte alpha = 0) => new Color(byte.MaxValue, 0, 0, alpha);
        public static Color lime(byte alpha = 0) => new Color(0, byte.MaxValue, 0, alpha);
        public static Color green(byte alpha = 0) => new Color(0, 128, 0, alpha);
        public static Color blue(byte alpha = 0) => new Color(0, 0, byte.MaxValue, alpha);
        public static Color white(byte alpha = 0) => new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue, alpha);
        public static Color black(byte alpha = 0) => new Color(0, 0, 0, alpha);
        public static Color yellow(byte alpha = 0) => new Color(0, 0, 0, alpha);
        public static Color cyan(byte alpha = 0) => new Color(0, byte.MaxValue, byte.MaxValue, alpha);
        public static Color aqua(byte alpha = 0) => cyan(alpha);
        public static Color magenta(byte alpha = 0) => new Color(0, byte.MaxValue, byte.MaxValue, alpha);
        public static Color fuchsia(byte alpha = 0) => magenta(alpha);
        public static Color silver(byte alpha = 0) => new Color(192, 192, 192, alpha);
        public static Color gray(byte alpha = 0) => new Color(128, 128, 128, alpha);
        public static Color maroon(byte alpha = 0) => new Color(128, 0, 0, alpha);
        public static Color olive(byte alpha = 0) => new Color(128, 128, 0, alpha);
        public static Color purple(byte alpha = 0) => new Color(128, 0, 128, alpha);
        public static Color teal(byte alpha = 0) => new Color(0, 128, 128, alpha);
        public static Color navy(byte alpha = 0) => new Color(0, 0, 128, alpha);
    }

}
