using Autofac;
using ViajaNetFullStackSr.Domain.Interfaces.Services;
using ViajaNetFullStackSr.Domain.Services;

namespace ViajaNetFullStackSr.Autofac.Modules.Services
{
    public class WriteLogServiceModule : Module
    {
        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WriteLogService>().As<IWriteLogService>();
        }

        #endregion
    }
}
