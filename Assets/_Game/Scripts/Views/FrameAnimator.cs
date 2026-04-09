using System;
using Gilzoide.UpdateManager;
using UnityEngine;

namespace _Game.Scripts.Views
{
    public class FrameAnimator : AManagedBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite[] _frames;
        [SerializeField] private float _fps = 12f;
        [SerializeField] private bool _loop;

        private float _timer;
        private int _currentFrame;

        private void Awake()
        {
            if (_frames == null || _frames.Length == 0)
            {
                Debug.LogError("FrameAnimator needs frame array");
            }
        }

        protected override void OnEnable()
        {
            _currentFrame = 0;
            _spriteRenderer.sprite = null;
            _timer = 0;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= 1f / _fps)
            {
                _timer -= 1f / _fps;
                _currentFrame = (_currentFrame + 1) % _frames.Length;
                _spriteRenderer.sprite = _frames[_currentFrame];
            }
        }
    }
}