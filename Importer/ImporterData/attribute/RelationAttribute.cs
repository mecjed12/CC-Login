using System;

namespace ImporterData.attribute
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
	public class RelationAttribute : Attribute
	{
		public Type Relation { get; set; }
	}
}
