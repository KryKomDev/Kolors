namespace Kolors;

public class StringColors {
    public static string AddColor(string text, int hex) {
        return $"\x1b[38;2;{(byte)(hex >> 16)};{(byte)(hex >> 8)};{(byte)hex}m{text}\x1b[0m";
    }

    public static string AddColorB(string text, int hex) {
        return $"\x1b[48;2;{(byte)(hex >> 16)};{(byte)(hex >> 8)};{(byte)hex}m{text}\x1b[0m";
    }
}