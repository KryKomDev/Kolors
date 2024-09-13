//
// Kolors
// by KryKom 2024
//

namespace Kolors;

public struct ColorPalette {

    public static readonly List<(string name, ColorPalette palette)> palettes = new();
    private static int maxNameLength = 0;
    
    public static ColorPalette LAVENDER = register("lavander", new ColorPalette([0xfdc5f5, 0xF7AEF8, 0xB388EB, 0x8093F1, 0x72DDF7]));
    public static ColorPalette BLUE_WOOD = register("blue_wood", new ColorPalette([0x483D3F, 0x058ED9, 0xF4EBD9, 0xA39A92, 0x77685D]));
    public static ColorPalette RAINBOW = register("rainbow", new ColorPalette("e6c229-f17105-d11149-6610f2-1a8fe3"));
    public static ColorPalette DOWN = register("down", new ColorPalette("003049-d62828-f77f00-fcbf49-eae2b7"));
    public static ColorPalette BLUE_9 = register("blue_9", new ColorPalette("03045e-023e8a-0077b6-0096c7-00b4d8-48cae4-90e0ef-ade8f4-caf0f8"));
    public static ColorPalette DOWN_10 = register("down_10", new ColorPalette("001219-005f73-0a9396-94d2bd-e9d8a6-ee9b00-ca6702-bb3e03-ae2012-9b2226"));
    public static ColorPalette MARSHMELLOW = register("marshmellow", new ColorPalette("ff99c8-fcf6bd-d0f4de-a9def9-e4c1f9"));
    public static ColorPalette RED_10 = register("red_10", new ColorPalette("03071e-370617-6a040f-9d0208-d00000-dc2f02-e85d04-f48c06-faa307-ffba08"));
    public static ColorPalette COLORS = register("colors", new ColorPalette("ef476f-ffd166-06d6a0-118ab2-073b4c"));
    public static ColorPalette GRAY_9 = register("gray_9", new ColorPalette("f8f9fa-e9ecef-dee2e6-ced4da-adb5bd-6c757d-495057-343a40-212529"));
    public static ColorPalette BASE = register("base", new ColorPalette("f8ffe5-06d6a0-1b9aaa-ef476f-ffc43d"));
    public static ColorPalette IDEA = register("idea", new ColorPalette("ced0d6-e9515f-ce7b47-62a660-c77dbb"));
    public static ColorPalette STONE = register("stone", new ColorPalette("bcd4de-a5ccd1-a0b9bf-9dacb2-949ba0"));
    
    public static ColorPalette RED = register("red", new ColorPalette("780116-f7b538-db7c26-d8572a-c32f27"));
    public static ColorPalette ORANGE = register("orange", new ColorPalette("cc5803-e2711d-ff9505-ffb627-ffc971"));
    public static ColorPalette YELLOW = register("yellow", new ColorPalette("fff75e-ffe94e-ffda3d-fdc43f-fdb833"));
    public static ColorPalette GREEN = register("green", new ColorPalette("5bba6f-3fa34d-2a9134-137547-054a29"));
    public static ColorPalette GREEN_BROWN = register("green-brown", new ColorPalette([0xDAD7CD, 0xA3B18A, 0x588157, 0x3A5A40, 0x344E41]));
    public static ColorPalette CYAN = register("cyan", new ColorPalette("07beb8-3dccc7-68d8d6-9ceaef-c4fff9"));
    public static ColorPalette BLUE = register("blue", new ColorPalette("03045e-0077b6-00b4d8-90e0ef-caf0f8"));
    public static ColorPalette PINK = register("pink", new ColorPalette("f08080-f4978e-f8ad9d-fbc4ab-ffdab9"));
    public static ColorPalette PURPLE = register("purple", new ColorPalette("231942-5e548e-9f86c0-be95c4-e0b1cb"));
    public static ColorPalette BROWN = register("brown", new ColorPalette("ede0d4-e6ccb2-ddb892-b08968-7f5539-9c6644"));

    public static ColorPalette NONE = register("none", new ColorPalette("ff0000-ff8800-ffee00-00ff00-0000ff"));
    
    public int[] colors { get; private set; }

    public ColorPalette(int[] colors) {
        this.colors = colors;
    }

    public static ColorPalette register(string name, ColorPalette palette) {

        foreach (var p in palettes) {
            if (p.name == name) {
                Debug.error($"Could not add palette named '{name}'! Palette with the same name already exists.");
                return palette;
            }
        }

        maxNameLength = name.Length > maxNameLength ? name.Length : maxNameLength;
        
        palettes.Add((name, palette));
        return palette;
    }

    public static ColorPalette getPalette(string name) {
        foreach ((string name, ColorPalette p) v in palettes) {
            if (v.name == name) {
                return v.p;
            }
        }

        return NONE;
    }

    public ColorPalette(string url) {

        colors = new int[(url.Length + 1) / 7];

        for (int i = 0; i < url.Length; i += 7) {
            string colorRaw = "" + url[i] + url[i + 1] + url[i + 2] + url[i + 3] + url[i + 4] + url[i + 5];

            colors[i / 7] = int.Parse(colorRaw, System.Globalization.NumberStyles.HexNumber);
        }
    }

    public void printPalette() {
        foreach (int c in colors) {
            ConsoleColors.printColoredB("   ", c);
        }
        
        Console.Write("\n");
    }
    
    public static void printAllPalettes() {
        foreach (var p in palettes) {
            string name = p.name + ":";

            for (int i = maxNameLength - p.name.Length + 1; i >= 0; i--) {
                name += " ";
            }

            ConsoleColors.printColored(name, p.palette.colors[p.palette.colors.Length / 2]);
            // Console.Write(name);
            p.palette.printPalette();
        }
    }
}