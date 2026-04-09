using System;
using _Game.Scripts.Services.CameraService;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Game.Scripts.Testings
{
    public class TestScript : MonoBehaviour
    {
        private void Update()
        {
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                G.GetGlobal<CameraService>().Shake(1, .3f, ScreenShakeType.Radial);
            }
        }
    }
}