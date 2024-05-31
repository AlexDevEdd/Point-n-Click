namespace App.Core
{
    public interface ISaveSystem
    {
        public void Save();
        public void Load();
        public void RemoveSaves();
    }
}