using System;
using ImageFromXamarinUI.OpenGLView;
using Sample.Helpers;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class OpenGLViewPage : ContentPage
    {
        IOpenGLViewSharedCode sharedCode = DependencyService.Get<IOpenGLViewSharedCode>();

        public OpenGLViewPage()
        {
            InitializeComponent();

            openGLView.IsVisible = sharedCode != null;

            if (sharedCode != null)
            {
                openGLView.OnDisplay = sharedCode.RenderLoop;
                openGLView.Display();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (sharedCode != null)
                openGLView.HasRenderLoop = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (sharedCode != null)
                openGLView.HasRenderLoop = false;
        }

        private async void OnCapture(object sender, EventArgs e)
        {
            using var stream = await openGLView.CaptureImageAsync();
            var filepath = await FileHelper.SaveAsync(stream);
            resultImage.Source = ImageSource.FromFile(filepath);
        }

    }
}
