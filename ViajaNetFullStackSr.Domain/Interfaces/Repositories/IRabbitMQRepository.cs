namespace ViajaNetFullStackSr.Domain.Interfaces.Repositories
{
    public interface IRabbitMQRepository
    {
        void Insert(Log entity);
    }
}
