using System.DirectoryServices;
using HansKindberg.Abstractions;

namespace HansKindberg.DirectoryServices
{
	public class DirectoryEntryConfigurationWrapper : Wrapper<DirectoryEntryConfiguration>, IDirectoryEntryConfiguration
	{
		#region Constructors

		public DirectoryEntryConfigurationWrapper(DirectoryEntryConfiguration directoryEntryConfiguration) : base(directoryEntryConfiguration, "directoryEntryConfiguration") {}

		#endregion

		#region Properties

		public virtual int PageSize
		{
			get { return this.WrappedInstance.PageSize; }
			set { this.WrappedInstance.PageSize = value; }
		}

		public virtual PasswordEncodingMethod PasswordEncoding
		{
			get { return this.WrappedInstance.PasswordEncoding; }
			set { this.WrappedInstance.PasswordEncoding = value; }
		}

		public virtual int PasswordPort
		{
			get { return this.WrappedInstance.PasswordPort; }
			set { this.WrappedInstance.PasswordPort = value; }
		}

		public virtual ReferralChasingOption Referral
		{
			get { return this.WrappedInstance.Referral; }
			set { this.WrappedInstance.Referral = value; }
		}

		public virtual SecurityMasks SecurityMasks
		{
			get { return this.WrappedInstance.SecurityMasks; }
			set { this.WrappedInstance.SecurityMasks = value; }
		}

		#endregion

		#region Methods

		public static DirectoryEntryConfigurationWrapper FromDirectoryEntryConfiguration(DirectoryEntryConfiguration directoryEntryConfiguration)
		{
			return directoryEntryConfiguration;
		}

		public virtual string GetCurrentServerName()
		{
			return this.WrappedInstance.GetCurrentServerName();
		}

		public virtual bool IsMutuallyAuthenticated()
		{
			return this.WrappedInstance.IsMutuallyAuthenticated();
		}

		public virtual void SetUserNameQueryQuota(string accountName)
		{
			this.WrappedInstance.SetUserNameQueryQuota(accountName);
		}

		#endregion

		#region Implicit operator

		public static implicit operator DirectoryEntryConfigurationWrapper(DirectoryEntryConfiguration directoryEntryConfiguration)
		{
			return directoryEntryConfiguration == null ? null : new DirectoryEntryConfigurationWrapper(directoryEntryConfiguration);
		}

		#endregion
	}
}