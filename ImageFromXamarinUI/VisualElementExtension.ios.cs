using System;
using System.IO;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ImageFromXamarinUI
{
    public static partial class VisualElementExtension
    {
        static Task<Stream> PlatformCaptureImageAsync(VisualElement view)
        {
            Stream stream = null;
            using (var image = ViewToUIImage(GetNativeView(view)))
                stream = ImageToStream(image);
            return Task.FromResult(stream);
        }

        static UIView GetNativeView(VisualElement view)
        {
            var render = Platform.GetRenderer(view);

            if (render == null)
                throw new ArgumentException($"The {view} parameter does not have a render", nameof(view));

            return render.NativeView;
        }

        static UIImage ViewToUIImage(UIView view)
        {
            UIGraphics.BeginImageContextWithOptions(view.Frame.Size, false, UIScreen.MainScreen.Scale);
            view.Layer.RenderInContext(UIGraphics.GetCurrentContext());
            var image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return image;
        }

        static Stream ImageToStream(UIImage image)
        {
            var imageData = image.AsPNG();
            return imageData.AsStream();
        }
    }
}
