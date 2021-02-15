# ImageFromXamarinUI [![NuGet](https://img.shields.io/nuget/v/ImageFromXamarinUI?style=plastic)](https://www.nuget.org/packages/ImageFromXamarinUI/)
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
