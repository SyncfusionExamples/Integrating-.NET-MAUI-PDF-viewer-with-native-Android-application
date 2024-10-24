# Integrating .NET MAUI PDFViewer with native Android application
In this article, learn to use the .NET MAUI PDF viewer control in a native Android application and view a PDF document.

**Step 1:**

Before creating a Android project, create a .NET MAUI class library project and delete the Platforms folder and the Class1.cs file from it. Then add the classes named **EmbeddedExtensions, EmbeddedPlatformApplication, EmbeddedWindowHandler, and EmbeddedWindowProvider** to the created .NET MAUI class library project. The required code for these classes are available [here](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/native-embedding?view=net-maui-8.0&pivots=devices-android)

**Step 2:**

Next in the same solution, create a .NET MAUI single project. This project is used to register the handlers required to render the PDF viewer control. After including the project in the solution, follow the steps mentioned [here](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/native-embedding?view=net-maui-8.0&pivots=devices-windows#create-a-net-maui-single-project)

**Step 3:**

Install the [Syncfusion.Maui.PdfViewer](https://www.nuget.org/packages/Syncfusion.Maui.PdfViewer)  nuget package from [nuget.org](https://www.nuget.org/) into the created .NET MAUI single project.

**Step 4:**

Register the Syncfusion core handler in the **MauiProgram.cs** file of the .NET MAUI single project by calling the **ConfigureSyncfusionCore** method.
 
 ```csharp
public static MauiApp CreateMauiApp<TApp>(Action<MauiAppBuilder>? additional = null) where TApp : App
 {
     var builder = MauiApp.CreateBuilder();
     builder
         .UseMauiApp<TApp>()
         .ConfigureSyncfusionCore()
         .ConfigureFonts(fonts =>
         {
             fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
             fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
         }); 
 ```

**Step 5:**

Create the native Android application project in which you want to add the PDF viewer and install the  [Syncfusion.Maui.PdfViewer](https://www.nuget.org/packages/Syncfusion.Maui.PdfViewer) nuget package from [nuget.org](https://www.nuget.org/).

**Step 6:**

In the project file of the native Android application, add `<UseMaui>`true  `<UseMaui>` to enable the .Net Maui support demonstrated as follows.
 
 ```xml
<PropertyGroup>
  <TargetFramework>net8.0-android</TargetFramework>
  <OutputType>Exe</OutputType>
  <Nullable>enable</Nullable>
  <UseMaui>true</UseMaui>
  <ImplicitUsings>enable</ImplicitUsings>
  <SupportedOSPlatformVersion>13.0</SupportedOSPlatformVersion>
</PropertyGroup> 
 ```

**Step 7:**

Initialize .NET MAUI in the native Android project by creating a MauiApp object and using the UseMauiEmbedding method in the MainActivity.cs file as follows.
 
 ```csharp
public class MainActivity : Activity
{
    public static readonly Lazy<MauiApp> MauiApp = new(() =>
    {
        return MauiProgram.CreateMauiApp(builder =>
        {
            builder.UseMauiEmbedding(); 
        });
    });

    public static bool UseWindowContext = true;
    private SfPdfViewer _pdfViewer;
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Initialize the Maui app
        var mauiApp = MauiApp.Value;
        var _mauiContext = UseWindowContext
             ? mauiApp.CreateEmbeddedWindowContext(this) // Create window context
             : new MauiContext(mauiApp.Services);        // Create app context
         ……
         ……
       } 
 ```

**Step 8:**

Create a new folder with the name “Assets” in the Android app project and include the PDF document to be loaded, inside the folder. Set the Build Action of the PDF file to **Embedded Resource.** In this example, a PDF named “PDF_Succinctly.pdf” is used.

**Step 9:**

Create the .NET MAUI PDF viewer control, convert it to a native view and add it as the Content of the OnCreate().
 
 ```csharp
protected override void OnCreate(Bundle? savedInstanceState)
    {
            …..
            …..
            // Initialize and configure the SfPdfViewer
            _pdfViewer = new SfPdfViewer();

            // Set the document source for SfPdfViewer control
            var assembly = Assembly.GetExecutingAssembly();
            _pdfViewer.DocumentSource = this.GetType().Assembly.GetManifestResourceStream("NativeEmbeddingPDFViewerDemoAndroid.Droid.Assets.PDF_Succinctly.pdf");

            // Convert SfPdfViewer to an Android view
            Android.Views.View pdfViewerView = _pdfViewer.ToPlatform(_mauiContext);

            // Directly set the pdfViewerView as the content view
            SetContentView(pdfViewerView);

     } 
 ```

**Step 10:**

In the solution, set the native Android project as the start-up project. Build, deploy and run the project.

[View the sample on GitHub](https://github.com/SyncfusionExamples/Integrating-.NET-MAUI-PDF-viewer-with-native-Android-application)

**Conclusion**

We hope you enjoyed learning how to integrate .NET MAUI PDF Viewer in a native Android application.

Refer to our [.NET MAUI PDF Viewer’s feature tour page](https://www.syncfusion.com/maui-controls/maui-pdf-viewer) to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI PDF Viewer Documentation](https://help.syncfusion.com/maui/pdf-viewer/getting-started) to understand how to present and manipulate data.

For current customers, check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI PDF Viewer and other .NET MAUI components.


Please let us know in the following comments if you have any queries or require clarifications. You can also contact us through our [support forums](https://www.syncfusion.com/downloads/maui), [support ticket](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui). We are always happy to assist you!