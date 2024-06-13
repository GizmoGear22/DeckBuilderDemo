using System.Threading.Tasks;
using Models;

namespace LogicLayer.APIPostLogic
{
	public interface IAPIPostHandlers
	{
		Task APIPostHandler(CardModel model);
	}
}