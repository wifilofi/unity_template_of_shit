using Tools.ServiceLocator.Scripts;
using UnityEngine;

namespace ServiceLocator.Scripts
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ServiceLocator))]
    public abstract class Bootstrapper : MonoBehaviour
    {
        ServiceLocator container;
        internal ServiceLocator Container => container.OrNull() ?? (container = GetComponent<ServiceLocator>());

        bool hasBeenBootstrapped;

        void Awake() => BootstrapOnDemand();

        public void BootstrapOnDemand()
        {
            if (hasBeenBootstrapped) return;
            hasBeenBootstrapped = true;
            
            var bootstrapper = FindObjectOfType<GameBootstrapper>();

            if (bootstrapper == null)
            {
                Instantiate(Resources.Load<GameBootstrapper>("GameBootstrapper"));
            }
            Bootstrap();
        }

        protected abstract void Bootstrap();
    }
}