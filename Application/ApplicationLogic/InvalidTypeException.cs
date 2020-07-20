using System;

namespace ApplicationLogic
{
	public class InvalidTypeException : Exception
	{
		public InvalidTypeException() : base()
		{

		}
		public InvalidTypeException(string message) : base(message)
		{

		}
		public InvalidTypeException(string message, Exception innerException) : base(message, innerException)
		{

		}
	}
}
