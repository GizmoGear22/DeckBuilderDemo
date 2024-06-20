using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicLayer.Validation
{
	public class IdValidation
	{
		public bool CheckId(CardModel model, string message) 
		{
			if (model.id < 0)
			{
				message = "Can't have ID Number less than or equal to 0";
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool CheckIfIdExists(CardModel model, string message)
		{
			throw new NotImplementedException();
		}


	}
}
