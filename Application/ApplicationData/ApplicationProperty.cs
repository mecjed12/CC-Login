using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationData
{
	public class ApplicationProperty : Attribute
	{
		public string DisplayName { get; set; }

		public ApplicationProperty(string displayName)
		{
			DisplayName = displayName;
		}

		public ApplicationProperty()
		{

		}
	}
}
