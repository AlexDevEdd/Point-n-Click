using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace App
{
    public sealed class PrefabFactoryAsync<TComponent> : IFactory<string, UniTask<TComponent>>
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public PrefabFactoryAsync(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public async UniTask<TComponent> Create(string assetKey)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(assetKey);
            var newObject = _instantiator.InstantiatePrefab(prefab);
            return newObject.GetComponent<TComponent>();
        }
    }
}