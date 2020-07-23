using System.Collections.Generic;
using System.Reflection;

namespace ImporterData
{
	public interface IImportClass
	{
		/// <summary>
		/// Get the Import Properties
		/// </summary>
		/// <returns>A List of PropertyInfo</returns>
		List<PropertyInfo> GetProperties();

		/// <summary>
		/// Get the SubClasses of the ImportClass
		/// </summary>
		/// <returns>A List of SubClasses</returns>
		List<IImportSubclass> GetSubclasses();

	}
}
