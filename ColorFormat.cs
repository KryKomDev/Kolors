using System.Drawing;

namespace Kolors;

public class ColorFormat {
    public static void ColorToHSV(Color color, out double hue, out double saturation, out double value) {
        int max = Math.Max(color.R, Math.Max(color.G, color.B));
        int min = Math.Min(color.R, Math.Min(color.G, color.B));

        hue = color.GetHue();
        saturation = (max == 0) ? 0 : 1d - (1d * min / max);
        value = max / 255d;
    }

    public static (int r, int g, int b) ColorFromHSV(double hue, double saturation, double value) {
        int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
        double f = hue / 60 - Math.Floor(hue / 60);
        
        value = value * 255;
        int v = Convert.ToInt32(value);
        int p = Convert.ToInt32(value * (1 - saturation));
        int q = Convert.ToInt32(value * (1 - f * saturation));
        int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

        if (hi == 0) return (v, t, p);
        else if (hi == 1) return (q, v, p);
        else if (hi == 2) return (p, v, t);
        else if (hi == 3) return (p, q, v);
        else if (hi == 4) return ( t, p, v);
        else return (v, p, q);
    }
    
    public static int HsvToInt(float h, float s, float v){
        // Convert HSV to RGB
        (int r, int g, int b) c = ColorFromHSV(h, s, v);

        // Convert RGB to HEX
        return c.r << 16 | c.g << 8 | c.b;
    }
}