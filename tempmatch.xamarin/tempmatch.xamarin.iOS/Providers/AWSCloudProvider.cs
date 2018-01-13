using System;

using tempmatch.xamarin.Core.Interfaces;

using Amazon;
using Amazon.CognitoIdentity;
using Amazon.CognitoSync.SyncManager;

namespace tempmatch.xamarin.iOS.Providers
{
    public class AWSCloudProvider : IAWSCloudProvider
    {
        private CognitoAWSCredentials _cognitoAWSCredentials;
        private CognitoSyncManager _cognitoSyncManager;
        private AWSIdentityProvider _aWSIdentityProvider;

        public AWSCloudProvider()
        {
			AWSConfigs.AWSRegion = "eu-west-2";
			AWSConfigs.CorrectForClockSkew = true;

			var loggingConfig = AWSConfigs.LoggingConfig;
			loggingConfig.LogMetrics = true;
			loggingConfig.LogResponses = ResponseLoggingOption.Always;
			loggingConfig.LogMetricsFormat = LogMetricsFormatOption.JSON;
			loggingConfig.LogTo = LoggingOptions.SystemDiagnostics;

			var cognitoAWSCcredentials = new Amazon.CognitoIdentity.CognitoAWSCredentials("eu-west-2:5482fe82-1e73-43c0-966e-7812de8108de", RegionEndpoint.EUWest2);


			CognitoSyncManager syncManager = new CognitoSyncManager(
				cognitoAWSCcredentials,
				new Amazon.CognitoSync.AmazonCognitoSyncConfig
				{
					RegionEndpoint = RegionEndpoint.EUWest2 // Region
				}
			);

		}

        CognitoAWSCredentials IAWSCloudProvider.CognitoAWSCredentials 
        {
            get
            {
                return _cognitoAWSCredentials;    
            }
            set
			{
                _cognitoAWSCredentials = value;
			}
        }

        CognitoSyncManager IAWSCloudProvider.CognitoSyncManager
        {
			get
			{
				return _cognitoSyncManager;
			}
			set
			{
				_cognitoSyncManager = value;
			}
        }

		AWSIdentityProvider IAWSCloudProvider.AWSIdentityProvider
		{
			get
			{
				return _aWSIdentityProvider;
			}
			set
			{
				_aWSIdentityProvider = value;
			}
		}
    }
}