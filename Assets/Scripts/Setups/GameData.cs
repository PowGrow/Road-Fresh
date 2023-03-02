using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace RoadFresh.Initialize.Setups
{
    [CreateAssetMenu]
    [Game, Unique]
    public class GameData : ScriptableObject
    {
        public float DeltaSpeed;
        public float DeltaInterval;
        public float ScorePerObstacle;
        public float GlobalGameSpeed;
        public float Score;
        public float ObstaclePassed;
    }
}
