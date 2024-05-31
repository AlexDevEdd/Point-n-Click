using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay
{
    [CreateAssetMenu(fileName = "GameBalance", menuName = "Installers/GameBalance")]
    public sealed class GameBalance : ScriptableObject
    {
        [Title("Loading window configuration", TitleAlignment = TitleAlignments.Centered)] [PropertySpace]
        [Space(10)]
        public LoadingConfig LoadingConfig;
        
        [Title("Player configuration", TitleAlignment = TitleAlignments.Centered)] [PropertySpace]
        [Space(10)]
        public PlayerConfig PlayerConfig;
        
        [Title("Path configuration", TitleAlignment = TitleAlignments.Centered)] [PropertySpace]
        [Space(10)]
        public PathConfig PathConfig;
        
        [Title("Location configuration", TitleAlignment = TitleAlignments.Centered)] [PropertySpace]
        [Space(10)]
        public LocationConfig LocationConfig;
        
        [Title("Save configuration", TitleAlignment = TitleAlignments.Centered)] [PropertySpace]
        [Space(10)]
        public SaveConfig SaveConfig;
        
        
    }
}