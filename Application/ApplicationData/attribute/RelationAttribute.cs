using System;

namespace ApplicationData.attribute
{
	public class RelationAttribute : Attribute
	{
		public Type Relation { get; set; }

	}
}
