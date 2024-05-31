using System;
using System.Collections.Generic;
using Utils;

namespace App.SaveData
{
    [Serializable]
    public class PlayerWaypointsData
    {
        public List<SerializableVector3> WayPoints = new();
    }
}