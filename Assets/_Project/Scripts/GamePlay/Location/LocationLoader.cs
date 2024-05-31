using App;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class LocationLoader : IInitializable
    {
        private readonly IAssetProvider _assetProvider;
        private readonly GameBalance _balance;
        private readonly Transform _container;

        public LocationLoader(IAssetProvider assetProvider, GameBalance balance, Transform container)
        {
            _assetProvider = assetProvider;
            _balance = balance;
            _container = container;
        }

        public void Initialize()
        {
            LoadLocation().Forget();
        }

        private async UniTask LoadLocation()
        {
            var asset =  await _assetProvider.LoadAsync<GameObject>(_balance.LocationConfig.LevelAsset);
            Object.Instantiate(asset, _container);
        }
    }
}