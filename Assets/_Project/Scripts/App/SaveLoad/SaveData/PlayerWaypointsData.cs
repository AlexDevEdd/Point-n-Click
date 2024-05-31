using System;
using System.Collections.Generic;
using Utils.Serialize;

namespace App
{
    [Serializable]
    public class PlayerWaypointsData
    {
        public List<SerializableVector3> WayPoints = new();
    }
}