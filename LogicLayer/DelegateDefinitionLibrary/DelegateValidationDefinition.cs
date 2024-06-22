﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicLayer.DelegateDefinitionLibrary
{

	public class DelegateValidationDefinition
	{
		public delegate void ValidationDelegate(CardModel model);

		public delegate void ValidationMessageDelegate(string message);
	}
}
