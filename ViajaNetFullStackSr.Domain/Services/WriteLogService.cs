using ViajaNetFullStackSr.DataComunication;
using ViajaNetFullStackSr.Domain.Interfaces.Repositories;
using ViajaNetFullStackSr.Domain.Interfaces.Services;

namespace ViajaNetFullStackSr.Domain.Services
{
    public class WriteLogService : IWriteLogService
    {
        #region Fields

        private readonly IRabbitMQRepository _repository;

        #endregion

        #region Builder

        public WriteLogService(IRabbitMQRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public void Insert(LogDTO log)
        {
            Log logResult = new Log()
            {
                Id = log.Id,
                Ip = log.Ip,
                BrowserName = log.BrowserName,
                PageName = log.PageName,
                Parameters = log.Parameters
            };

            _repository.Insert(logResult);
        }

        #endregion
    }
}
