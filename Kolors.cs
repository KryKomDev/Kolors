using Kolors.console;

namespace Kolors;

public class Kolors {
    public static event EventHandler EventRecieved;
    
    public static void Main() {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine();
        Console.WriteLine();
        
        ConsoleProgressBar bar = new ConsoleProgressBar(0, 100, 40, ConsoleProgressBar.BarStyle.MODERN);
        EventRecieved += bar.OnProgressUpdate;

        Random rnd = new Random();
        
        for (int i = 0; i < 100; i++) {
            Thread.Sleep(rnd.Next(0, 50));
            EventRecieved.Invoke(null, EventArgs.Empty);
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}