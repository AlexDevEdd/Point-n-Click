using App.Core;

namespace App.SaveLoaders
{
    public abstract class SaveLoader<TData, TSystem> : ISaveLoader
    {
        private readonly GameRepository _repository;
        private readonly TSystem _system;
        
        protected SaveLoader(GameRepository repository, TSystem system)
        {
            _repository = repository;
            _system = system;
        }
        
        public void SaveGame()
        {
            var data = ConvertToData(_system);
            _repository.SetData(data);
        }

        public void LoadGame()
        {
            if (_repository.TryGetData(out TData data))
                SetUpData(data, _system);
        }

        protected abstract TData ConvertToData(TSystem system);
        protected abstract void SetUpData(TData data, TSystem system);

        protected virtual void SetUpDefaultData(TSystem system) { }
    }
}