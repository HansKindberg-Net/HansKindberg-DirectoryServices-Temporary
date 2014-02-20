﻿using System.DirectoryServices;

namespace HansKindberg.DirectoryServices
{
	public class Directory : IDirectory
	{
		#region Fields

		private readonly AuthenticationTypes? _authenticationTypes;
		private readonly string _password;
		private readonly string _userName;

		#endregion

		#region Constructors

		public Directory() {}

		public Directory(AuthenticationTypes authenticationTypes)
		{
			this._authenticationTypes = authenticationTypes;
		}

		public Directory(string userName, string password)
		{
			this._password = password;
			this._userName = userName;
		}

		public Directory(string userName, string password, AuthenticationTypes authenticationTypes) : this(userName, password)
		{
			this._authenticationTypes = authenticationTypes;
		}

		#endregion

		#region Properties

		protected internal virtual AuthenticationTypes? AuthenticationTypes
		{
			get { return this._authenticationTypes; }
		}

		protected internal virtual string Password
		{
			get { return this._password; }
		}

		protected internal virtual string UserName
		{
			get { return this._userName; }
		}

		#endregion

		#region Methods

		public virtual bool Exists(string path)
		{
			return DirectoryEntry.Exists(path);
		}

		public virtual IDirectoryEntry Get(string path)
		{
			return (DirectoryEntryWrapper) this.GetDirectoryEntry(path);
		}

		protected internal virtual DirectoryEntry GetDirectoryEntry(string path)
		{
			DirectoryEntry directoryEntry = new DirectoryEntry(path, this.UserName, this.Password);

			if(this.AuthenticationTypes.HasValue)
				directoryEntry.AuthenticationType = this.AuthenticationTypes.Value;

			return directoryEntry;
		}

		#endregion
	}
}