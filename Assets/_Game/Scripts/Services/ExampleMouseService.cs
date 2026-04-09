using UnityEngine;

namespace _Game.Services
{
    public class ExampleMouseService
    {
        private int _i;
        public void SetCusorLock(CursorLockMode lockmode)
        {
            _i++;
            Cursor.lockState =  lockmode;
            Debug.Log($"CURSOR LOCK STATE: {lockmode} {_i}");
        }
    }
}