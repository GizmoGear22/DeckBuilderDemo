using System.Threading.Tasks;
using Models;

namespace LogicLayer.Validation
{
	public interface IIdValidation
	{
		Task<(bool, string)> CheckId(CardModel model);
		Task<(bool, string)> CheckIfIdExists(CardModel model);
	}
}