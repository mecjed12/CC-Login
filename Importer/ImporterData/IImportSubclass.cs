using System.Collections.Generic;
using System.Reflection;

namespace ImporterData
{
	public interface IImportSubclass
	{
		/// <summary>
		/// Get the SubClass Properties
		/// </summary>
		/// <returns>A List of PropertyInfo</returns>
		List<PropertyInfo> GetProperties();
	}

}
