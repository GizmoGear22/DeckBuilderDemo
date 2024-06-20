using System.Threading.Tasks;
using Models;

namespace LogicLayer.APIPostLogic
{
	public interface IAPIPostHandler
	{
		Task PostNewCard(CardModel model);
	}
}