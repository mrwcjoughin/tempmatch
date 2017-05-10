using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using Foundation;
using UIKit;

using common.xamarin.Core.Views;
using tempmatch.xamarin.core.iOS;

[assembly: ExportRenderer ( typeof (ButtonView), typeof (ButtonViewRenderer ) ) ]
namespace tempmatch.xamarin.core.iOS
{
	public class ButtonViewRenderer : ButtonRenderer
	{
		public ButtonViewRenderer ()
		{
		}

		protected override void OnElementChanged ( ElementChangedEventArgs<Button> e )
		{
			base.OnElementChanged  (e );

			if ( Control != null ) 
			{   
				Control.TouchUpInside += ( sender, el ) =>
				{
					UIView ctl = Control;
					while ( true )
					{
						ctl = ctl.Superview;
						if ( ctl.Description.Contains ( "UIView" ) )
							break;
					}
					ctl.EndEditing ( true );
				};
			}
		}
	}
}