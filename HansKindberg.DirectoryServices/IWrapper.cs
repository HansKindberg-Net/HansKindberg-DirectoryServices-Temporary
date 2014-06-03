using System;

namespace HansKindberg.Abstractions
{
	[Obsolete("Move this to https://github.com/HansKindberg-Net/HansKindberg-Abstractions.")]
	public interface IWrapper<out T>
	{
		#region Properties

		T WrappedInstance { get; }

		#endregion
	}
}