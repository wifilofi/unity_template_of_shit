using UnityEngine;

namespace Tools.ServiceLocator.Scripts
{
    [DefaultExecutionOrder(-700)]
    public class GameBootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            G.InitGlobalServices();
            DontDestroyOnLoad(this);
        }
    }
}