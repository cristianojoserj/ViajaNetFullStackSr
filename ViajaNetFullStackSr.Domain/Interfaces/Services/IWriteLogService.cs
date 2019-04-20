using ViajaNetFullStackSr.DataComunication;

namespace ViajaNetFullStackSr.Domain.Interfaces.Services
{
    public interface IWriteLogService
    {
        void Insert(LogDTO log);
    }
}
