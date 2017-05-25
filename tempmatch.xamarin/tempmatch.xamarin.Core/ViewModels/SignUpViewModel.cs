using System;
using System.IO;
using System.Threading.Tasks;
using common.xamarin.Core;
using common.xamarin.Core.ViewModels;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Xamarin.Forms;
using XLabs.Platform.Services.Media;

namespace tempmatch.xamarin.Core.ViewModels
{
	public class SignUpViewModel : BaseViewModel
	{
        #region Fields

        private Guid _accountUID = Guid.NewGuid();
        private MediaFile _avatarImageMediaFile;
        private ImageSource _avatarImageSource = null;
		private string _avatarImageSourceFileName = null;
        private IMvxAsyncCommand _chooseAvatarCommand;
        private bool _isTermsAndConditionsAccepted = false;

		#endregion Fields

		#region Constructors

		public SignUpViewModel(IMvxNavigationService navigation)
			: base(navigation)
        {
            Device.OnPlatform(
                iOS: () => _avatarImageSourceFileName = "avatar.png",
                Android: () => _avatarImageSourceFileName = "avatar.png",
                WinPhone: () => _avatarImageSourceFileName = "Resources/Images/avatar.png"
            );
        }

		#endregion Constructors

		#region Properties

		public Guid AccountUID
        {
			get
			{
				return _accountUID;
			}
			set
			{
				_accountUID = value;
				SetProperty(ref _accountUID, value);
				OnPropertyChanged("AccountUID");
			}
        }

		public MediaFile AvatarImageMediaFile
		{
			get
			{
				return _avatarImageMediaFile;
			}
			set
			{
				_avatarImageMediaFile = value;
				SetProperty(ref _avatarImageMediaFile, value);
				OnPropertyChanged("AvatarImageMediaFile");
			}
		}

		public ImageSource AvatarImageSource
		{
			get
			{
				if ((!IsBusy) && (_avatarImageSource == null))
				{
					_avatarImageSource = GetImageSource().Result;
					//_imageMessageSource = AsyncContext.RunTask (GetImageSource).Result;
				}

				return _avatarImageSource;
			}
			set
			{
				_avatarImageSource = value;
				OnPropertyChanged("AvatarImageSource");
			}
		}

        public IMvxAsyncCommand ChooseAvatarCommand
		{
			get
			{
				_chooseAvatarCommand = _chooseAvatarCommand ?? new MvxAsyncCommand(NavigateBack);
				return _chooseAvatarCommand;
			}
		}

        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private string _password;
        private string _phoneNumber;
        private string _zipcode;

        public string FirstName
        {
			get
			{
				return _firstName;
			}
			set
			{
				_firstName = value;
				SetProperty(ref _firstName, value);
				OnPropertyChanged("FirstName");
			}
        }

		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				_lastName = value;
				SetProperty(ref _lastName, value);
				OnPropertyChanged("LastName");
			}
		}

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
				OnPropertyChanged("_emailAddress");
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
				OnPropertyChanged("Password");
			}
		}

		public string PhoneNumber
		{
			get
			{
				return _phoneNumber;
			}
			set
			{
				_phoneNumber = value;
				SetProperty(ref _phoneNumber, value);
				OnPropertyChanged("PhoneNumber");
			}
		}

		public string Zipcode
		{
			get
			{
				return _zipcode;
			}
			set
			{
				_zipcode = value;
				SetProperty(ref _zipcode, value);
				OnPropertyChanged("Zipcode");
			}
		}

        public bool IsTermsAndConditionsAccepted
        {
			get
			{
				return _isTermsAndConditionsAccepted;
			}
			set
			{
				_isTermsAndConditionsAccepted = value;
				SetProperty(ref _isTermsAndConditionsAccepted, value);
				OnPropertyChanged("IsTermsAndConditionsAccepted");
			}
        }

		#endregion Properites

		#region Methods

		public async Task<ImageSource> GetImageSource()
		{
			if (!IsBusy)
			{
				IsLoading = true;
				//              ImageSource result = null;
				//
				//              if (_imageMessage != null)
				//              {
				//                  result = _imageMessage.Source;
				//              }
				if ((_avatarImageSourceFileName == null) || (_avatarImageSourceFileName == string.Empty))
				{
					_avatarImageSourceFileName = await Public.DownloadImageMediaFileToAWSS3("tempmatch-s3-bucket", "images", this.AccountUID.ToString()).ConfigureAwait(false);
				}

				IsLoading = false;
			}

			var result = _avatarImageMediaFile != null ? ImageSource.FromStream(() => _avatarImageMediaFile.Source) : ImageSource.FromFile(Path.Combine(SessionContext.DocumentsFolder, this.AccountUID.ToString()));

            return result;
		}

        public override void UpdateValidation(string specificFieldName = null)
		{
		}

		#endregion Methods
	}
}