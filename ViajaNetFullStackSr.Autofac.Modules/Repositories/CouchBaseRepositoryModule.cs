using Autofac;
using ViajaNetFullStackSr.Domain.Interfaces.Repositories;
using ViajaNetFullStackSr.Infra;

namespace ViajaNetFullStackSr.Autofac.Modules.Repositories
{
    public class CouchBaseRepositoryModule : Module
    {
        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CouchBaseRepository>().As< ICouchBaseRepository > ();
        }

        #endregion
    }
}
