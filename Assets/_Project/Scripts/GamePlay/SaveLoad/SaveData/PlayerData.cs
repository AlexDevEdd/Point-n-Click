using System;
using Utils;

namespace GamePlay
{
    [Serializable]
    public struct PlayerData
    {
        public SerializableVector3 Position;
        public SerializableVector3 Rotation;
    }
}