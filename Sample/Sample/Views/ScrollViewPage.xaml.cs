using System;
using ImageFromXamarinUI;
using Sample.Helpers;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class ScrollViewPage : ContentPage
    {
        public ScrollViewPage()
            => InitializeComponent();

        private void CaptureScrollView(object sender, EventArgs e)
            => OnCapture(scrollView);

        private void CaptureScrollViewContent(object sender, EventArgs e)
            => OnCapture(scrollViewContent);

        async void OnCapture(VisualElement element)
        {
            using var stream = await element.CaptureImageAsync();
            var filepath = await FileHelper.SaveAsync(stream);
            resultImage.Source = ImageSource.FromFile(filepath);
        }
    }
}
