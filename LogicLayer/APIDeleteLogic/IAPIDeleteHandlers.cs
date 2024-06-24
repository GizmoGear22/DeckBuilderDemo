using System.Threading.Tasks;
using Models;

namespace LogicLayer.APIDeleteLogic
{
	public interface IAPIDeleteHandlers
	{
		Task DeleteCard(CardModel model);
	}
}