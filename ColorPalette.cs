//
// Kolors
// by KryKom 2024
//

using System.Drawing;

namespace Kolors;

public class ColorPalette {

    private static readonly List<(string name, ColorPalette palette)> palettes = new();
    private static int maxNameLength = 0;
    
    public static readonly ColorPalette LAVENDER = Register("lavander", new ColorPalette([0xfdc5f5, 0xF7AEF8, 0xB388EB, 0x8093F1, 0x72DDF7]));
    public static readonly ColorPalette BLUE_WOOD = Register("blue_wood", new ColorPalette([0x483D3F, 0x058ED9, 0xF4EBD9, 0xA39A92, 0x77685D]));
    public static readonly ColorPalette RAINBOW = Register("rainbow", new ColorPalette("e6c229-f17105-d11149-6610f2-1a8fe3"));
    public static readonly ColorPalette DOWN = Register("down", new ColorPalette("003049-d62828-f77f00-fcbf49-eae2b7"));
    public static readonly ColorPalette BLUE_9 = Register("blue_9", new ColorPalette("03045e-023e8a-0077b6-0096c7-00b4d8-48cae4-90e0ef-ade8f4-caf0f8"));
    public static readonly ColorPalette DOWN_10 = Register("down_10", new ColorPalette("001219-005f73-0a9396-94d2bd-e9d8a6-ee9b00-ca6702-bb3e03-ae2012-9b2226"));
    public static readonly ColorPalette MARSHMELLOW = Register("marshmellow", new ColorPalette("ff99c8-fcf6bd-d0f4de-a9def9-e4c1f9"));
    public static readonly ColorPalette RED_10 = Register("red_10", new ColorPalette("03071e-370617-6a040f-9d0208-d00000-dc2f02-e85d04-f48c06-faa307-ffba08"));
    public static readonly ColorPalette COLORS = Register("colors", new ColorPalette("ef476f-ffd166-06d6a0-118ab2-073b4c"));
    public static readonly ColorPalette GRAY_9 = Register("gray_9", new ColorPalette("f8f9fa-e9ecef-dee2e6-ced4da-adb5bd-6c757d-495057-343a40-212529"));
    public static readonly ColorPalette BASE = Register("base", new ColorPalette("f8ffe5-06d6a0-1b9aaa-ef476f-ffc43d"));
    public static readonly ColorPalette IDEA = Register("idea", new ColorPalette("ced0d6-e9515f-ce7b47-62a660-c77dbb"));
    public static readonly ColorPalette STONE = Register("stone", new ColorPalette("bcd4de-a5ccd1-a0b9bf-9dacb2-949ba0"));
    
    public static readonly ColorPalette RED = Register("red", new ColorPalette("780116-f7b538-db7c26-d8572a-c32f27"));
    public static readonly ColorPalette ORANGE = Register("orange", new ColorPalette("cc5803-e2711d-ff9505-ffb627-ffc971"));
    public static readonly ColorPalette YELLOW = Register("yellow", new ColorPalette("fff75e-ffe94e-ffda3d-fdc43f-fdb833"));
    public static readonly ColorPalette GREEN = Register("green", new ColorPalette("5bba6f-3fa34d-2a9134-137547-054a29"));
    public static readonly ColorPalette GREEN_BROWN = Register("green-brown", new ColorPalette([0xDAD7CD, 0xA3B18A, 0x588157, 0x3A5A40, 0x344E41]));
    public static readonly ColorPalette CYAN = Register("cyan", new ColorPalette("07beb8-3dccc7-68d8d6-9ceaef-c4fff9"));
    public static readonly ColorPalette BLUE = Register("blue", new ColorPalette("03045e-0077b6-00b4d8-90e0ef-caf0f8"));
    public static readonly ColorPalette PINK = Register("pink", new ColorPalette("f08080-f4978e-f8ad9d-fbc4ab-ffdab9"));
    public static readonly ColorPalette PURPLE = Register("purple", new ColorPalette("231942-5e548e-9f86c0-be95c4-e0b1cb"));
    public static readonly ColorPalette BROWN = Register("brown", new ColorPalette("ede0d4-e6ccb2-ddb892-b08968-7f5539-9c6644"));

    public static readonly ColorPalette NONE = Register("none", new ColorPalette("ff0000-ff8800-ffee00-00ff00-0000ff"));
    
    private int[] colors { get; set; }
    
    /// <summary>
    /// returns the stored color palette as a set of integers, where the bytes mean AARRGGBB
    /// </summary>
    public int[] Colors => colors;
    
    /// <summary>
    /// returns the stored color palette
    /// </summary>
    public Color[] GetColors => colors.Select(Color.FromArgb).ToArray();

    /// <summary>
    /// creates a new color palette from a set of integers, where the bytes mean AARRGGBB
    /// </summary>
    /// <param name="colors"></param>
    public ColorPalette(int[] colors) {
        this.colors = colors;
    }

    
    /// <summary>
    /// registers a new palette
    /// </summary>
    public static ColorPalette Register(string name, ColorPalette palette) {

        foreach (var p in palettes) {
            if (p.name == name) {
                Debug.Error($"Could not add palette named '{name}'! Palette with the same name already exists.");
                return palette;
            }
        }

        maxNameLength = name.Length > maxNameLength ? name.Length : maxNameLength;
        
        palettes.Add((name, palette));
        return palette;
    }

    /// <summary>
    /// returns a palette from the registry by its name
    /// </summary>
    public static ColorPalette GetPalette(string name) {
        foreach ((string name, ColorPalette p) v in palettes) {
            if (v.name == name) {
                return v.p;
            }
        }

        return NONE;
    }

    /// <summary>
    /// creates a new palette from the format "rrggbb-rrggbb-..."
    /// </summary>
    /// <param name="url">the string</param>
    public ColorPalette(string url) {

        colors = new int[(url.Length + 1) / 7];

        for (int i = 0; i < url.Length; i += 7) {
            string colorRaw = "" + url[i] + url[i + 1] + url[i + 2] + url[i + 3] + url[i + 4] + url[i + 5];

            colors[i / 7] = int.Parse(colorRaw, System.Globalization.NumberStyles.HexNumber);
        }
    }

    /// <summary>
    /// prints a palette to the console
    /// </summary>
    public void PrintPalette() {
        foreach (int c in colors) {
            ConsoleColors.PrintColoredB("   ", c);
        }
        
        Console.Write("\n");
    }

    /// <summary>
    /// uses a custom action to print a palette 
    /// </summary>
    /// <param name="print">print delegate that prints a single color</param>
    public void PrintPalette(Action<int> print) {
        foreach (var c in colors) {
            print(c);
        }
        
        Console.Write("\n");
    }
    
    /// <summary>
    /// prints all registered palettes
    /// </summary>
    public static void PrintAllPalettes() {
        foreach (var p in palettes) {
            string name = p.name + ":";

            for (int i = maxNameLength - p.name.Length + 1; i >= 0; i--) {
                name += " ";
            }

            ConsoleColors.PrintColored(name, p.palette.colors[p.palette.colors.Length / 2]);
            // Console.Write(name);
            p.palette.PrintPalette();
        }
    }

    /// <summary>
    /// generates a new random visually pleasing palette 
    /// </summary>
    /// <param name="seed">seed for random</param>
    /// <param name="colorCount">how many colors will the palette contain</param>
    public static ColorPalette GeneratePalette(int seed, int colorCount = 10) {
        ColorPalette palette = new ColorPalette(new int[colorCount]);

        Random rnd = new Random(seed);
        
        var A = (rnd.NextSingle(), rnd.NextSingle(), rnd.NextSingle());
        var B = (rnd.NextSingle(), rnd.NextSingle(), rnd.NextSingle());
        var C = (rnd.NextSingle(), rnd.NextSingle(), rnd.NextSingle());
        var D = (rnd.NextSingle(), rnd.NextSingle(), rnd.NextSingle());

        for (int i = 0; i < colorCount; i++) {
            Color c = GenerateColorAtX(A, B, C, D, (float)i / colorCount);
            palette.colors[i] = c.R << 16 | c.G << 8 | c.B;
        }
        
        return palette;
    }

    /// <summary>
    /// returns the color located at X in a graph of <c>color = A + B * Cos(2 * PI * (Cx + D))</c>
    /// where A, B, C and D are 3d vectors representing a color (all their values should be between 1 and 0)
    /// </summary>
    public static Color GenerateColorAtX((double R, double G, double B) A, (double R, double G, double B) B,
        (double R, double G, double B) C, (double R, double G, double B) D, double x) 
    {
        Color result = Color.FromArgb(
            (byte)((A.R + B.R * Math.Cos(2 * Math.PI * (C.R * x + D.R))) * 255),
            (byte)((A.G + B.G * Math.Cos(2 * Math.PI * (C.G * x + D.G))) * 255),
            (byte)((A.B + B.B * Math.Cos(2 * Math.PI * (C.B * x + D.B))) * 255));
        
        return result;
    }
}