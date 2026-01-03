namespace Calculator;

public class SteamManager
{
    static string personaName = "";

    public static void Init()
    {
#if Steam
        try
        {
            if (SteamAPI.Init())
            {
                personaName = SteamFriends.GetPersonaName();
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("SteamAPI Init Exception: " + exception.Message);
        }
        finally
        {
            SteamAPI.Shutdown();
        }
#endif
    }

    public static void Shutdown()
    {
#if Steam
        SteamAPI.Shutdown();
#endif
    }

    public static string PersonaName()
    {
        return personaName;
    }
}