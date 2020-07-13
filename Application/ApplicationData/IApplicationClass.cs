using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApplicationData
{
	public interface IApplicationClass
	{
		List<PropertyInfo> GetProperties();

		List<IApplicationSubclass> GetSubclasses();

		List<PropertyInfo> GetSubclassProperties();

	}

}
