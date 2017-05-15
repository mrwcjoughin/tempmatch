using System;
using System.IO;
using System.Threading.Tasks;
using common.xamarin.Core;
using common.xamarin.Core.ViewModels;
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

        #endregion Fields

        #region Constructors

        public SignUpViewModel()
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