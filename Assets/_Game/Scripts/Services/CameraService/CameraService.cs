using Gilzoide.UpdateManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Scripts.Services.CameraService
{
    public class CameraService : AManagedBehaviour
    {
        [field: SerializeField] public Camera curCamera { get; private set; }

        public struct Settings
        {
            public float maxScreenShakeAmp;
        }

        protected override void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected override void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // TryFindCamsOnScene();
        }

        public void SetNewCamera(Camera camera)
        {
            if (curCamera != null)
            {
                Destroy(curCamera.gameObject);
            }

            curCamera = camera;
        }

        private void TryFindCamsOnScene()
        {
            Camera[] allCameras = FindObjectsByType<Camera>(FindObjectsSortMode.None);
            Camera foundCam = null;

            foreach (Camera cam in allCameras)
            {
                if (!cam.transform.IsChildOf(transform))
                {
                    foundCam = cam;
                    break;
                }
            }

            if (foundCam != null)
            {
                Debug.Log(foundCam.name);
                Destroy(curCamera.gameObject);
                curCamera = foundCam;
            }
        }

        public void OnDeconstruct()
        {
        }
    }
}