# ImageFromXamarinUI [![NuGet Badge](https://img.shields.io/nuget/vpre/ImageFromXamarinUI)](https://www.nuget.org/packages/ImageFromXamarinUI/) [![NuGet downloads](https://img.shields.io/nuget/dt/ImageFromXamarinUI)](https://www.nuget.org/packages/ImageFromXamarinUI/) [![license](https://img.shields.io/github/license/dimonovdd/ImageFromXamarinUI)](https://github.com/dimonovdd/ImageFromXamarinUI/blob/main/LICENSE) [![ImageFromXamarinUI on fuget.org](https://www.fuget.org/packages/ImageFromXamarinUI/badge.svg)](https://www.fuget.org/packages/ImageFromXamarinUI) [![YouTube Video Views](https://img.shields.io/youtube/views/O9D3NSYh1t0?style=social)](https://youtu.be/O9D3NSYh1t0)
### Extension methods for capturing images from UI

![header](/header.svg)

## Available Platforms:

| Platform | Version |
| --- | --- |
| Android | MonoAndroid90+|
| iOS | Xamarin.iOS10 |
| .NET Standard | 2.0 |

## Getting started

You can just watch the [Video](https://youtu.be/O9D3NSYh1t0) that [@jfversluis](https://github.com/jfversluis) published


This is how you can create a simple command to call `CaptureImageAsync` method

```csharp
public ImageSource ResultImageSource { get; set; }

public ICommand CaptureCommand  => new Command<Xamarin.Forms.VisualElement>(OnCapture);

async void OnCapture(Xamarin.Forms.VisualElement element)
{
    try
    {
        var stream = await element.CaptureImageAsync(Color.White);
        ResultImageSource = ImageSource.FromStream(() => stream);
    }
    catch (Exception)
    {
        // Handle exception
    }        
}
 ```
 
 You can pass in the calling element when the `Command` is triggered:
 
 ```xml
<StackLayout x:Name="rootView">
    <Button Text="Capture"
            Command="{Binding CaptureCommand}"
            CommandParameter="{x:Reference rootView}"/>
</StackLayout>
 ```
