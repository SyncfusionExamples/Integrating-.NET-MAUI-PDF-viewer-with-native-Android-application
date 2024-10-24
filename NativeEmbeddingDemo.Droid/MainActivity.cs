using Android.Views;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Buttons;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.PdfViewer;
using System.Reflection;
using static Android.Views.ViewGroup.LayoutParams;

namespace NativeEmbeddingPDFViewerDemoAndroid.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/AppTheme")]
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

            // Initialize the SfPdfViewer
            _pdfViewer = new SfPdfViewer();

            // Set the document source for SfPdfViewer control
            var assembly = Assembly.GetExecutingAssembly();
            _pdfViewer.DocumentSource = this.GetType().Assembly.GetManifestResourceStream("NativeEmbeddingPDFViewerDemoAndroid.Droid.Assets.PDF_Succinctly.pdf");

            // Convert SfPdfViewer to an Android view
            Android.Views.View pdfViewerView = _pdfViewer.ToPlatform(_mauiContext);

            // Directly set the pdfViewerView as the content view
            SetContentView(pdfViewerView);
        }
    }
}