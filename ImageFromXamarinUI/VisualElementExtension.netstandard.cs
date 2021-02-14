using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageFromXamarinUI
{
    public static partial class VisualElementExtension
    {
        static Task<Stream> PlatformCaptureImageAsync(VisualElement view, Color backgroundColor)
               => throw new NotImplementedException($"{nameof(CaptureImageAsync)} not supported on netstandart project");

    }
}
