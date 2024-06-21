using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicLayer.Utility
{
	public class TypeConversions
	{
		public static string IntToTypeConversion (CardType model)
		{
			switch (model)
			{
				case CardType.Machine:
					return CardType.Machine.ToString();
				case CardType.Pyro:
					return "Pyro";
				case CardType.Alchemy:
					return "Alchemy";
				case CardType.Tesla:
					return "Tesla";
				case CardType.Bio:
					return "Bio";
				default:
					return ("Unknown");
			}
		}
	}
}
