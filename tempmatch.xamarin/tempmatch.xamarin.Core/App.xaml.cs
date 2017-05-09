using common.xamarin.Core;
using MvvmCross.Platform.IoC;
using Xamarin.Forms.Xaml;

namespace tempmatch.xamarin.Core
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public override void Initialize ()
		{
			CreatableTypes ()
				.EndingWith ("Service")
				.AsInterfaces ()
				.RegisterAsLazySingleton ();

			SessionContext.App = this;

			var styles = new StylesPage();
			Xamarin.Forms.Application.Current.Resources = styles.Resources;
			SessionContext.Resources = styles.Resources;

			SessionContext.Init ();

			RegisterAppStart<ViewModels.LoginViewModel> ();
		}
	}
}