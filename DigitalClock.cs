using System.Timers;

namespace Kolors;

public class DigitalClock {
    public static readonly string[] ZERO = [" ██████ " , " ██  ██ " , " ██  ██ " , " ██  ██ " , " ██████ "];
    public static readonly string[] ONE = ["     ██ " , "     ██ " , "     ██ " , "     ██ " , "     ██ "];
    public static readonly string[] TWO = [" ██████ " , "     ██ " , " ██████ " , " ██     " , " ██████ "];
    public static readonly string[] THREE = [" ██████ " , "     ██ " , " ██████ " , "     ██ " , " ██████ "];
    public static readonly string[] FOUR = [" ██  ██ " , " ██  ██ " , " ██████ " , "     ██ " , "     ██ "];
    public static readonly string[] FIVE = [" ██████ " , " ██     " , " ██████ " , "     ██ " , " ██████ "];
    public static readonly string[] SIX = [" ██████ " , " ██     " , " ██████ " , " ██  ██ " , " ██████ "];
    public static readonly string[] SEVEN = [" ██████ " , "     ██ " , "     ██ " , "     ██ " , "     ██ "];
    public static readonly string[] EIGHT = [" ██████ " , " ██  ██ " , " ██████ " , " ██  ██ " , " ██████ "];
    public static readonly string[] NINE = [" ██████ " , " ██  ██ " , " ██████ " , "     ██ " , " ██████ "];
    public static readonly string[] SEPARATOR = ["    ", " ██ ", "    ", " ██ ", "    "];

    public static int COLOR = 0;
    private static Action? ON_UPDATE = null;
    
    public static void printNumber(int number, int color) {
        string[] o = new string[5];
        string s = number.ToString();

        foreach (char c in s) {

            string[] toAdd = new string[5];
            
            switch (c) {
                case '0': 
                    toAdd = ZERO;
                    break;
                case '1': 
                    toAdd = ONE;
                    break;
                case '2': 
                    toAdd = TWO;
                    break;
                case '3':
                    toAdd = THREE;
                    break;
                case '4':
                    toAdd = FOUR;
                    break;
                case '5':
                    toAdd = FIVE;
                    break;
                case '6':
                    toAdd = SIX;
                    break;
                case '7':
                    toAdd = SEVEN;
                    break;
                case '8':
                    toAdd = EIGHT;
                    break;
                case '9':
                    toAdd = NINE;
                    break;
            }

            for (int i = 0; i < 5; i++) {
                o[i] += toAdd[i];
            }
        }

        foreach (var str in o) {
            foreach (var c in str) {
                if (c == '█') {
                    ConsoleColors.printColoredB(" ", color);
                }
                else {
                    Console.Write(" ");
                }
            }
            
            Console.WriteLine();
        }
    }

    public static void clock(int color) {

        COLOR = color;
        ON_UPDATE = null;
        
        var timer = new System.Timers.Timer();
        timer.Interval = 1000; // Interval in milliseconds (1 second)
        timer.Elapsed += printTime;
        timer.Start();

        // Keep the program running
        Console.WriteLine("Press Enter to exit...");
        string s = Console.ReadLine();

        if (s == "") {
            timer.Stop();
            return;
        }
    }
    
    public static void clock(int color, Action onUpdate) {
        
        COLOR = color;
        ON_UPDATE = onUpdate;
        
        var timer = new System.Timers.Timer();
        timer.Interval = 1000; // Interval in milliseconds (1 second)
        timer.Elapsed += printTime;
        timer.Start();

        // Keep the program running
        Console.WriteLine("Press Enter to exit...");
        string s = Console.ReadLine();

        if (s == "") {
            timer.Stop();
            Console.Clear();
        }
    }

    public static void printTime(object sender, ElapsedEventArgs e) {
        
        int hours = DateTime.Now.Hour;
        int minutes = DateTime.Now.Minute;
        int seconds = DateTime.Now.Second;

        if (ON_UPDATE != null) {
            ON_UPDATE();
        }
        
        string[] o = new string[5];
        string top = "";
        string bottom = "";

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < (Console.WindowWidth - 58) / 2; j++) {
                o[i] += " ";
            }
        }
        
        for (int j = 0; j < (Console.WindowWidth - 58) / 2; j++) {
            top += " ";
            bottom += " ";
        }
        
        o[0] += "│";
        o[1] += "│";
        o[2] += "│";
        o[3] += "│";
        o[4] += "│";
        
        // │╭ ╮╯─╮  ╰│╯╰ ╭─
        // ┃┏ ┓┛━┓  ┗┃┛┗ ┏━
        
        if (hours < 10) {
            for (int i = 0; i < 5; i++) {
                o[i] += ZERO[i];
            }
        }
        addNum(hours, ref o);

        for (int i = 0; i < 5; i++) {
            o[i] += SEPARATOR[i];
        }
        
        if (minutes < 10) {
            for (int i = 0; i < 5; i++) {
                o[i] += ZERO[i];
            }
        }
        addNum(minutes, ref o);
        
        for (int i = 0; i < 5; i++) {
            o[i] += SEPARATOR[i];
        }
        
        if (seconds < 10) {
            for (int i = 0; i < 5; i++) {
                o[i] += ZERO[i];
            }
        }
        addNum(seconds, ref o);

        Console.Clear();
        
        for (int i = 1; i <= (Console.WindowHeight - 7) / 2; i++) {
            Console.WriteLine();
        }
        
        top += "┌────────────────────────────────────────────────────────┐";
        ConsoleColors.printlnColored(top, COLOR);

        o[0] += "│";
        o[1] += "│";
        o[2] += "│";
        o[3] += "│";
        o[4] += "│";
        
        foreach (var str in o) {
            foreach (var c in str) {
                if (c == '█') {
                    ConsoleColors.printColoredB(" ", COLOR);
                }
                else if (c != ' ') {
                    ConsoleColors.printColored("" + c, COLOR);
                }
                else {
                    Console.Write(" ");
                }
            }
            
            Console.WriteLine();
        }

        bottom += $"└─────────────────── {DateTime.Now:yyyy-MM-dd}  [{DateTime.Now.ToString("ddd").ToUpper()}] ───────────────────┘\n";
        ConsoleColors.printlnColored(bottom, COLOR);
    }

    private static void addNum(int number, ref string[] o) {
        
        string s = number.ToString();

        foreach (char c in s) {

            string[] toAdd = new string[5];
            
            switch (c) {
                case '0': 
                    toAdd = ZERO;
                    break;
                case '1': 
                    toAdd = ONE;
                    break;
                case '2': 
                    toAdd = TWO;
                    break;
                case '3':
                    toAdd = THREE;
                    break;
                case '4':
                    toAdd = FOUR;
                    break;
                case '5':
                    toAdd = FIVE;
                    break;
                case '6':
                    toAdd = SIX;
                    break;
                case '7':
                    toAdd = SEVEN;
                    break;
                case '8':
                    toAdd = EIGHT;
                    break;
                case '9':
                    toAdd = NINE;
                    break;
            }

            for (int i = 0; i < 5; i++) {
                o[i] += toAdd[i];
            }
        }
    } 
} 