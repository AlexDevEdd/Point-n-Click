using System.Threading.Tasks;
using App;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class SceneLoader : ISceneLoader
    {
        private readonly IAssetProvider _assetProvider;
        private string _currentSceneName;

        public SceneLoader(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public async UniTask LoadAsync(string nextScene, LoadSceneMode mode)
        {
            if (_currentSceneName == nextScene)
                await Task.CompletedTask;
            
            await _assetProvider.LoadSceneAsync(nextScene, mode);
        }
    }
}