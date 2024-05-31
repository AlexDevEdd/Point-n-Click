using App;
using App.Core;
using UnityEngine;
using Zenject;

namespace GamePlay
{
    public sealed class SaveComponent : MonoBehaviour
    {
        private ISaveSystem _saveSystem;

        [Inject]
        public void Construct(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        private void OnApplicationQuit()
        {
            _saveSystem.Save();
        }
    }
}