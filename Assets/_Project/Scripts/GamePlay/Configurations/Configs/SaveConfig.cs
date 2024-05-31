using System;

namespace GamePlay.Configs
{
    [Serializable]
    public struct SaveConfig
    {
        public SaveType Type;
        
        public enum SaveType
        {
            Local,
            Cloud
        }
    }
}