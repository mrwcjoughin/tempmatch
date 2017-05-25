using common.xamarin.Core.ViewModels;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace tempmatch.xamarin.Core.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		#region Constructors

		public AboutViewModel(IMvxNavigationService navigation)
            : base(navigation)
        {

		}

		#endregion Constructors

		#region Methods

		public override void UpdateValidation (string specificFieldName = null)
		{
			//Nothing to do here in this ViewModel
		}

		#endregion Methods
	}
}