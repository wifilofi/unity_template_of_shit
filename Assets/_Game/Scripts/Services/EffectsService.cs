using _Game.Scripts.Prefabs;
using _Game.Scripts.Utils.Prefabs;
using Constants;
using Lean.Pool;
using PrefabTags;
using Tools.CMSTags;
using UnityEngine;

namespace _Game.Scripts.Services
{
    public class EffectsService
    {
        public enum Particle
        {
            Explosion
        }

        public EffectsService()
        {
            var model = CMS.Get<CMSEntity>(Models.Particles);
            _particles = model.Get<ParticlePrefabTag>().value;
        }

        private readonly ParticlePrefabContainer _particles;

        public void SpawnParticle(Particle particle, Vector3 position)
        {
            //bb
           LeanPool.Spawn(_particles.Get(particle), position, Quaternion.identity);
        }
    }
}