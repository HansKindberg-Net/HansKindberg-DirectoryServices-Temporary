using System;

namespace HansKindberg.Abstractions.Extensions
{
	[Obsolete("Move this to https://github.com/HansKindberg-Net/HansKindberg-Abstractions.")]
	public static class WrapperExtension
	{
		#region Fields

		private static volatile IWrapperExtension _instance;
		private static readonly object _lockObject = new object();

		#endregion

		#region Properties

		public static IWrapperExtension Instance
		{
			get
			{
				if(_instance == null)
				{
					lock(_lockObject)
					{
						if(_instance == null)
							_instance = new DefaultWrapperExtension();
					}
				}

				return _instance;
			}
			set
			{
				if(Equals(_instance, value))
					return;

				lock(_lockObject)
				{
					_instance = value;
				}
			}
		}

		#endregion

		#region Methods

		public static T GetWrappedInstance<T>(this object potentialWrapper)
		{
			return Instance.GetWrappedInstance<T>(potentialWrapper);
		}

		#endregion
	}
}