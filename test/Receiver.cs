using eyecandy;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;

namespace test;

public class Receiver : OpenTKWindow, IDisposable
{
    private string name;
    private string groups;
    private int textureID = -1;

    public Receiver(EyeCandyWindowConfig windowConfig, string deviceName, string groupName)
        : base(windowConfig, "passthrough.vert", "receiver.frag")
    {
        name = deviceName;
        groups = groupName;
        OpenGLUtils.SetTextureUniformCallback = SetTextureUniformCallback;
    }

    protected override void OnLoad()
    {
        base.OnLoad();

    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {

        base.OnRenderFrame(e);
    }

    // called from OpenGLUtils.SetUniforms
    internal void SetTextureUniformCallback()
    {
        if (textureID == -1) return;
        Shader.SetTexture("receivedTexture", textureID, TextureUnit.Texture0);
    }

    public new void Dispose()
    {
        base.Dispose();
    }
}
