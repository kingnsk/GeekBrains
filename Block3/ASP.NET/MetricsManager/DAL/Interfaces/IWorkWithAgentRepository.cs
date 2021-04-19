using MetricsManager.Models;
using Core.Interfaces;

namespace MetricsManager.DAL
{
    // маркировочный интерфейс
    // необходим, чтобы проверить работу репозитория на тесте-заглушке
    public interface IWorkWithAgentRepository : IRepository<Agent>
    {

    }
}
