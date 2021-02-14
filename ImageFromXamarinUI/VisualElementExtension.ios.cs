using System;
using System.IO;
using System.Threading.Tasks;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ImageFromXamarinUI
{
    public static partial class VisualElementExtension
    {
        static Task<Stream> PlatformCaptureImageAsync(VisualElement view, Color backgroundColor)
        {
            Stream stream = null;
            using (var image = ViewToUIImage(GetNativeView(view), backgroundColor))
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

        static UIImage ViewToUIImage(UIView view, Color backgroundColor)
        {
            var size = view.Frame.Size;
            UIGraphics.BeginImageContextWithOptions(size, false, UIScreen.MainScreen.Scale);
            using var context = UIGraphics.GetCurrentContext();

            if(backgroundColor != Color.Transparent)
            {
                context.SetFillColor(backgroundColor.ToCGColor());
                context.FillRect(new CGRect(0, 0, size.Width, size.Height));
            }
            
            view.Layer.RenderInContext(context);
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
