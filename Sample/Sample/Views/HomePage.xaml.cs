using System;
using Sample.Models;
using Xamarin.Forms;

namespace Sample.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            samplesView.ItemsSource = new SampleItem[]
            {
                new SampleItem(
                    "OpenGLView",
                    typeof(OpenGLViewPage)),
                new SampleItem(
                    "ScrollView",
                    typeof(ScrollViewPage)),
                new SampleItem(
                    "Command",
                    typeof(CommandPage)),
                new SampleItem(
                    "BackgroundColor",
                    typeof(BackgroundColorPage))
            };
        }

        async void OnSampleTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as SampleItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.PageType);
            page.Title = item.Name;

            await Navigation.PushAsync(page);

            // deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
