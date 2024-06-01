using App;
using JetBrains.Annotations;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class PlayerSaveLoader : SaveLoader<PlayerData, AgentMovement>
    {
        public PlayerSaveLoader(GameRepository repository, AgentMovement system)
            : base(repository, system) { }
        
        protected override PlayerData ConvertToData(AgentMovement system)
        {
            var playerData = new PlayerData
            {
                Position = system.Position,
                Rotation = system.Rotation
            };
            return playerData;
        }

        protected override void SetUpData(PlayerData data, AgentMovement system)
        {
            system.Warp(data.Position, data.Rotation);
        }
    }
}