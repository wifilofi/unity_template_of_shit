using System;
using Gilzoide.UpdateManager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Game.Scripts.Services
{
    public class InputService : IUpdatable
    {
        public event Action Confirmed;

        public InputService()
        {
            _c = new Controls();
            _c.Enable();
            this.RegisterInManager();
        }

        public void ManagedUpdate()
        {
            if (_c.PC.Confirm.WasPressedThisFrame())
                Confirmed?.Invoke();
        }
        
        public Vector2 MousePosition => Mouse.current.position.ReadValue();
        public bool IsLMBPressed => Mouse.current.leftButton.isPressed;
        public bool IsLMBDown => Mouse.current.leftButton.wasPressedThisFrame;
        public bool IsRMBPressed => Mouse.current.rightButton.isPressed;
        public Vector2 ScrollDelta => Mouse.current?.scroll.ReadValue() ?? Vector2.zero;

        public bool ConfirmWasPressedThisFrame => _c.PC.Confirm.WasPressedThisFrame();
        public bool IsConfirmPressedThisFrame => _c.PC.Confirm.IsPressed();
        
        private Controls _c;
    }
}