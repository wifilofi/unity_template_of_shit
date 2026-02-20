using ServiceLocator.Scripts;
using Tools.ServiceLocator.Scripts;
using UnityEngine;

namespace ServiceLocator
{
    [AddComponentMenu("ServiceLocator/ServiceLocator Scene")]
    public class ServiceLocatorScene : Bootstrapper
    {
        [SerializeField] private BaseInstaller _installer;
        protected override void Bootstrap()
        {
            Container.ConfigureForScene();
            _installer?.Install();
        }
    }
}