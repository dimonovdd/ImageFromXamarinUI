using System;
using System.IO;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Opengl;
using Java.Nio;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ImageFromXamarinUI.OpenGLView
{
    public static partial class OpenGLViewExtension
    {
        static async Task<Stream> PlatformCaptureImageAsync(Xamarin.Forms.OpenGLView view, Xamarin.Forms.Color backgroundColor)
        {
            using var bitmap = ViewToBitMap(GetNativeView(view), backgroundColor);
            var stream = await BitMapToStream(bitmap);
            bitmap.Recycle();
            return stream;
        }

        static GLSurfaceView GetNativeView(Xamarin.Forms.OpenGLView view)
        {
            var render = Platform.GetRenderer(view) as ViewRenderer<Xamarin.Forms.OpenGLView, GLSurfaceView>;

            if (render == null)
                throw new ArgumentException($"The {view} parameter does not have a render", nameof(view));

            return render.Control;
        }

        static Bitmap ViewToBitMap(GLSurfaceView view, Xamarin.Forms.Color backgroundColor)
        {
            var bitmap = Bitmap.CreateBitmap(view.Width, view.Height, Bitmap.Config.Argb8888);
            using var canvas = new Canvas(bitmap);
            canvas.DrawColor(backgroundColor.ToAndroid());
            view.Draw(canvas);


            return CreateBitmapFromGLSurface(200, 200, null);
        }

        static async Task<Stream> BitMapToStream(Bitmap bitmap)
        {
            var ms = new MemoryStream();
            await bitmap.CompressAsync(Bitmap.CompressFormat.Png, 100, ms).ConfigureAwait(false);
            ms.Position = 0;
            return ms;
        }



        private static Bitmap CreateBitmapFromGLSurface(int w, int h, GLES20 gl)
        {
            IntBuffer ib = IntBuffer.Allocate(w * h);
            GLES10.GlReadPixels(0, 0, w, h, GLES10.GlRgba, GLES10.GlUnsignedByte, ib);

            Bitmap _screenShotBitmap = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
            _screenShotBitmap.CopyPixelsFromBuffer(ib);

            return _screenShotBitmap;
        }
    }
}
