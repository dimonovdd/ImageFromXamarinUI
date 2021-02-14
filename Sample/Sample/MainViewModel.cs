using System.IO;
using System.Windows.Input;
using ImageFromXamarinUI;
using Xamarin.Essentials;
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
            var stream = await element.CaptureImageAsync(Color.Red.MultiplyAlpha(0.4));
            ResultImageSource = ImageSource.FromStream(() => stream);


            //var dir = FileSystem.CacheDirectory;
            //var filepath = Path.Combine(dir, "image.jpg");

            //if (File.Exists(filepath))
            //    File.Delete(filepath);

            //var fileStream = File.OpenWrite(filepath);
            //stream.CopyTo(fileStream);
            //fileStream.Close();

            //await Share.RequestAsync(new ShareFileRequest(new ShareFile(filepath)));
        }
    }
}
