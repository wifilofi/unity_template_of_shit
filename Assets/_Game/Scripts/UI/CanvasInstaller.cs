using _Game.Scripts.Services.CameraService;
using Gilzoide.UpdateManager;
using UnityEngine;

namespace _Game.Scripts.UI
{
    public class CanvasInstaller : AManagedBehaviour
    {
        [SerializeField] private Canvas _canvas;
        private CameraService _cameraService;

        private void Start()
        {
            _cameraService = G.GetGlobal<CameraService>();
            if (_cameraService.curCamera != null)
            {
                _canvas.worldCamera = _cameraService.curCamera;
            }
        }
    }
}