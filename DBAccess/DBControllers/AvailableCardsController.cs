using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DBAccess.DBControllers
{
	public class AvailableCardsController
	{
		private readonly IConfiguration _configuration;
		public AvailableCardsController(IConfiguration configuration) 
		{
			_configuration = configuration;
		}
		public string CnnVal()
		{
			return _configuration.GetConnectionString("DBAccessHandler");
		}
	}
}
