using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Utility;
using Models;

namespace LogicLayer.ModelConversions
{
	public class FrontEndModelToDBModel
	{
		public static DBCardModel ConvertFrontEndModelToCardModel(FrontEndModel model)
		{
			DBCardModel cardModel = new DBCardModel();
			
			cardModel.id = model.id;
			cardModel.name = model.name;
			cardModel.type = TypeConversions.TypeToIntConversion(cardModel, model);
			cardModel.attack = model.attack;
			cardModel.defense = model.defense;

			return cardModel;
		}
	}
}
