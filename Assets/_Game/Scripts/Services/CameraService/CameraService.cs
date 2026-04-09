using System.Collections;
using Gilzoide.UpdateManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Scripts.Services.CameraService
{
    public enum ScreenShakeType
    {
        Radial,
        Horizontal,
        Vertical
    }

    public class CameraService : AManagedBehaviour
    {
        [field: SerializeField] public Camera curCamera { get; private set; }

        public struct Settings
        {
            public float maxScreenShakeAmp;
        }

        private static readonly AnimationCurve _defaultFadeCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
        private Coroutine _shakeCoroutine;

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

        public void Shake(float amplitude, float duration, ScreenShakeType type = ScreenShakeType.Radial, AnimationCurve fadeCurve = null)
        {
            if (curCamera == null) return;
            if (_shakeCoroutine != null) StopCoroutine(_shakeCoroutine);
            _shakeCoroutine = StartCoroutine(ShakeRoutine(amplitude, duration, type, fadeCurve ?? _defaultFadeCurve));
        }

        private IEnumerator ShakeRoutine(float amplitude, float duration, ScreenShakeType type, AnimationCurve fadeCurve)
        {
            var camTransform = curCamera.transform;
            var originalLocalPos = camTransform.localPosition;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float t = elapsed / duration;
                float currentAmp = amplitude * fadeCurve.Evaluate(t);

                Vector3 offset = type switch
                {
                    ScreenShakeType.Horizontal => new Vector3(Random.Range(-1f, 1f) * currentAmp, 0f, 0f),
                    ScreenShakeType.Vertical   => new Vector3(0f, Random.Range(-1f, 1f) * currentAmp, 0f),
                    _                          => new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized * currentAmp
                };

                camTransform.localPosition = originalLocalPos + offset;
                elapsed += Time.deltaTime;
                yield return null;
            }

            camTransform.localPosition = originalLocalPos;
            _shakeCoroutine = null;
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