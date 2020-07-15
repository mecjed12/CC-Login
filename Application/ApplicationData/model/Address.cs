using ApplicationData.attribute;
using ApplicationData.enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ApplicationData.model
{
	public class Address : CreatedModify, IApplicationSubclass
	{
		public int Id { get; set; }

		[ApplicationProperty(DisplayName = "Strasse", Required = true)]
		public string Street { get; set; }

		[ApplicationProperty(DisplayName = "Ort", Required = true)]
		public string Place { get; set; }

		[ApplicationProperty(DisplayName = "Postleitzahl", Required = true)]
		[Column("zip")]
		public int? ZipCode { get; set; }

		[ApplicationProperty(DisplayName = "Land", Required = true)]
		public string Country { get; set; }

		[Relation]
		public List<RelPersonAddress> PAddress { get; set; }

		public List<PropertyInfo> GetProperties()
		{
			return GetType().GetProperties().Where(x => x.IsDefined(typeof(ApplicationPropertyAttribute), false)).ToList();
		}
	}
}
