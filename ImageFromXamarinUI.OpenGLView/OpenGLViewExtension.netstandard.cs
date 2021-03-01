using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageFromXamarinUI.OpenGLView
{
    public static partial class OpenGLViewExtension
    {
        static Task<Stream> PlatformCaptureImageAsync(VisualElement view, Color backgroundColor)
               => throw new NotImplementedException($"{nameof(CaptureImageAsync)} not supported on netstandart project");

    }
}
