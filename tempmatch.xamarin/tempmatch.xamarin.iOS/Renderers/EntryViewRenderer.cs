using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using tempmatch.xamarin.core;
using common.xamarin.Core.Views;

using tempmatch.xamarin.core.iOS;

using UIKit;

[assembly: ExportRenderer (typeof (EntryView), typeof (EntryRenderer))]
namespace tempmatch.xamarin.core.iOS
{
	public class EntryViewRenderer : EntryRenderer
	{
		#region Constructors

		public EntryViewRenderer ()
		{
		}

		#endregion Constructors

		#region Properties

		#endregion Properties

		#region Methods

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			try
			{
				base.OnElementChanged(e);
				var view = (EntryView)Element;
				SetFont(view);
				SetFontSize(view);
                Control.BorderStyle = UITextBorderStyle.None;
			}
			catch(Exception)
			{
				//Do Nothing for now
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			try
			{
				base.OnElementPropertyChanged(sender, e);

				var view = (EntryView)Element;

				if (string.IsNullOrEmpty (e.PropertyName) || e.PropertyName == "Font")
				{
					SetFont (view);
				}

				if (string.IsNullOrEmpty (e.PropertyName) || e.PropertyName == "FontSize")
				{
					SetFontSize (view);
				}
			}
			catch(Exception)
			{
				//Do Nothing for now
			}
		}

		private void SetFont(EntryView view)
		{
			UIFont uiFont;
			if (view.Font != Font.Default && (uiFont = view.Font.ToUIFont()) != null)
			{
				Control.Font = uiFont;
			}
			else if (view.Font == Font.Default)
			{
				Control.Font = UIFont.SystemFontOfSize(17f);
			}
		}

		private void SetFontSize(EntryView view)
		{
//			if (view.FontSize != null)
//			{
			Font font;
			if (view.Font.FontFamily == string.Empty)
			{
				font = Font.Default;
			}
			else
			{
				font = view.Font;
			}

			Control.Font = UIFont.FromName(font.FontFamily, (float)view.FontSize);// view.FontSize;
//			}
		}

		#endregion Methods
	}
}