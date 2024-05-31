using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    public interface ISceneLoader
    {
        public UniTask LoadAsync(string nextScene, LoadSceneMode mode);
    }
}