using _Game.Services;
using ServiceLocator.Scripts;
using Tools.ServiceLocator.Scripts;

namespace _Game.Installers
{
    public class ExampleGameplayInstaller : BaseInstaller
    {
        protected override void AfterInstall()
        {
            G.RegLocal(new ExampleGameplayService());
        }
    }
}