using System;
using _Game.Scripts.Views;
using Constants;
using Plugins.generic_serializable_dictionary_1._0._2.Runtime;
using ServiceTags;
using UnityEngine;

namespace _Game.Scripts.Services.CursorService
{
    public enum CursorType
    {
        Pointer,
        Hover,
        Press,
        Grab,
        GrabPress
    }

    public class CursorService
    {
        [Serializable]
        public struct CursorEntry
        {
            public Sprite sprite;
            public Vector2 hotspot;
        }

        [Serializable]
        public struct Settings
        {
            public CursorView prefab;
            public GenericDictionary<CursorType, CursorEntry> cursors;
        }

        private readonly Settings _settings;
        private CursorView _view;
        private CursorType _currentType = CursorType.Pointer;

        public CursorService()
        {
            _settings = CMS.Get<CMSEntity>(Models.CursorService)
                .Get<CursorServiceTag>().value;

            if (_settings.prefab != null)
            {
                _view = UnityEngine.Object.Instantiate(_settings.prefab);
                UnityEngine.Object.DontDestroyOnLoad(_view.gameObject);
                _view.Init(this);
                ApplyCursor(_currentType);
            }
        }

        public void BindView(CursorView view)
        {
            _view = view;
            ApplyCursor(_currentType);
        }

        public void SetCursor(CursorType type)
        {
            _currentType = type;
            if (_view != null)
                ApplyCursor(type);
        }

        public void ResetCursor() => SetCursor(CursorType.Pointer);

        private void ApplyCursor(CursorType type)
        {
            if (_settings.cursors == null || !_settings.cursors.TryGetValue(type, out var entry))
                return;

            _view.SetSprite(entry.sprite, entry.hotspot);
        }
    }
}
