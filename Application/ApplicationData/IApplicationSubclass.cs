using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApplicationData
{
	public interface IApplicationSubclass
	{
		/// <summary>
		/// Get the SubClass Properties
		/// </summary>
		/// <returns>A List of PropertyInfo</returns>
		List<PropertyInfo> GetProperties();
	}

}
