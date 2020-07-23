using ImporterData;
using ImporterData.repo;
using ImporterData.model;
using System.Linq;

namespace ImporterData.repo
{
	public class AddressRepository : Repository<Address>
	{
		public AddressRepository(DcvEntities entities) : base(entities)
		{
		}

		public override Address Get(Address address)
		{
			return Entities.Addresses.FirstOrDefault(x => x.Street == address.Street && x.Place == address.Place && x.ZipCode == address.ZipCode && x.Country == address.Country);
		}
	}
}
