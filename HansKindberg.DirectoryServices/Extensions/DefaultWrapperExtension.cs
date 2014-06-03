using System;
using System.Globalization;

namespace HansKindberg.Abstractions.Extensions
{
	[Obsolete("Move this to https://github.com/HansKindberg-Net/HansKindberg-Abstractions.")]
	public class DefaultWrapperExtension : IWrapperExtension
	{
		#region Methods

		public virtual T GetWrappedInstance<T>(object potentialWrapper)
		{
			if(potentialWrapper == null)
				return default(T);

			var wrapper = potentialWrapper as IWrapper<T>;

			if(wrapper != null)
				return wrapper.WrappedInstance;

			throw new NotImplementedException(string.Format(CultureInfo.InvariantCulture, "The object of type \"{0}\" does not implement \"{1}\".", potentialWrapper.GetType(), typeof(IWrapper<T>)));
		}

		#endregion
	}
}