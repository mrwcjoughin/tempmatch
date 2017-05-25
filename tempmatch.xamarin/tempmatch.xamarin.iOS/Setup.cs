using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using UIKit;
using Xamarin.Forms;
using MvvmCross.Forms;
using MvvmCross.Forms.iOS;
using MvvmCross.Forms.iOS.Presenters;
using MvvmCross.iOS.Support;
using MvvmCross.Core.Views;
using MvvmCross.Platform.iOS.Platform;
using MvvmCross.Forms.Core;

namespace tempmatch.xamarin.iOS
{
	public class Setup : MvxIosSetup
	{
		public Setup (MvxFormsApplicationDelegate applicationDelegate, UIWindow window)
			: base (applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Core.App ();
		}

		protected override IMvxTrace CreateDebugTrace ()
		{
			return new DebugTrace ();
		}

		protected override IMvxIosViewPresenter CreatePresenter()
		{
			Forms.Init();

			var xamarinFormsApp = new MvxFormsApplication();
            return new MvxFormsIosPagePresenter(Window, xamarinFormsApp);
		}
	}
}
