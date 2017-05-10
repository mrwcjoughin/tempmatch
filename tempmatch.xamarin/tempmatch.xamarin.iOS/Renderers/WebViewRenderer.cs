using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;

using common.xamarin.Core.Views;
using tempmatch.xamarin.core.iOS;

[assembly: ExportRenderer (typeof (common.xamarin.Core.Views.WebView), typeof (tempmatch.xamarin.core.iOS.WebViewRenderer))]
namespace tempmatch.xamarin.core.iOS
{
	public class WebViewRenderer : Xamarin.Forms.Platform.iOS.WebViewRenderer
	{
		public WebViewRenderer ()
		{
		}

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			Frame = new System.Drawing.RectangleF(0, 0, (float)UIScreen.MainScreen.Bounds.Width,(float)UIScreen.MainScreen.Bounds.Height);
			ContentMode = UIViewContentMode.ScaleAspectFill;
			ScalesPageToFit = true;
			AutoresizingMask = UIViewAutoresizing.All;
		}
	}
}