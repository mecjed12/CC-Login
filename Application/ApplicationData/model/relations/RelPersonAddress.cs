using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationData.model
{
	[Table("addressperson")]
	public class RelPersonAddress
	{
		public int Id { get; set; }

		public int AddressId { get; set; }
		public int PersonId { get; set; }

		public Address Address { get; set; }
		public Person Person { get; set; }

	}
}
