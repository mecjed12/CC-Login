using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApplicationData
{
	public interface IApplicationClass
	{
		/// <summary>
		/// Get the Application Properties
		/// </summary>
		/// <returns>A List of PropertyInfo</returns>
		List<PropertyInfo> GetProperties();

		/// <summary>
		/// Get the SubClasses of the ApplicationClass
		/// </summary>
		/// <returns>A List of SubClasses</returns>
		List<IApplicationSubclass> GetSubclasses();

	}

}
