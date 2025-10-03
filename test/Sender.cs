using eyecandy;
using NewTek;
using OpenTK.Windowing.Common;

namespace test;

public class Sender : OpenTKWindow, IDisposable
{
    private string name;
    private string groups;

    public Sender(EyeCandyWindowConfig windowConfig, string deviceName, string groupList)
        : base(windowConfig, "passthrough.vert", "sender.frag")
    {
        name = deviceName;
        groups = groupList;
    }

    protected override void OnLoad()
    {
        base.OnLoad();

        NDISenderManager.InitializeSender(name, groups);
        NDISenderManager.PrepareVideoFrame(ClientSize.X, ClientSize.Y);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        OpenGLUtils.ReadFramebufferPixels(ClientSize.X, ClientSize.Y);
        NDISenderManager.SendVideoFrame(ref OpenGLUtils.VideoFrame);
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        NDISenderManager.PrepareVideoFrame(ClientSize.X, ClientSize.Y);
    }

    public new void Dispose()
    {
        base.Dispose();
        NDISenderManager.Dispose();
    }
}
