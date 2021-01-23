using System;
using System.IO;
using System.Threading.Tasks;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ImageFromXamarinUI
{
    public static partial class VisualElementExtension
    {
        static async Task<Stream> PlatformCaptureImageAsync(VisualElement view)
        {
            using var bitmap = ViewToBitMap(GetNativeView(view));
            var stream = await BitMapToStream(bitmap);
            bitmap.Recycle();
            return stream;
        }

        static Android.Views.View GetNativeView(VisualElement view)
        {
            var render = Platform.GetRenderer(view);

            if (render == null)
                throw new ArgumentException($"The {view} parameter does not have a render", nameof(view));

            return render.View;
        }

        static Bitmap ViewToBitMap(Android.Views.View view)
        {
            var bitmap = Bitmap.CreateBitmap(view.Width, view.Height, Bitmap.Config.Argb8888);
            using var canvas = new Canvas(bitmap);
            canvas.DrawColor(Android.Graphics.Color.Transparent);
            view.Draw(canvas);

            return bitmap;
        }

        static async Task<Stream> BitMapToStream(Bitmap bitmap)
        {
            var ms = new MemoryStream();
            await bitmap.CompressAsync(Bitmap.CompressFormat.Png, 100, ms).ConfigureAwait(false);
            ms.Position = 0;
            return ms;
        }
    }
}
