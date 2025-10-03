using eyecandy;
using OpenTK.Windowing.Common;

namespace test;

public class Sender : OpenTKWindow, IDisposable
{
    private string name;

    public Sender(EyeCandyWindowConfig windowConfig, string deviceName)
        : base(windowConfig, "passthrough.vert", "sender.frag")
    {
        name = deviceName;
    }

    protected override void OnLoad()
    {
        base.OnLoad();
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
    }

    public new void Dispose()
    {
        base.Dispose();
    }
}
