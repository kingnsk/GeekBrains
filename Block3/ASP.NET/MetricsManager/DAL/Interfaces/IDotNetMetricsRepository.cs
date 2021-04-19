using Core.Interfaces;
using MetricsManager.Models;

namespace MetricsManager.DAL
{
    // маркировочный интерфейс
    // необходим, чтобы проверить работу репозитория на тесте-заглушке
    public interface IDotNetMetricsRepository : IRepository<DotNetMetric>
    {

    }
}
