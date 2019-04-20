using System.Collections.Generic;

namespace ViajaNetFullStackSr.Domain.Interfaces.Repositories
{
    public interface ICouchBaseRepository
    {
        List<Log> GetByFilter(string ip, string pageName);
    }
}
