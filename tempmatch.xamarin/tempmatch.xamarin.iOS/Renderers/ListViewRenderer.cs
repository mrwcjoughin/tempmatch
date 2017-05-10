using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;

using common.xamarin.Core.Views;
using tempmatch.xamarin.core.iOS;

[assembly: ExportRenderer (typeof (common.xamarin.Core.Views.ListView), typeof (tempmatch.xamarin.core.iOS.ListViewRenderer))]
namespace tempmatch.xamarin.core.iOS
{
	public class ListViewRenderer : Xamarin.Forms.Platform.iOS.ListViewRenderer
    {
        #region Constructors

        public ListViewRenderer ()
        {
        }

        #endregion Constructors

        #region Methods

        protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged (e);

            Control.ShowsVerticalScrollIndicator = false;
        }

        #endregion Methods
    }
}