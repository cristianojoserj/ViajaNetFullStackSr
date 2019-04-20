using Autofac;
using ViajaNetFullStackSr.Domain.Interfaces.Repositories;
using ViajaNetFullStackSr.Infra;

namespace ViajaNetFullStackSr.Autofac.Modules.Repositories
{
    public class RabbitMQRepositoryModule : Module
    {
        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RabbitMQRepository>().As<IRabbitMQRepository>();
        }

        #endregion
    }
}
