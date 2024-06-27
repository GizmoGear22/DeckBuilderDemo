using System.Threading.Tasks;
using Models;

namespace LogicLayer.Validation.CheckName
{
	public interface ICheckIfNameExists
	{
		Task<bool> CheckName(CardModel model);
		bool CheckNameCharacters(CardModel model);
	}
}