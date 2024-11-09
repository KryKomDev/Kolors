//
// Kolors - Colored Console Utils
// by KryKom 2024
//

namespace Kolors.console;

public static class ConsoleColors {

    public static void Main() {
        for (int i = 0; i < 100; i++) {
            ColorPalette cp = ColorPalette.GeneratePalette(i, 100);
            cp.PrintPalette(color => PrintColoredB(" ", color));
            Console.WriteLine();
        }
    }
    
    /// <summary>
    /// prints a colored string in the console without newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="hex">hexadecimal value of the color</param>
    public static void PrintColored(string s, int hex) {
        Console.Write($"\x1b[38;2;{(byte)(hex >> 16)};{(byte)(hex >> 8)};{(byte)hex}m{s}\x1b[0m");
    }

    /// <summary>
    /// prints a string with its characters colored using string symbols
    /// </summary>
    /// <param name="s">source string</param>
    /// <param name="colors">
    /// tuple of symbol string and hexadecimal color representation,
    /// with which will the symbol be replaced,
    /// if a color is -1 the colors will be reset
    /// </param>
    public static void PrintComplexColored(string s, (string symbol, int hex)[] colors) {
        foreach (var c in colors) {
            
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (c.hex == -1) {
                s = s.Replace(c.symbol, "\x1b[0m");
            }
            else {
                s = s.Replace(c.symbol, $"\x1b[38;2;{(byte)(c.hex >> 16)};{(byte)(c.hex >> 8)};{(byte)c.hex}m");
            }
        }
        
        Console.Write(s);
    }
    
    /// <summary>
    /// prints a colored string in the console with newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="hex">hexadecimal value of the color</param>
    public static void PrintlnColored(string s, int hex) {
        Console.Write($"\x1b[38;2;{(byte)(hex >> 16)};{(byte)(hex >> 8)};{(byte)hex}m{s}\x1b[0m\n");
    }
    
    /// <summary>
    /// prints a string with its background colored using string symbols
    /// </summary>
    /// <param name="s">source string</param>
    /// <param name="colors">
    /// tuple of symbol string and hexadecimal color representation,
    /// with which will the symbol be replaced,
    /// if a color is -1 the colors will be reset
    /// </param>
    public static void PrintlnComplexColored(string s, (string replaced, int hex)[] colors) {
        foreach (var c in colors) {
            s = s.Replace(c.replaced, $"\x1b[38;2;{(byte)(c.hex >> 16)};{(byte)(c.hex >> 8)};{(byte)c.hex}m");
        }
        
        Console.WriteLine(s);
    }
    
    /// <summary>
    /// prints a colored string in the console without newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="r">red value of the color</param>
    /// <param name="g">green value of the color</param>
    /// <param name="b">blue value of the color</param>
    public static void PrintColored(string s, byte r, byte g, byte b) {
        Console.Write($"\x1b[38;2;{r};{g};{b}m{s}\x1b[0m");
    }
    
    /// <summary>
    /// prints a colored string in the console with newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="r">red value of the color</param>
    /// <param name="g">green value of the color</param>
    /// <param name="b">blue value of the color</param>
    public static void PrintlnColored(string s, byte r, byte g, byte b) {
        Console.Write($"\x1b[38;2;{r};{g};{b}m{s}\x1b[0m\n");
    }
    
    /// <summary>
    /// prints a string with colored background in the console without newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="hex">hexadecimal value of the color</param>
    public static void PrintColoredB(string s, int hex) {
        Console.Write($"\x1b[48;2;{(byte)(hex >> 16)};{(byte)(hex >> 8)};{(byte)hex}m{s}\x1b[0m");
    }
    
    /// <summary>
    /// prints a string with colored background in the console with newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="hex">hexadecimal value of the color</param>
    public static void PrintlnColoredB(string s, int hex) {
        Console.Write($"\x1b[48;2;{(byte)(hex >> 16)};{(byte)(hex >> 8)};{(byte)hex}m{s}\x1b[0m\n");
    }
    
    /// <summary>
    /// prints a string with colored background in the console without newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="r">red value of the color</param>
    /// <param name="g">green value of the color</param>
    /// <param name="b">blue value of the color</param>
    public static void PrintColoredB(string s, byte r, byte g, byte b) {
        Console.Write($"\x1b[48;2;{r};{g};{b}m{s}\x1b[0m");
    }
    
    /// <summary>
    /// prints a string with colored background in the console with newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="r">red value of the color</param>
    /// <param name="g">green value of the color</param>
    /// <param name="b">blue value of the color</param>
    public static void PrintlnColoredB(string s, byte r, byte g, byte b) {
        Console.Write($"\x1b[48;2;{r};{g};{b}m{s}\x1b[0m\n");
    }
}