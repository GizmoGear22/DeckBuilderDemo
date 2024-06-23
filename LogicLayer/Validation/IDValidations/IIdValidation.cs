using System.Threading.Tasks;
using Models;

namespace LogicLayer.Validation
{
	public interface IIdValidation
	{
		bool CheckId(CardModel model);
		Task<bool> CheckIfIdExists(CardModel model);
	}
}