using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Validation
{
	public class DelegateValidationMessage
	{
		public static Task ValidationMessage(string message)
		{
			Console.WriteLine(message);
			throw new Exception(message);
		}
	}
}
