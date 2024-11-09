namespace Kolors.console;

public class ConsoleProgressBar {
    
    private readonly int barSize;
    private readonly int minValue;
    private readonly int maxValue;
    private int currentValue = 0;
    private readonly BarStyle barStyle;
    
    private const int OFFSET = 1;

    public ConsoleProgressBar(int minValue, int maxValue, int barSize = 10, BarStyle barStyle = BarStyle.CLASSIC) {
        this.barSize = barSize;
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.barStyle = barStyle;
        Console.CursorVisible = false;
        StartProgressBar();
    }

    public void EndProgressBar() {
        Console.WriteLine();
        Console.CursorVisible = true;
    }

    public void OnProgressUpdate(object? sender, EventArgs e) {
        currentValue++;
        UpdateProgressBar();
    }

    private void StartProgressBar() {
        PrintBarStart();

        for (int i = 0; i < barSize; i++) {
            PrintBarPart(false);
        }
        
        PrintBarEnd();

        Console.CursorLeft = OFFSET;
    }

    private void UpdateProgressBar() {
        int steps = (int)((1 - (float)(maxValue - minValue - currentValue) / (maxValue - minValue)) * barSize);
        Console.CursorLeft = OFFSET;
        
        for (int i = 0; i < steps; i++) {
            PrintBarPart(true);
        }
    }

    private void PrintBarPart(bool state) {
        switch (barStyle) {
            case BarStyle.CLASSIC:
                ConsoleColors.PrintColored(CLASSIC_BAR, state ? Debug.InfoColor : Debug.ErrorColor);
                break;
            case BarStyle.MODERN:
                ConsoleColors.PrintColored(MODERN_BAR, state ? Debug.InfoColor : Debug.ErrorColor);
                break;
            case BarStyle.MODERN_THIN:
                ConsoleColors.PrintColored(MODERN_THIN_BAR, state ? Debug.InfoColor : Debug.ErrorColor);
                break;
            case BarStyle.MODERN_DOUBLE:
                ConsoleColors.PrintColored(MODERN_DOUBLE_BAR, state ? Debug.InfoColor : Debug.ErrorColor);
                break;
        }
    }

    private void PrintBarStart() {
        switch (barStyle) {
            case BarStyle.CLASSIC:
                Console.Write(CLASSIC_START);
                break;
            case BarStyle.MODERN:
                Console.Write(MODERN_START);
                break;
            case BarStyle.MODERN_THIN:
                Console.Write(MODERN_START);
                break;
            case BarStyle.MODERN_DOUBLE:
                Console.Write(MODERN_START);
                break;
        }
    }
    
    private void PrintBarEnd() {
        switch (barStyle) {
            case BarStyle.CLASSIC:
                Console.Write(CLASSIC_END);
                break;
            case BarStyle.MODERN:
                Console.Write(MODERN_END);
                break;
            case BarStyle.MODERN_THIN:
                Console.Write(MODERN_END);
                break;
            case BarStyle.MODERN_DOUBLE:
                Console.Write(MODERN_END);
                break;
        }
    }

    public enum BarStyle {
        CLASSIC,
        MODERN,
        MODERN_DOUBLE,
        MODERN_THIN
    }

    private const string CLASSIC_START = "[";
    private const string CLASSIC_BAR = "=";
    private const string CLASSIC_END = "]";
    
    private const string MODERN_START = " ";
    private const string MODERN_END = " ";
    private const string MODERN_BAR = "━";
    private const string MODERN_DOUBLE_BAR = "═";
    private const string MODERN_THIN_BAR = "─";
}