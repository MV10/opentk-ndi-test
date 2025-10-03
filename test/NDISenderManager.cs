
using NewTek;
using System.Runtime.InteropServices;

namespace test;

internal static class NDISenderManager
{
    internal static nint Sender = nint.Zero;
    internal static NDIlib.video_frame_v2_t VideoFrameData;

    internal static void InitializeSender(string name, string groups)
    {
        nint ptrName = nint.Zero;
        nint ptrGroups = nint.Zero;

        try
        {
            ptrName = Marshal.StringToHGlobalAnsi(name);
            ptrGroups = Marshal.StringToHGlobalAnsi(groups);
            var config = new NDIlib.send_create_t
            {
                p_ndi_name = ptrName,
                p_groups = ptrGroups,
                clock_audio = false,
                clock_video = true,
            };
            Sender = NDIlib.send_create(ref config);
        }
        finally
        {
            if (ptrName != nint.Zero) Marshal.FreeHGlobal(ptrName);
            if (ptrGroups != nint.Zero) Marshal.FreeHGlobal(ptrGroups);
        }
    }

    internal static void PrepareVideoFrame(int width, int height)
    {
        if (Sender == nint.Zero) return;
        VideoFrameData = new()
        {
            xres = width,
            yres = height,
            FourCC = NDIlib.FourCC_type_e.FourCC_type_RGBA,
            frame_rate_N = 30000,
            frame_rate_D = 1001,
            picture_aspect_ratio = (float)width / height,
            frame_format_type = NDIlib.frame_format_type_e.frame_format_type_progressive,
            timecode = NDIlib.send_timecode_synthesize,
            p_data = nint.Zero,
            line_stride_in_bytes = width * 4,
        };
    }

    internal unsafe static void SendVideoFrame(ref byte[] frameData)
    {
        if(Sender == nint.Zero) return;

        fixed(byte * ptrFrameData = frameData)
        {
            VideoFrameData.p_data = (nint)ptrFrameData;
            NDIlib.send_send_video_v2(Sender, ref VideoFrameData);
        }
    }

    internal static void Dispose()
    {
        if (Sender != nint.Zero)
        {
            NDIlib.send_destroy(Sender);
            Sender = nint.Zero;
        }
    }
}
