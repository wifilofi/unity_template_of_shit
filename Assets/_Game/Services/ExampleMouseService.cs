using UnityEngine;

namespace _Game.Services
{
    public class ExampleMouseService
    {
        public void SetCusorLock(CursorLockMode lockmode)
        {
            Cursor.lockState =  lockmode;
            Debug.Log($"CURSOR LOCK STATE: {lockmode}");
        }
    }
}