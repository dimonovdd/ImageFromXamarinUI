using System.Windows.Input;
using ImageFromXamarinUI;
using Sample.Helpers;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    public class CommandVM : BaseNotifier
    {
        public CommandVM()
           => CaptureCommand = new Command<VisualElement>(OnCapture);

        public ICommand CaptureCommand { get; set; }

        public ImageSource CapturedImage { get; set; }

        async void OnCapture(VisualElement element)
        {
            using var stream = await element.CaptureImageAsync();
            var filepath = await FileHelper.SaveAsync(stream);
            CapturedImage = ImageSource.FromFile(filepath);
        }
    }
}
