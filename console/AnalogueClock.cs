//
// Kolors - Colored Console Utils
// by KryKom 2024
//

using System.Timers;

namespace Kolors.console;

public static class AnalogueClock {
    private const string CIRCLE = "          ██████████          \n" +
                                  "      ████          ████      \n" +
                                  "    ██                  ██    \n" +
                                  "  ██                      ██  \n" +
                                  "  ██                      ██  \n" +
                                  "██                          ██\n" +
                                  "██                          ██\n" +
                                  "██                          ██\n" +
                                  "██                          ██\n" +
                                  "██                          ██\n" +
                                  "  ██                      ██  \n" +
                                  "  ██                      ██  \n" +
                                  "    ██                  ██    \n" +
                                  "      ████          ████      \n" +
                                  "          ██████████          \n";

    private static readonly int[,] FIELD = {{0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},  // [y, x]
                                            {0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                                            {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                                            {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                            {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                                            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                                            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                                            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                                            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                                            {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                            {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                            {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                                            {0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                                            {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0}
    };

    private static int[,] WORKING = FIELD;
    private const int RADIUS = 6;
    private const int SIZE = 15;
    private const int HOUR_LENGTH = 3;
    private const int MINUTE_LENGTH = 4;
    private const int SECOND_LENGTH = 6;
    public static ColorPalette COLORS = ColorPalette.LAVENDER;

    public const int TESTH = 3;
    public const int TESTM = 37;
    
    private static void SetHours() {
        double angle = 30f * DateTime.Now.Hour - 90;
        
        for (int i = 1; i <= HOUR_LENGTH; i++) {
            int x = (int)Math.Round(Math.Cos(angle * Math.PI / 180) * (i)) + RADIUS + 1;
            int y = (int)Math.Round(Math.Sin(angle * Math.PI / 180) * (i)) + RADIUS + 1;
                        
            WORKING[y, x] = 2;
        }
    }
    
    private static void SetMinutes() {
        double angle = 6f * DateTime.Now.Minute - 90;
        
        for (int i = 1; i <= MINUTE_LENGTH; i++) {
            int x = (int)(Math.Cos(angle * Math.PI / 180) * i) + RADIUS + 1;
            int y = (int)(Math.Sin(angle * Math.PI / 180) * i) + RADIUS + 1;
            
            WORKING[y, x] = 3;
        }
        
        // int x = (int)Math.Round((Math.Cos(angle * Math.PI / 180) * (RADIUS + 0))) + RADIUS + 1;
        // int y = (int)Math.Round((Math.Sin(angle * Math.PI / 180) * (RADIUS + 0))) + RADIUS + 1;
        //     
        // WORKING[y, x] = 3;
    }
    
    private static void SetSeconds() {
        double angle = 6f * DateTime.Now.Second - 90;
        
        for (int i = 1; i <= SECOND_LENGTH; i++) {
            int x = (int)(Math.Cos(angle * Math.PI / 180) * i) + RADIUS + 1;
            int y = (int)(Math.Sin(angle * Math.PI / 180) * i) + RADIUS + 1;
            
            WORKING[y, x] = 4;
        }
        
        // int x = (int)Math.Round((Math.Cos(angle * Math.PI / 180) * (RADIUS + 1))) + RADIUS + 1;
        // int y = (int)Math.Round((Math.Sin(angle * Math.PI / 180) * (RADIUS + 1))) + RADIUS + 1;
        //     
        // WORKING[y, x] = 4;
    }

    /// <summary>
    /// starts an analogue clock in the console
    /// </summary>
    public static void Start(ColorPalette colors) {
        COLORS = colors;
        
        var timer = new System.Timers.Timer();
        timer.Interval = 1000; // Interval in milliseconds (1 second)
        timer.Elapsed += UpdateClock!;
        timer.Start();

        // Keep the program running
        Console.WriteLine("Press Enter to exit...");
        string? s = Console.ReadLine();

        if (s == "") {
            timer.Stop();
            Console.Clear();
        }
    }

    private static void UpdateClock(object sender, ElapsedEventArgs e) {

        WORKING = new int[SIZE, SIZE];
        
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                WORKING[i, j] = FIELD[i, j];
            }
        }

        SetSeconds();
        SetMinutes();
        SetHours();
        WORKING[7, 7] = 1;
        Console.Clear();

        for (int i = 1; i <= (Console.WindowHeight - SIZE) / 2; i++) {
            Console.WriteLine();
        }
        
        for (int i = 0; i < SIZE; i++) {

            string padding = "";
            
            for (int j = 0; j < (Console.WindowWidth - SIZE * 2) / 2; j++) {
                padding += " ";
            }

            Console.Write(padding);
            
            for (int j = 0; j < SIZE; j++) {
                if (WORKING[i, j] == 1) {
                    ConsoleColors.PrintColoredB("  ", COLORS.Colors[4]);
                } 
                else if (WORKING[i, j] == 2) {
                    ConsoleColors.PrintColoredB("  ", COLORS.Colors[3]);
                }
                    
                else if (WORKING[i, j] == 3) {
                    ConsoleColors.PrintColoredB("  ", COLORS.Colors[2]);
                } 
                else if (WORKING[i, j] == 4) {
                    ConsoleColors.PrintColoredB("  ", COLORS.Colors[1]);

                }
                else {
                    Console.Write("  ");
                }
            }
            
            Console.WriteLine();
        }
    }
}