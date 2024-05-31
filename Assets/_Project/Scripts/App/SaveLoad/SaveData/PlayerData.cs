using System;
using Utils;

namespace App.SaveData
{
    [Serializable]
    public struct PlayerData
    {
        public SerializableVector3 Position;
        public SerializableVector3 Rotation;
    }
}