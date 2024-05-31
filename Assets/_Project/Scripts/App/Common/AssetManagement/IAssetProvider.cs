using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace App
{
    public interface IAssetProvider
    {
        public UniTask InitializeAsync();
        public UniTask<TAsset> LoadAsync<TAsset>(AssetReference assetReference) where TAsset : class;
        public UniTask<TAsset> LoadAsync<TAsset>(string key) where TAsset : class;
        public UniTask<SceneInstance> LoadSceneAsync(string sceneName, LoadSceneMode mode);
        public UniTask<List<string>> GetAssetsListAsync<TAsset>(string key);
        public UniTask<List<string>> GetAssetsListAsync(string key, Type type = null);
        public UniTask<TAsset[]> LoadAllAsync<TAsset>(List<string> keys) where TAsset : class;
        public UniTask WarmupAssetsAsync(string key);
        public UniTask ReleaseAssetsAsync(string label);
        public void Cleanup();
    }
}