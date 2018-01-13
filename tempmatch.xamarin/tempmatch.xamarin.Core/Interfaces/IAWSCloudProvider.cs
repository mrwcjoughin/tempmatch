using System;
using Amazon.CognitoIdentity;
using Amazon.CognitoSync.SyncManager;

namespace tempmatch.xamarin.Core.Interfaces
{
    public interface IAWSCloudProvider
    {
        CognitoAWSCredentials CognitoAWSCredentials
        {
            get;
            set;
        }

        CognitoSyncManager CognitoSyncManager
        {
			get;
			set;
        }

        Amazon.CognitoIdentity. AWSIdentityProvider AWSIdentityProvider
		{
			get;
			set;
		}
    }
}