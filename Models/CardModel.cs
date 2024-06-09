﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class CardModel
	{
		public int id { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public int cost { get; set; }
		public int attack {  get; set; }
		public int defense { get; set; }
	}
}
