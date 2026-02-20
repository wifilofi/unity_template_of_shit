using System;
using _Game.Services;
using ServiceLocator.Scripts;
using Tools.ServiceLocator.Scripts;
using UnityEngine;

namespace _Game.Scripts
{
    public class ExampleMenuScript : MonoBehaviour
    {
        private bool _isLocked;
        
        private ExampleMouseService  _mouseService;
        private void Awake()
        {
           _mouseService = G.GetGlobal<ExampleMouseService>();
           _mouseService.SetCusorLock(CursorLockMode.None);
        }

        public void ChangeState()
        {
            _isLocked = !_isLocked;
            _mouseService.SetCusorLock(_isLocked ?  CursorLockMode.Confined : CursorLockMode.None);
        }
    }
}