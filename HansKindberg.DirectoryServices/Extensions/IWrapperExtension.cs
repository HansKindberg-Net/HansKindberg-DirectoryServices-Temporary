using System;

namespace HansKindberg.Abstractions.Extensions
{
	[Obsolete("Move this to https://github.com/HansKindberg-Net/HansKindberg-Abstractions.")]
	public interface IWrapperExtension
	{
		#region Methods

		T GetWrappedInstance<T>(object potentialWrapper);

		#endregion
	}
}