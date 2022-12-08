// See https://aka.ms/new-console-template for more information
using AoC;

internal class Program
{
    [STAThread]
    private static async Task Main(string[] args)
    {
        var day = new AoC.Y22.Day8();
        var solution = await day.Part1();
        //var altSolution = await day.AltPart1();
        SetText(solution);

        Console.WriteLine($"Answer is: {solution}");
        //Console.WriteLine($"Alt Answer is: {altSolution}");
        Console.WriteLine("Press Enter to close...");
        _ = Console.ReadLine();
    }

    public static void SetText(string txt)
    {
        Thread STAThread = new Thread(
            delegate ()
            {
                System.Windows.Forms.Clipboard.SetText(txt);
            });
        STAThread.SetApartmentState(ApartmentState.STA);
        STAThread.Start();
        STAThread.Join();
    }
}