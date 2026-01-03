global using Steamworks;
global using System.Data;

namespace Calculator;

internal static class Program
{
    static void Main()
    {
        try
        {
            SteamManager.Init();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
        catch (Exception exception)
        {
            Console.WriteLine($"An error occurred: {exception.Message}");
        }
        finally
        {
            SteamManager.Shutdown();
        }
    }
}