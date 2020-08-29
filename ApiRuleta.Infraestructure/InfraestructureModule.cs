using ApiRuleta.Infraestructure.Data.EntityFrameworkPostgreSQL;
using ApiRuleta.Core.Interfaces.Repositories;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

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
