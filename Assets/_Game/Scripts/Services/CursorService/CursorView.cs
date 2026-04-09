using _Game.Scripts.Services;
using _Game.Scripts.Services.CameraService;
using _Game.Scripts.Services.CursorService;
using Gilzoide.UpdateManager;
using UnityEngine;

namespace _Game.Scripts.Views
{
    public class CursorView : AManagedBehaviour, IUpdatable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _distance = 10f;
        [SerializeField] private float _pixelSize = 32f;
        [SerializeField] private Vector2 _hotspot = Vector2.zero;

        private Camera _camera;
        private InputService _inputService;
        private CursorService _cursorService;
        private bool _hasMovedWhileRMB;
        private Vector2 _lastMousePosition;
        private CursorType _activeCursor;

        private void Awake()
        {
            Cursor.visible = false;
            _inputService = G.GetGlobal<InputService>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Cursor.visible = false;
        }

        public void Init(CursorService cursorService)
        {
            _cursorService = cursorService;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Cursor.visible = true;
        }

        public void SetSprite(Sprite sprite, Vector2 hotspot)
        {
            _spriteRenderer.sprite = sprite;
            _hotspot = hotspot;
            RecalculateScale();
        }

        public void ManagedUpdate()
        {
            if (_camera == null)
                _camera = G.GetGlobal<CameraService>().curCamera;
            if (_camera == null) return;

            Vector2 mousePos = _inputService.MousePosition;
            bool moving = (mousePos - _lastMousePosition).sqrMagnitude > 0f;
            _lastMousePosition = mousePos;

            bool rmb = _inputService.IsRMBPressed;
            bool lmb = _inputService.IsLMBPressed;

            if (!rmb)
                _hasMovedWhileRMB = false;
            else if (moving)
                _hasMovedWhileRMB = true;

            CursorType desired;
            if (rmb)
                desired = _hasMovedWhileRMB ? CursorType.GrabPress : CursorType.Grab;
            else
                desired = lmb ? CursorType.Press : CursorType.Pointer;

            if (desired != _activeCursor)
            {
                _activeCursor = desired;
                _cursorService.SetCursor(desired);
            }

            Vector3 mouse = _inputService.MousePosition;
            mouse.z = _distance;
            Vector3 worldPos = _camera.ScreenToWorldPoint(mouse);

            // offset by hotspot in world units
            if (_spriteRenderer.sprite != null)
            {
                float worldPerPixel = WorldUnitsPerPixel();
                worldPos -= new Vector3(_hotspot.x * worldPerPixel, _hotspot.y * worldPerPixel, 0f);
            }

            transform.position = worldPos;
        }

        private void RecalculateScale()
        {
            if (_spriteRenderer.sprite == null || _camera == null) return;

            float worldPerPixel = WorldUnitsPerPixel();
            float desiredWorldSize = _pixelSize * worldPerPixel;
            float spriteWorldSize = _spriteRenderer.sprite.rect.width / _spriteRenderer.sprite.pixelsPerUnit;
            float scale = desiredWorldSize / spriteWorldSize;
            transform.localScale = Vector3.one * scale;
        }

        private float WorldUnitsPerPixel()
        {
            float worldHeight = 2f * _distance * Mathf.Tan(_camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
            return worldHeight / Screen.height;
        }
    }
}
