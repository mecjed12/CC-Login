using System;

namespace ApplicationData.attribute
{
	public class ApplicationPropertyAttribute : Attribute
	{
		public string DisplayName { get; set; }

		public bool Required { get; set; } = false;

		/// <summary>
		/// Used to sort the properties
		/// default value = 32,767(Max short)
		/// </summary>
		public short Index { get; set; } = short.MaxValue;
	}
}
