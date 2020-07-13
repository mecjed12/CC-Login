using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationData.attribute
{
	public class RelationAttribute : Attribute
	{
		public Type Relation { get; set; }

	}
}
