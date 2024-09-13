namespace Kolors;

public class VisualConsole {
    public static void printMap(int?[,] map, bool oneColor) {
        for (int x = 0; x < map.GetLength(0); x++) {
            for (int y = 0; y < map.GetLength(1); y++) {
                if (map[x, y] is null) Console.Write("   ");
                else if (map[x, y] == 0) ConsoleColors.printColoredB("   ", 0x000000);
                else if (oneColor) ConsoleColors.printColoredB("   ", 0xffffff);
                else ConsoleColors.printColoredB("   ", 
                        ColorFormat.HsvToInt((float)(map[x, y] / 60f)!, 1, 1));
            }
            
            Console.WriteLine();
        }
    }
    
    public static void printMap(float?[,] map, bool oneColor) {
        for (int x = 0; x < map.GetLength(0); x++) {
            for (int y = 0; y < map.GetLength(1); y++) {
                if (map[x, y] is null) Console.Write("   ");
                else if (map[x, y] == 0) ConsoleColors.printColoredB("   ", 0x000000);
                else if (oneColor) ConsoleColors.printColoredB("   ", 0xffffff);
                else ConsoleColors.printColoredB("   ", 
                    ColorFormat.HsvToInt((float)map[x, y]!, 1, 1));
            }
            
            Console.WriteLine();
        }
    }

    public static void printVMap(((int x, int y) a, (int x, int y) b)[] vmap, int xSize, int ySize) {
        char[,] img = new char[xSize, ySize];
        
        foreach (var vert in vmap) {
            if (vert.a.x == vert.b.x) {
                for (int y = Math.Min(vert.a.y, vert.b.y); y < Math.Max(vert.a.y, vert.b.y); y++) {
                    img[vert.a.x, y] = '\u2551';
                }
            }
            else {
                for (int x = Math.Min(vert.a.x, vert.b.x); x < Math.Max(vert.a.x, vert.b.x); x++) {
                    img[x, vert.a.y] = '\u2550';
                }
            }
        }

        for (int x = 0; x < xSize; x++) {
            for (int y = 0; y < ySize; y++) {
                Console.Write(img[x, y]);
            }
            
            Console.WriteLine();
        }
    }
}