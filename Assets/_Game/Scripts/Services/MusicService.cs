using System;
using Plugins.generic_serializable_dictionary_1._0._2.Runtime;
using UnityEngine;

namespace _Game.Scripts.Services
{
    public enum MusicTrack { None, MainMenu, Gameplay }

    public class MusicService
    {
        [Serializable]
        public struct Settings
        {
            public GenericDictionary<MusicTrack, AudioClip> tracks;
            [Range(0f, 1f)] public float volume;
        }

        private readonly Settings _settings;
        private readonly AudioSource _audioSource;
        private MusicTrack _currentTrack = MusicTrack.None;

        public MusicService()
        {
            _settings = CMS.Get<CMSEntity>(Constants.Models.MusicService)
                .Get<ServiceTags.MusicServiceTag>().value;

            var go = new GameObject("Music");
            UnityEngine.Object.DontDestroyOnLoad(go);
            _audioSource = go.AddComponent<AudioSource>();
            _audioSource.loop = true;
            _audioSource.volume = _settings.volume;
            _audioSource.playOnAwake = false;
        }

        public void PlayTrack(MusicTrack track)
        {
            if (track == _currentTrack) return;
            _currentTrack = track;

            if (track == MusicTrack.None)
            {
                _audioSource.Stop();
                return;
            }

            if (!_settings.tracks.TryGetValue(track, out var clip)) return;

            _audioSource.clip = clip;
            _audioSource.Play();
        }

        public void OnDeconstruct()
        {
            if (_audioSource != null)
                UnityEngine.Object.Destroy(_audioSource.gameObject);
        }
    }
}
