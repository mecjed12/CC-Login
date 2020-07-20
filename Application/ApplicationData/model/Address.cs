using ApplicationData.attribute;
using ApplicationData.enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ApplicationData.model
{
	[Table("address")]//Needed otherwise the name of the DBset is used to find the table
	public class Address : CreatedModified, IApplicationSubclass
	{
		//TODO ask how i should order them
		[ApplicationProperty(DisplayName = "Strasse", Index = 8)]
		public string Street { get; set; }

		[ApplicationProperty(DisplayName = "Ort", Index = 10)]
		public string Place { get; set; }

		[ApplicationProperty(DisplayName = "Postleitzahl", Index = 9)]
		[Column("zip")]
		public int? ZipCode { get; set; }

		[ApplicationProperty(DisplayName = "Land", Index = 11)]
		public string Country { get; set; }

		[Relation]
		public List<RelPersonAddress> PAddress { get; set; }

		public List<PropertyInfo> GetProperties()
		{
			return GetType().GetProperties().Where(x => x.IsDefined(typeof(ApplicationPropertyAttribute), false)).ToList();
		}
	}
}
