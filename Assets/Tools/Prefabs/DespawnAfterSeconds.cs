using Cysharp.Threading.Tasks;
using Lean.Pool;
using UnityEngine;

namespace Tools.Prefabs
{
    public class DespawnAfterSeconds : MonoBehaviour
    {
        [SerializeField] private float _waitTime = 1f;

        private void OnEnable()
        {
            StartTimer();
        }

        private async void StartTimer()
        {
            await UniTask.WaitForSeconds(_waitTime);
            LeanPool.Despawn(this);
        }
    }
}