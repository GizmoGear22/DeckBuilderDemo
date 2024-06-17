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
		public static string IntToTypeConversion (CardModel model, FrontEndModel newModel)
		{
			switch (model.type)
			{
				case CardType.Machine:
					newModel.type = "Machine";
					break;
				case CardType.Pyro:
					newModel.type = "Pyro";
					break;
				case CardType.Alchemy:
					newModel.type = "Alchemy";
					break;
				case CardType.Tesla:
					newModel.type = "Tesla";
					break;
				case CardType.Bio:
					newModel.type = "Bio";
					break;
			}
			return newModel.type;
		}
	}
}
