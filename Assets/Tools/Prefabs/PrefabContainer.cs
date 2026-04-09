using System;
using Plugins.generic_serializable_dictionary_1._0._2.Runtime;
using UnityEngine;

namespace _Game.Scripts.Utils.Prefabs
{
    [Serializable]
    public abstract class PrefabContainer<TValue, TKey>
    {
        [SerializeField] private GenericDictionary<TKey, TValue> Prefabs = new GenericDictionary<TKey, TValue>();


        public TValue Get(TKey key)
        {
            return Prefabs[key];
            /*foreach (var prefab in Prefabs)
            {
                if (key.Equals(prefab.Key))
                {
                    return prefab.Value;
                }
            }

            throw new Exception(String.Format($"Prefab for {key} was not found"));*/
        }

        [Serializable]
        private struct Prefab
        {
            public TValue Value;
            public TKey Key;

            public Prefab(TKey Key, TValue Value)
            {
                this.Key = Key;
                this.Value = Value;
            }
        }
    }
}