using System;

namespace ImporterData.attribute
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ImportPropertyAttribute : Attribute
	{
		public string DisplayName { get; set; }

		public bool Required { get; set; } = false;

		/// <summary>
		/// Used to sort the properties
		/// default value = 32,767(Max Signed 16-bit integer)
		/// </summary>
		public short Index { get; set; } = short.MaxValue;
	}
}
