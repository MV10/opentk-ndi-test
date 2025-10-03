using eyecandy;

namespace test;

internal class Program
{
    internal static BaseWindow Window;

    static void Main(string[] args)
    {
        Console.WriteLine("\nOpenTK NDI Test\n\n");

        if(args.Length < 1 || args.Length > 2)
        {
            Help();
            return;
        }

        var spoutName = args.Length > 1 ? args[1] : "test";
        var groupName = args.Length == 3 ? args[2] : string.Empty;

        var windowConfig = new EyeCandyWindowConfig();
        windowConfig.OpenTKNativeWindowSettings.Title = "opentk-ndi-test";
        windowConfig.OpenTKNativeWindowSettings.ClientSize = (960, 540);
        windowConfig.StartFullScreen = false;
        windowConfig.OpenTKNativeWindowSettings.APIVersion = new Version(4, 5);

        args[0] = args[0].Trim().ToLowerInvariant();
        if (args[0] == "sender") Window = new Sender(windowConfig, spoutName, groupName);
        if (args[0] == "receiver") Window = new Receiver(windowConfig, spoutName, groupName);

        if(Window is null)
        {
            Help();
            return;
        }

        Window.Focus();
        Window.Run();
        Window.Dispose();
    }

    static void Help()
    {
        Console.WriteLine("Usage: opentk-ndi-test [sender|receiver] \"[name]\" \"[groups]\"");
        Console.WriteLine("  sender   - transmit shader output frames");
        Console.WriteLine("  receiver - apply shader to input frames");
        Console.WriteLine("  name     - optional device name (use quotes if name has spaces)");
        Console.WriteLine("  groups   - optional groups, comma delimited (quoted for spaces)");
    }
}
