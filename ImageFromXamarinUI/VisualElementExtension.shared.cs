using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageFromXamarinUI
{
    /// <summary>The extension class with methods for creating images</summary>
    public static partial class VisualElementExtension
    {
        /// <summary>Captures an image from the current state of <paramref name="element"/></summary>
        /// <param name="element">element to which the render was assigned</param>
        /// <param name="backgroundColor"></param>
        /// <returns>Stream an image as png with transparency</returns>
        public static async Task<Stream> CaptureImageAsync(this VisualElement element, Color? backgroundColor = null)
            => await PlatformCaptureImageAsync(element, backgroundColor ?? Color.Transparent);
    }
}