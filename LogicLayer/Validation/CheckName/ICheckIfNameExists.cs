using System.Threading.Tasks;
using Models;

namespace LogicLayer.Validation.CheckName
{
	public interface ICheckIfNameExists
	{
		Task<bool> CheckName(CardModel model);
		Task<bool> CheckNameCharacters(CardModel model);
	}
}