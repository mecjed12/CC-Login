using System;

namespace ApplicationData.model
{
	public class BasePerson : CreatedModify
	{
		public int Id { get; set; }

		[ApplicationProperty]
		public string Name1 { get; set; }

		[ApplicationProperty]
		public string Name2 { get; set; }

		[ApplicationProperty]
		public DateTime? Date { get; set; }

	}
}
