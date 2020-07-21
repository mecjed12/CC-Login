using ApplicationData.model;
using System.Linq;

namespace ApplicationData.repo
{
	public class AddressRepository : Repository<Address>
	{
		public AddressRepository(DcvEntities entities) : base(entities)
		{
		}

		public override Address GetOne(Address address)
		{
			return Entities.Addresses.FirstOrDefault(x => x.Street == address.Street && x.Place == address.Place && x.ZipCode == address.ZipCode && x.Country == address.Country);
		}
	}
}
