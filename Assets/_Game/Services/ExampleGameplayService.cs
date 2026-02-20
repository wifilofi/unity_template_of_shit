using System;
using Constants;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace _Game.Services
{
    public class ExampleGameplayService
    {
        [Serializable]
        public struct Settings
        {
            public GameObject cubePrefab;
        }

        public ExampleGameplayService()
        {
            _settings = CMS.Get<CMSEntity>(Models.ExampleGameplayServiceSettings)
                .Get<ServiceTags.ExampleGameplayServiceTag>().value;
        }

        private readonly Settings _settings;

        public void SpawnCube()
        {
            //Debug.Log("spawned cube");
            var randPosition = new Vector3(Random.Range(-2, 2f), Random.Range(4f, 6f), 0);
            Object.Instantiate(_settings.cubePrefab, randPosition, Random.rotation);
        }
    }
}