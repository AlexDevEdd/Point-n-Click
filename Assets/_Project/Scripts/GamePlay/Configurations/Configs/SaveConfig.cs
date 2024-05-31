using System;

namespace GamePlay
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