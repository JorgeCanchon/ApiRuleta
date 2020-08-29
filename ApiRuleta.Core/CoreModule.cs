using ApiRuleta.Core.UseCases.Roulette;
using Autofac;

namespace ApiRuleta.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RouletteInteractor>().As<IRouletteInteractor>().SingleInstance();
        }
    }
}
