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
		public delegate void DelegateForValidation(CardModel model);
		public delegate void ValidationMessageDelegate(string message);
	}
}
