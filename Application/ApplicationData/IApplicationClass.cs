using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationData
{
	public interface IApplicationClass
	{
		List<System.Reflection.PropertyInfo> GetProperties();
	}

}
