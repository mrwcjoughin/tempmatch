using Android.Content;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Droid.Presenters;
using MvvmCross.Forms.Core;

namespace tempmatch.xamarin.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup (Context applicationContext)
			: base (applicationContext)
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

		protected override IMvxAndroidViewPresenter CreateViewPresenter ()
		{
			var xamarinFormsApp = new MvxFormsApplication();
            var presenter = new MvxFormsDroidPagePresenter (xamarinFormsApp);
			Mvx.RegisterSingleton<IMvxViewPresenter> (presenter);

			return presenter;
		}
	}
}