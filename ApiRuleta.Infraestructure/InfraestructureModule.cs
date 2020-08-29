using Autofac;
using ApiRuleta.Core.Interfaces.Repositories;
using ApiRuleta.Infraestructure.Data.EntityFrameworkPostgreSQL;

namespace ApiRuleta.Infraestructure
{
    public class InfraestructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryWrapper>().As<IRepositoryWrapper>().InstancePerLifetimeScope();
        }
    }
}
