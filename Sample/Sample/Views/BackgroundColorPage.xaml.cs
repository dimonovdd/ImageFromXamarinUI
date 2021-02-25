using System;
using ImageFromXamarinUI;
using Sample.Helpers;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class BackgroundColorPage : ContentPage
    {
        Random rnd = new Random();

        public BackgroundColorPage()
        {
            InitializeComponent();
            label.Text =
                "Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  " +
                "Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  " +
                "Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  Sample Text  ";
        }

        async void OnCapture(object sender, EventArgs e)
        {
            var color = Color.FromRgba(RndNext(), RndNext(), RndNext(), RndNext());
            using var stream = await label.CaptureImageAsync(color);
            var filepath = await FileHelper.SaveAsync(stream);
            resultImage.Source = ImageSource.FromFile(filepath);
        }

        int RndNext()
            => rnd.Next(255);
    }
}
