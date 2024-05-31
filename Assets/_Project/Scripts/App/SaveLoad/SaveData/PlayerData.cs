using System;
using Utils.Serialize;

namespace App
{
    [Serializable]
    public struct PlayerData
    {
        public SerializableVector3 Position;
        public SerializableVector3 Rotation;
    }
}