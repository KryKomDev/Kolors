//
// Kolors
// by KryKom 2024
//

using System.Drawing;

namespace Kolors;

public static class ConsoleColors {

    public static void Main() {
        // ColorPalette.NONE.printPalette();
        // ColorPalette.COLORS.printPalette();
        // ColorPalette.printAllPalettes();
        Debug.error("cus");
        Debug.warn("cus");
        Debug.info("cus");
        
        // Console.WriteLine(Clock.TWO);
        // Console.WriteLine(Clock.SIX);
        // Clock.printNumber(1234567890, 0x5f2c76);
        // DigitalClock.clock(0x5f2c76);
        // AnalogueClock.clock(ColorPalette.COLORS);
        
        // (int, int, int) hsv = ()
        
        void action() {
            (int r, int g, int b) c = ColorFormat.ColorFromHSV(DateTime.Now.Second * 180 + 100, 1, 1);
            DigitalClock.COLOR = (c.r << 16) + (c.g << 8) + c.b;
        }
        
        DigitalClock.clock(0xff0000, action);
    }
    
    /// <summary>
    /// prints a colored string in the console without newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="hex">hexadecimal value of the color</param>
    public static void printColored(string s, int hex) {
        Console.Write($"\x1b[38;2;{(byte)(hex >> 16)};{(byte)(hex >> 8)};{(byte)hex}m{s}\x1b[0m");
    }

    /// <summary>
    /// TODO summary
    /// </summary>
    /// <param name="s"></param>
    /// <param name="colors"></param>
    public static void printComplexColored(string s, (string replaced, int hex)[] colors) {
        foreach (var c in colors) {
            s = s.Replace(c.replaced, $"\x1b[38;2;{(byte)(c.hex >> 16)};{(byte)(c.hex >> 8)};{(byte)c.hex}m");
        }
        
        Console.Write(s);
    }
    
    /// <summary>
    /// prints a colored string in the console with newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="hex">hexadecimal value of the color</param>
    public static void printlnColored(string s, int hex) {
        Console.Write($"\x1b[38;2;{(byte)(hex >> 16)};{(byte)(hex >> 8)};{(byte)hex}m{s}\x1b[0m\n");
    }
    
    /// <summary>
    /// TODO summary
    /// </summary>
    /// <param name="s"></param>
    /// <param name="colors"></param>
    public static void printlnComplexColored(string s, (string replaced, int hex)[] colors) {
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
    public static void printColored(string s, byte r, byte g, byte b) {
        Console.Write($"\x1b[38;2;{r};{g};{b}m{s}\x1b[0m");
    }
    
    /// <summary>
    /// prints a colored string in the console with newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="r">red value of the color</param>
    /// <param name="g">green value of the color</param>
    /// <param name="b">blue value of the color</param>
    public static void printlnColored(string s, byte r, byte g, byte b) {
        Console.Write($"\x1b[38;2;{r};{g};{b}m{s}\x1b[0m\n");
    }
    
    /// <summary>
    /// prints a string with colored background in the console without newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="hex">hexadecimal value of the color</param>
    public static void printColoredB(string s, int hex) {
        Console.Write($"\x1b[48;2;{(byte)(hex >> 16)};{(byte)(hex >> 8)};{(byte)hex}m{s}\x1b[0m");
    }
    
    /// <summary>
    /// prints a string with colored background in the console with newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="hex">hexadecimal value of the color</param>
    public static void printlnColoredB(string s, int hex) {
        Console.Write($"\x1b[48;2;{(byte)(hex >> 16)};{(byte)(hex >> 8)};{(byte)hex}m{s}\x1b[0m\n");
    }
    
    /// <summary>
    /// prints a string with colored background in the console without newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="r">red value of the color</param>
    /// <param name="g">green value of the color</param>
    /// <param name="b">blue value of the color</param>
    public static void printColoredB(string s, byte r, byte g, byte b) {
        Console.Write($"\x1b[48;2;{r};{g};{b}m{s}\x1b[0m");
    }
    
    /// <summary>
    /// prints a string with colored background in the console with newline
    /// </summary>
    /// <param name="s">string to print</param>
    /// <param name="r">red value of the color</param>
    /// <param name="g">green value of the color</param>
    /// <param name="b">blue value of the color</param>
    public static void printlnColoredB(string s, byte r, byte g, byte b) {
        Console.Write($"\x1b[48;2;{r};{g};{b}m{s}\x1b[0m\n");
    }
}