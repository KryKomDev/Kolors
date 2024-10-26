//
// Kolors - Colored Console Utils
// by KryKom 2024
//

namespace Kolors;

/// <summary>
/// debug console utils 
/// </summary>
public static class Debug {
    private static int warnColor { get; set; } = ColorPalette.COLORS.colors[1];

    public static int WarnColor {
        get => warnColor;
        set => warnColor = value;
    }
    
    private static int errorColor { get; set; } = ColorPalette.COLORS.colors[0];

    public static int ErrorColor {
        get => errorColor;
        set => errorColor = value;
    }
    
    private static int infoColor { get; set; } = ColorPalette.COLORS.colors[2];

    public static int InfoColor {
        get => infoColor;
        set => infoColor = value;
    }
    
    /// <summary>
    /// what will be shown in the console <br/>
    /// 0 - nothing <br/>
    /// 1 - error <br/>
    /// 2 - error + warn <br/>
    /// 3 - error + warn + info <br/>
    /// </summary>
    private static DebugLevel level { get; set; } = DebugLevel.ERRORS_WARNS;

    public static DebugLevel Level {
        get => level;
        set => level = value;
    }
    
    public enum DebugLevel {
        NOTHING = 0,
        ONLY_ERRORS = 1,
        ERRORS_WARNS = 2,
        ALL = 3
    }
    
    /// <summary>
    /// prints red error text
    /// </summary>
    /// <param name="s">desired string message</param>
    /// <param name="hideTime">hides time if true</param>
    public static void Error(string s, bool hideTime = false) {
        if (level >= DebugLevel.ONLY_ERRORS) 
            ConsoleColors.PrintColored(hideTime ? $"\x1B[1mERROR: {s}\n" : $"[{DateTime.Now:HH:mm:ss}] ERROR: {s}\n", errorColor);
    }

    /// <summary>
    /// prints yellow warning text
    /// </summary>
    /// <param name="s">desired string message</param>
    /// <param name="hideTime">hides time if true</param>
    public static void Warn(string s, bool hideTime = false) {
        if (level >= DebugLevel.ERRORS_WARNS) 
            ConsoleColors.PrintColored(hideTime ? $"WARN: {s}\n" : $"[{DateTime.Now:HH:mm:ss}] WARN: {s}\n", warnColor);
    }
    
    /// <summary>
    /// prints green info text
    /// </summary>
    /// <param name="s">desired string message</param>
    /// <param name="hideTime">hides time if true</param>
    public static void Info(string s, bool hideTime = false) {
        if (level >= DebugLevel.ALL) 
            ConsoleColors.PrintColored(hideTime ? $"INFO: {s}\n" : $"[{DateTime.Now:HH:mm:ss}] INFO: {s}\n", infoColor);
    }
}