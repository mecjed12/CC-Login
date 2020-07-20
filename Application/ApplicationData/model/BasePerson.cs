using ApplicationData.attribute;
using System;

namespace ApplicationData.model
{
	public class BasePerson : CreatedModified
	{
		[ApplicationProperty(DisplayName = "Vorname", Required = true, Index = 0)]
		public string Name1 { get; set; }
		
		[ApplicationProperty(DisplayName = "Zuname", Required = true, Index = 1)]
		public string Name2 { get; set; }

		[ApplicationProperty(DisplayName = "Geburtsdatum", Required = true, Index = 2)]
		public DateTime? Date { get; set; }

	}
}
