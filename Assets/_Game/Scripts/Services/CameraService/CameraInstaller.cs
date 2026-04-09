using UnityEngine;

namespace _Game.Scripts.Services.CameraService
{
    [RequireComponent(typeof(Camera))]
    public class CameraInstaller : MonoBehaviour
    {
        private CameraService _cameraService;

        private void Awake()
        {
           // _cameraService = G.GetGlobal<CameraService>();
           // _cameraService.SetNewCamera(GetComponent<Camera>());
        }
    }
}