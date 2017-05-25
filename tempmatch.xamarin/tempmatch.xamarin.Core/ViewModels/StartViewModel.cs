using System;
using System.Threading.Tasks;
using common.xamarin.Core.ViewModels;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace tempmatch.xamarin.Core.ViewModels
{
	public class StartViewModel : BaseViewModel
	{
		#region Fields

		private string _emailAddress = string.Empty;
		private string _password = string.Empty;
		private string _emailAddressValidation = string.Empty;
		private string _passwordValidation = string.Empty;

		private IMvxAsyncCommand _loginCommand = null;
		private IMvxAsyncCommand _signUpCommand = null;

		#endregion Fields

        #region Constructors

		public StartViewModel(IMvxNavigationService navigation)
            : base(navigation)
        {

		}

        #endregion Constructors

		#region Properties

		public IMvxAsyncCommand GotoLoginCommand
		{
			get
			{
				_loginCommand = _loginCommand ?? new MvxAsyncCommand (GotoLogin);

				return _loginCommand;
			}
		}

		public IMvxAsyncCommand GotoSignUpCommand
		{
			get
			{
				_signUpCommand = _signUpCommand ?? new MvxAsyncCommand (GotoSignUp);

				return _signUpCommand;
			}
		}

		#endregion Properties

		#region Methods

		private async Task GotoLogin()
		{
			if (!IsLoading)
			{
				try
				{
					IsLoading = true;

					_navigationService.Navigate<LoginViewModel>();
				}
				finally
				{
					IsLoading = false;
				}
			}
		}

		private async Task GotoSignUp()
		{
			if (!IsLoading)
			{
				try
				{
					IsLoading = true;

					_navigationService.Navigate<SignUpViewModel>();
				}
				finally
				{
					IsLoading = false;
				}
			}
		}

		public override void UpdateValidation(string specificFieldName = null)
		{
		}

		#endregion Methods
	}
}