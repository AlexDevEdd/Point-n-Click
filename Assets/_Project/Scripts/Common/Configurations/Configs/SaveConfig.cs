using System;

namespace Common
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