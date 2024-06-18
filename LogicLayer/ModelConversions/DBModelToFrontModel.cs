using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Utility;
using Models;

namespace LogicLayer.ModelConversions
{
	public class DBModelToFrontModel
	{
		public static FrontEndModel ConvertDBModeltoFrontEndModel(CardModel model)
		{
			FrontEndModel frontEndModel = new FrontEndModel();

			frontEndModel.id = model.id;
			frontEndModel.name = model.name;
			frontEndModel.type = TypeConversions.IntToTypeConversion(model, frontEndModel);
			frontEndModel.cost = model.cost;
			frontEndModel.attack = model.attack;
			frontEndModel.defense = model.defense;

			return frontEndModel;
		}
	}
}
