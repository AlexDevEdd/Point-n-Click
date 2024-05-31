using App.Core;
using App.SaveData;
using GamePlay;
using JetBrains.Annotations;

namespace App.SaveLoaders
{
    [UsedImplicitly]
    public sealed class PlayerWayPointsSaveLoader : SaveLoader<PlayerWaypointsData, MovementPath>
    {
        public PlayerWayPointsSaveLoader(GameRepository repository, MovementPath system)
            : base(repository, system) { }

        protected override PlayerWaypointsData ConvertToData(MovementPath system)
        {
            var waypointsData = new PlayerWaypointsData();
            var path = system.Path;

            foreach (var position in path)
            {
                waypointsData.WayPoints.Add(position);
            }

            return waypointsData;
        }

        protected override void SetUpData(PlayerWaypointsData waypointsData, MovementPath system)
        {
            if (waypointsData.WayPoints.Count == 0) return;

            var path = system.Path;

            foreach (var position in waypointsData.WayPoints)
            {
                path.Enqueue(position);
            }

            system.PointAddedCommand.Execute();
        }
    }
}