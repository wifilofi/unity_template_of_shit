using System;
using _Game.Services;
using Tools.ServiceLocator.Scripts;
using UnityEngine;

namespace _Game.Scripts
{
    public class ExampleGameplayScript : MonoBehaviour
    {
        private ExampleGameplayService _exampleGameplayService;
        
        private void Awake()
        {
            _exampleGameplayService = G.GetLocal<ExampleGameplayService>();
        }

        public void SpawnCube()
        {
            _exampleGameplayService.SpawnCube();
        }
    }
}