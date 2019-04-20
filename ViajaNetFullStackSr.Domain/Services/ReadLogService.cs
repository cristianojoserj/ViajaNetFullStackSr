using System.Collections.Generic;
using ViajaNetFullStackSr.DataComunication;
using ViajaNetFullStackSr.Domain.Interfaces.Repositories;
using ViajaNetFullStackSr.Domain.Interfaces.Services;

namespace ViajaNetFullStackSr.Domain.Services
{
    public class ReadLogService : IReadLogService
    {
        #region Fields

        private readonly ICouchBaseRepository _repository;

        #endregion

        #region Builder

        public ReadLogService(ICouchBaseRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public List<LogDTO> GetByFilter(string ip, string pageName)
        {
            var log = _repository.GetByFilter(ip, pageName);
            var logResult = new List<LogDTO>();

            foreach (var item in log)
            {
                logResult.Add(new LogDTO()
                {
                    Id = item.Id,
                    Ip = item.Ip,
                    BrowserName = item.BrowserName,
                    PageName = item.PageName,
                    Parameters = item.Parameters
                });
            }
            return logResult;
        }

        #endregion
    }
}
