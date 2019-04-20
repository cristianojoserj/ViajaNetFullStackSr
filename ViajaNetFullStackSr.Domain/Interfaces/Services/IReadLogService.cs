using System.Collections.Generic;
using ViajaNetFullStackSr.DataComunication;

namespace ViajaNetFullStackSr.Domain.Interfaces.Services
{
    public interface IReadLogService
    {
        List<LogDTO> GetByFilter(string ip, string pageName);
    }
}
