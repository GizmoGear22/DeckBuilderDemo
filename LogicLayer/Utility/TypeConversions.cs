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
		public static string IntToTypeConversion (DBCardModel cardModel, FrontEndModel frontEndModel)
		{
			switch (cardModel.type)
			{
				case CardType.Machine:
					frontEndModel.type = "Machine";
					break;
				case CardType.Pyro:
					frontEndModel.type = "Pyro";
					break;
				case CardType.Alchemy:
					frontEndModel.type = "Alchemy";
					break;
				case CardType.Tesla:
					frontEndModel.type = "Tesla";
					break;
				case CardType.Bio:
					frontEndModel.type = "Bio";
					break;
			}
			return frontEndModel.type;
		}

		public static CardType TypeToIntConversion(DBCardModel cardModel, FrontEndModel frontEndModel)
		{
			switch (frontEndModel.type)
			{
				case "Machine":
					return cardModel.type = CardType.Machine;
				case "Pyro":
					return cardModel.type = CardType.Pyro;
				case "Alchemy":
					return cardModel.type = CardType.Alchemy;
				case "Tesla":
					return cardModel.type = CardType.Tesla;
				case "Bio":
					return cardModel.type = CardType.Bio;
			}
			return cardModel.type;
		}
	}
}
