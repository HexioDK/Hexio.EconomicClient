using Autofac;

namespace Hexio.EconomicClient
{
    public class EconomicModule : Module
    {
        private EconomicSettings Settings { get; set; }

        public EconomicModule(EconomicSettings settings)
        {
            Settings = settings;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => Settings);
            builder.Register(c => EconomicClientFactory.Execute(Settings.AppSecretToken, Settings.AgreementGrantToken)).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}