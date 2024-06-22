using Models;

namespace LogicLayer.Validation
{
	public interface IIdValidation
	{
		bool CheckId(CardModel model);
		bool CheckIfIdExists(CardModel model);
	}
}