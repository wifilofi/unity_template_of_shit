using UnityEngine;

namespace Tools.ServiceLocator.Scripts
{
    public abstract class BaseInstaller : MonoBehaviour
    {
        public void Install()
        {
            AfterInstall();
        }

        protected abstract void AfterInstall();
    }
}