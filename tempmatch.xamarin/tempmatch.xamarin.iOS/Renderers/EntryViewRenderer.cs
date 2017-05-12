using System;
using System.ComponentModel;

using Cirrious.FluentLayouts.Touch;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using tempmatch.xamarin.core;
using common.xamarin.Core.Views;

using tempmatch.xamarin.core.iOS;

using UIKit;
using CoreGraphics;
using Foundation;
using CoreAnimation;
using common.xamarin.Core.ViewModels;

[assembly: ExportRenderer (typeof (common.xamarin.Core.Views.EntryView), typeof (tempmatch.xamarin.core.iOS.EntryViewRenderer))]
namespace tempmatch.xamarin.core.iOS
{
	public class EntryViewRenderer : EntryRenderer
	{
		#region Fields

		public static UIColor FloatingLabelActiveTextColor = UIColor.Blue;
		public static string IsRequiredText = " *";

		#endregion Fields

		#region Constructors

		public EntryViewRenderer ()
		{
		}

		#endregion Constructors

		#region Properties

		protected UILabel FloatingLabel 
		{ 
			get; 
			set;
		}

		protected UILabel ValidationLabel 
		{ 
			get; 
			set;
		}

		protected EntryView EntryView
		{
			get
			{
				return (EntryView)Element;
			}
		}

		protected BaseViewModel ViewModel
		{
			get
			{
				return (BaseViewModel) EntryView.BindingContext;
			}
		}

		#endregion Properties

		#region Methods

		private void InitView(UITextField textField)
		{
			if (FloatingLabel == null)
			{
				FloatingLabel = new UILabel
				{
					TranslatesAutoresizingMaskIntoConstraints = false,
					//Alpha = 0.0f
					BackgroundColor = UIColor.Clear,
					Font = UIFont.FromName(Control.Font.Name, 11.5f),
				};

				//uncomment below to re-add floating label. Also set text vertical alignment to allow for the float label space
				textField.AddSubview(FloatingLabel);
			}

			if (ValidationLabel == null)
			{
				ValidationLabel = new UILabel
				{
					TranslatesAutoresizingMaskIntoConstraints = false,
					//Alpha = 0.0f
					BackgroundColor = UIColor.Clear,
					Font = UIFont.FromName(Control.Font.Name, 11.5f),
					TextColor = UIColor.Red,
				};

				//uncomment below to re-add floating label. Also set text vertical alignment to allow for the float label space
				textField.AddSubview(ValidationLabel);
			}

			RemoveFluentConstraints();
			AddFluentConstraints();
		}

		private void AddFluentConstraints()
		{
			Control.AddConstraints(new[]
			{
				FloatingLabel.AtTopOf(Control),
				FloatingLabel.AtLeftOf(Control),
				FloatingLabel.WithSameWidth(Control),
				FloatingLabel.Height().EqualTo(15f),

				ValidationLabel.AtBottomOf(Control),
				ValidationLabel.AtLeftOf(Control),
				ValidationLabel.WithSameWidth(Control),
				ValidationLabel.Height().EqualTo(15f),
			});
		}

		private void RemoveFluentConstraints()
		{
			Control.RemoveConstraints();
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			try
			{
				base.OnElementChanged(e);

				if (this.EntryView != null) 
				{
					InitView(Control);
					DrawBorder (this.EntryView);
					//SetFont(view);
					//SetFontSize(view);
					SetPlaceholderTextColor (this.EntryView);
	                //Control.BorderStyle = UITextBorderStyle.None;

					Control.EditingChanged += Control_ValueChanged;

					FloatingLabel.TextColor = this.EntryView.PlaceholderColor.ToUIColor();
				}
			}
			catch(Exception ex)
			{
				//Do Nothing for now
			}
		}

		void Control_ValueChanged (object sender, EventArgs e)
		{
			this.ViewModel.UpdateValidation(this.EntryView.FieldName);
			FloatingLabel.Text = Control.Text.Length > 0 ? Control.Placeholder : string.Empty;
			ValidationLabel.Text = this.EntryView.ValidationText;
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			try
			{
				base.OnElementPropertyChanged(sender, e);

				if (this.EntryView != null) 
				{
					DrawBorder (this.EntryView);

					if (string.IsNullOrEmpty (e.PropertyName) || e.PropertyName == "Font")
					{
						SetFont (this.EntryView);
					}

					if (string.IsNullOrEmpty (e.PropertyName) || e.PropertyName == "FontSize")
					{
						SetFontSize (this.EntryView);
					}

					if (string.IsNullOrEmpty (e.PropertyName) || e.PropertyName == "PlaceholderTextColor")
					{
						SetPlaceholderTextColor (this.EntryView);
					}

					//this.ViewModel.UpdateValidation();
					ValidationLabel.Text = this.EntryView.ValidationText;
				}
			}
			catch(Exception ex)
			{
				//Do Nothing for now
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			var view = (EntryView)Element;

			if (view != null) 
			{
				DrawBorder (view);
			}


			BringSubviewToFront(FloatingLabel);

			//Action updateLabelAction = () =>
			//{
			//	if (!string.IsNullOrEmpty(this.Element.Text))
			//	{
			//		FloatingLabel.Alpha = 1.0f;
			//		FloatingLabel.Frame =
			//			             new CGRect(
			//				             FloatingLabel.Frame.Location.X,
			//				             - FloatingLabel.Font.LineHeight/2,
			//				             FloatingLabel.Frame.Size.Width + 20f,
			//				             FloatingLabel.Frame.Size.Height);
			//	}
			//	else
			//	{
			//		FloatingLabel.Alpha = 0.0f;
			//		FloatingLabel.Frame =
			//			             new CGRect(
			//				             FloatingLabel.Frame.Location.X,
			//				             FloatingLabel.Font.LineHeight,
			//				             FloatingLabel.Frame.Size.Width + 20f,
			//				             FloatingLabel.Frame.Size.Height);
			//	}
			//};

			//if (IsFirstResponder)
			//{
			//	FloatingLabel.TextColor = FloatingLabelActiveTextColor;

			//	var shouldFloat = !string.IsNullOrEmpty(this.Element.Text);
			//	var isFloating = FloatingLabel.Alpha == 1f;

			//	if (shouldFloat == isFloating)
			//	{
			//		updateLabelAction();
			//	}
			//	else
			//	{
			//		UIView.Animate(
			//			0.3f,
			//			0.0f,
			//			UIViewAnimationOptions.BeginFromCurrentState | UIViewAnimationOptions.CurveEaseOut,
			//			updateLabelAction,
			//			() => { });
			//	}
			//}
			//else
			//{
			//	FloatingLabel.TextColor = view.PlaceholderColor.ToUIColor();

			//	if (FloatingLabel.Text == null)
			//	{
			//		FloatingLabel.Text = string.Empty;
			//	}
			//	//if (this.IsPicker)
			//	//{
			//	//	FloatingLabel.Text = FloatingLabel.Text.Replace("Select ", string.Empty);
			//	//}
			if (EntryView.IsRequired)
			{
				if (!EntryView.Placeholder.EndsWith(IsRequiredText))
				{
					EntryView.Placeholder = EntryView.Placeholder + IsRequiredText;
				}

				if (FloatingLabel != null && FloatingLabel.Text != null)
				{
					if (!FloatingLabel.Text.EndsWith(IsRequiredText))
					{
						FloatingLabel.Text = FloatingLabel.Text + IsRequiredText;
					}
				}
			}
			//	updateLabelAction();
			//}

			//FloatingLabel.SizeToFit();
			//FloatingLabel.Frame =
			//	                 new CGRect(
			//		                 0f,
			//		                 FloatingLabel.Font.LineHeight,
			//		                 FloatingLabel.Frame.Size.Width + 20f,
			//		                 FloatingLabel.Frame.Size.Height);

			FloatingLabel.TextColor = view.PlaceholderColor.ToUIColor();
			FloatingLabel.Text = Control.Text.Length > 0 ? Control.Placeholder : string.Empty;
		}

		private void DrawBorder (EntryView view)
		{
			var borderLayer = new CALayer ();
			borderLayer.MasksToBounds = true;
			borderLayer.Frame = new CoreGraphics.CGRect (0f, Control.Frame.Height - 17.5f, Control.Frame.Width, 2f);
			borderLayer.BorderColor = view.BorderColor.ToCGColor ();
			borderLayer.BorderWidth = 2.0f;

			Control.Layer.AddSublayer (borderLayer);
			Control.BorderStyle = UITextBorderStyle.None;
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
			if ( (view.Font.FontFamily == null) || (view.Font.FontFamily == string.Empty) )
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

		private void SetPlaceholderTextColor (EntryView view)
		{
			if (string.IsNullOrEmpty (view.Placeholder) == false && view.PlaceholderColor != Color.Default) {
				var placeholderString = new NSAttributedString (view.Placeholder, new UIStringAttributes { ForegroundColor = view.PlaceholderColor.ToUIColor () });
				Control.AttributedPlaceholder = placeholderString;
			}
		}

		#endregion Methods
	}
}