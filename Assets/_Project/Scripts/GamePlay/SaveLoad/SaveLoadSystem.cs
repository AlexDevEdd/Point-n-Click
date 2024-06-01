using System.Collections.Generic;
using App;
using JetBrains.Annotations;
using Zenject;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class SaveLoadSystem : ISaveSystem, IInitializable
    {
        private readonly GameRepository _repository;
        private readonly IEnumerable<ISaveLoader> _loaders;
        
        public SaveLoadSystem(GameRepository repository, IEnumerable<ISaveLoader> loaders)
        {
            _repository = repository;
            _loaders = loaders;
        }
        
        public void Initialize()
        {
            Load();
        }

        public void Save()
        {
            foreach (var loader in _loaders) 
                loader.SaveGame();
            
            _repository.SaveState();
        }

        public async void Load()
        {
           await _repository.LoadState();
           
           foreach (var loader in _loaders) 
               loader.LoadGame();
        }
        
        public void RemoveSaves()
        {
            _repository.RemoveSaves();
        }
    }
}