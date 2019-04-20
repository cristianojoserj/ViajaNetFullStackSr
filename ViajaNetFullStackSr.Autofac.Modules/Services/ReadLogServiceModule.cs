using Autofac;
using ViajaNetFullStackSr.Domain.Interfaces.Services;
using ViajaNetFullStackSr.Domain.Services;

namespace ViajaNetFullStackSr.Autofac.Modules.Services
{
    public class ReadLogServiceModule : Module
    {
        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReadLogService>().As<IReadLogService>();
        }

        #endregion
    }
}
