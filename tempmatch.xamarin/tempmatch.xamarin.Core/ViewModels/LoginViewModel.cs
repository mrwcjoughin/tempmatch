using System;
using System.Threading.Tasks;
using common.xamarin.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace tempmatch.xamarin.Core.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		#region Fields

		private string _emailAddress = string.Empty;
		private string _password = string.Empty;
		private string _emailAddressValidation = string.Empty;
		private string _passwordValidation = string.Empty;

		private IMvxAsyncCommand _loginCommand = null;
		private IMvxAsyncCommand _termsAndConditionsCommand = null;

		#endregion Fields

		#region Constructors

		public LoginViewModel ()
		{
			
		}

		#endregion Constructors

		#region Properties

		public string EmailAddress
		{
			get
			{
				return _emailAddress;
			}
			set
			{
				_emailAddress = value;
				SetProperty(ref _emailAddress, value);
				OnPropertyChanged ("EmailAddress");
			}
		}

		public string EmailAddressValidation
		{
			get
			{
				return _emailAddressValidation;
			}
			set
			{
				_emailAddressValidation = value;
				SetProperty(ref _emailAddressValidation, value);
				OnPropertyChanged ("EmailAddressValidation");
			}
		}

		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				SetProperty(ref _password, value);
				OnPropertyChanged ("Password");
			}
		}

		public string PasswordValidation
		{
			get
			{
				return _passwordValidation;
			}
			set
			{
				_passwordValidation = value;
				SetProperty(ref _passwordValidation, value);
				OnPropertyChanged ("PasswordValidation");
			}
		}

		public IMvxAsyncCommand LoginCommand
		{
			get
			{
				_loginCommand = _loginCommand ?? new MvxAsyncCommand (LoginBase);

				return _loginCommand;
			}
		}

		public IMvxAsyncCommand TermsAndConditionsCommand
		{
			get
			{
				_termsAndConditionsCommand = _termsAndConditionsCommand ?? new MvxAsyncCommand (GotoToTermsAndConditions);

				return _termsAndConditionsCommand;
			}
		}

		#endregion Properties

		#region Methods

		private async Task LoginBase()
		{
			try
			{
				await Login ();
			}
			catch (Exception)
			{

			}
		}
		private async Task Login()
		{
			if (!IsLoading)
			{
				try
				{
					IsLoading = true;

					//var loopUser = new LoopUser () { EmailAddress = this.Username, Password = this.Username };

					//var loginResult = await AppContext.CurrentAppDataContext.LoginAsync (loopUser);

					//if (loginResult == null)
					//{
					//	throw new Exception("Login Failed : Username or Password Incorrect");
					//}

					//var results = await AppContext.CurrentLoopUserManager.LoadLoopUsers();

					//var result = (from lu in results
					//              where lu.EmailAddress == this.Username
					//              && lu.Password == this.Password
					//              select lu
					//             ).FirstOrDefault();

					//AppContext.CurrentLoopUser = result;

					//SessionContext.UserName = this.Username;
					//SessionContext.Password = this.Password;

					//SessionContext.CurrentNavigationHandler.Navigate (new NavigationItem (aliens.loop.xamarin.core.Navigation.NavigationPages.Root, aliens.loop.xamarin.core.Navigation.NavigationViews.RecentLoops));
					//ShowViewModel<DashboardViewModel>();
				} 
				//catch(Exception)
				//{

				//}
				finally
				{
					IsLoading = false;
				}
			}
		}

		private async Task GotoToTermsAndConditions()
		{
			if (!IsLoading)
			{
				try
				{
					IsLoading = true;
					//SessionContext.CurrentNavigationHandler.Navigate (new NavigationItem (aliens.loop.xamarin.core.Navigation.NavigationPages.TermsAndConditions, aliens.loop.xamarin.core.Navigation.NavigationViews.TermsAndConditions));
					ShowViewModel<TermsViewModel>();
				}
				finally
				{
					IsLoading = false;
				}
			}
		}

		public override void UpdateValidation(string specificFieldName = null)
		{
			if ( (specificFieldName == null) || (specificFieldName == "EmailAddress") )
			{
				if (EmailAddress.Length > 0)
				{
					EmailAddressValidation = string.Empty;
				}
				else
				{
					EmailAddressValidation = "Field is required";
				}
			}

			if ( (specificFieldName == null) || (specificFieldName == "Password") )
			{
				if (Password.Length > 0)
				{
					PasswordValidation = string.Empty;
				}
				else
				{
					PasswordValidation = "Field is required";
				}
			}
		}

		#endregion Methods
	}
}