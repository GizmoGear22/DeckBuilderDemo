using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DelegateUtilities
{
	public class ValidationDelegates
	{
		public delegate bool DelegateForValidation(CardModel model);
		public delegate Task ValidationMessageDelegate(string message);
	}
}
