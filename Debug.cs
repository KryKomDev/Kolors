//
// Kolors
// by KryKom 2024
//

namespace Kolors;

/// <summary>
/// debug console utils 
/// </summary>
public static class Debug {

    public static int warnColor { get; set; } = ColorPalette.COLORS.colors[1];
    public static int errorColor { get; set; } = ColorPalette.COLORS.colors[0];
    public static int infoColor { get; set; } = ColorPalette.COLORS.colors[2];

    /// <summary>
    /// what will be shown in the console <br/>
    /// 0 - nothing <br/>
    /// 1 - error <br/>
    /// 2 - error + warn <br/>
    /// 3 - error + warn + info <br/>
    /// </summary>
    public static DebugLevel debugLevel { get; set; } = DebugLevel.ERRORS_WARNS;
    
    public enum DebugLevel {
        NOTHING = 0,
        ONLY_ERRORS = 1,
        ERRORS_WARNS = 2,
        ALL = 3,
    }
    
    /// <summary>
    /// prints red error text
    /// </summary>
    /// <param name="s">desired string message</param>
    /// <param name="hideTime">hides time if true</param>
    public static void error(string s, bool hideTime = false) {
        if (debugLevel >= DebugLevel.ONLY_ERRORS) 
            ConsoleColors.printColored(hideTime ? $"ERROR: {s}\n" : $"[{DateTime.Now:HH:mm:ss}] ERROR: {s}\n", errorColor);
    }

    /// <summary>
    /// prints yellow warning text
    /// </summary>
    /// <param name="s">desired string message</param>
    /// <param name="hideTime">hides time if true</param>
    public static void warn(string s, bool hideTime = false) {
        if (debugLevel >= DebugLevel.ERRORS_WARNS) 
            ConsoleColors.printColored(hideTime ? $"WARN: {s}\n" : $"[{DateTime.Now:HH:mm:ss}] WARN: {s}\n", warnColor);
    }
    
    /// <summary>
    /// prints green info text
    /// </summary>
    /// <param name="s">desired string message</param>
    /// <param name="hideTime">hides time if true</param>
    public static void info(string s, bool hideTime = false) {
        if (debugLevel >= DebugLevel.ALL) 
            ConsoleColors.printColored(hideTime ? $"INFO: {s}\n" : $"[{DateTime.Now:HH:mm:ss}] INFO: {s}\n", infoColor);
    }
}