using _Game.Scripts.Services;
using _Game.Scripts.Services.CameraService;
using _Game.Services;
using ServiceLocator.Scripts;
using Tools.ServiceLocator.Scripts;
using UnityEngine;

namespace _Game.Installers
{
    public class GameplayInstaller : BaseInstaller
    {
        [SerializeField] private Camera _mainCamera;
        protected override void AfterInstall()
        {
            G.GetGlobal<CameraService>().SetNewCamera(_mainCamera);
            G.RegLocal(new ExampleGameplayService());
        }
    }
}