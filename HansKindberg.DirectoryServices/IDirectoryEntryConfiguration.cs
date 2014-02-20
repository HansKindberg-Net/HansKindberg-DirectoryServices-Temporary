using System.DirectoryServices;

namespace HansKindberg.DirectoryServices
{
	public interface IDirectoryEntryConfiguration
	{
		#region Properties

		int PageSize { get; set; }
		PasswordEncodingMethod PasswordEncoding { get; set; }
		int PasswordPort { get; set; }
		ReferralChasingOption Referral { get; set; }
		SecurityMasks SecurityMasks { get; set; }

		#endregion

		#region Methods

		string GetCurrentServerName();
		bool IsMutuallyAuthenticated();
		void SetUserNameQueryQuota(string accountName);

		#endregion
	}
}