using ImporterData;
using ImporterData.attribute;
using ImporterData.model.relations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ImporterData.model
{
	[Table("address")]//Needed otherwise the name of the DBset is used to find the table
	public class Address : CreatedModified, IImportSubclass
	{
		[ImportProperty(DisplayName = "Strasse", Index = 8)]
		public string Street { get; set; }

		[ImportProperty(DisplayName = "Ort", Index = 10)]
		public string Place { get; set; }

		[ImportProperty(DisplayName = "Postleitzahl", Index = 9)]
		[Column("zip")]
		public int? ZipCode { get; set; }

		[ImportProperty(DisplayName = "Land", Index = 11)]
		public string Country { get; set; }

		[Relation]
		public List<RelPersonAddress> PAddress { get; set; }

		public List<PropertyInfo> GetProperties()
		{
			return GetType().GetProperties().Where(x => x.IsDefined(typeof(ImportPropertyAttribute), false)).ToList();
		}
	}
}
