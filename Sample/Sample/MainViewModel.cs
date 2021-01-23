using System.Windows.Input;
using ImageFromXamarinUI;
using Xamarin.Forms;

namespace Sample
{
    public class MainViewModel : BaseNotifier
    {
        private ImageSource resultImageSource;

        public MainViewModel()
        {
            CaptureCommand = new Command<VisualElement>(OnCapture);
        }

        public ICommand CaptureCommand { get; set; }

        public ImageSource ResultImageSource
        {
            get => resultImageSource;
            set
            {
                resultImageSource = value;
                OnPropertyChanged();
            }
        }

        async void OnCapture(VisualElement element)
        {
            var stream = await element.CaptureImageAsync();
            ResultImageSource = ImageSource.FromStream(() => stream);
        }
    }
}
