using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationData
{
	public interface IApplicationSubclass
	{
		List<System.Reflection.PropertyInfo> GetProperties();
	}

}
