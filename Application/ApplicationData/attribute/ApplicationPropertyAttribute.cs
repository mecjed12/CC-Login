using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationData.attribute
{
	public class ApplicationPropertyAttribute : Attribute
	{
		public string DisplayName { get; set; }
	}
}
