using ImporterData.attribute;
using System;

namespace ImporterData.model
{
	public class BasePerson : CreatedModified
	{
		[ImportProperty(DisplayName = "Vorname", Required = true, Index = 0)]
		public string Name1 { get; set; }

		[ImportProperty(DisplayName = "Zuname", Required = true, Index = 1)]
		public string Name2 { get; set; }

		[ImportProperty(DisplayName = "Geburtsdatum", Required = true, Index = 2)]
		public DateTime? Date { get; set; }

	}
}
