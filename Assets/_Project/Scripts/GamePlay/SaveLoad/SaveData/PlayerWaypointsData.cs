using System;
using System.Collections.Generic;
using Utils;

namespace GamePlay
{
    [Serializable]
    public class PlayerWaypointsData
    {
        public List<SerializableVector3> WayPoints = new();
    }
}