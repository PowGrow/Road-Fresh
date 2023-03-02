using Entitas;
using UnityEngine;

namespace RoadFresh.Initialize.Systems
{
    public class RoadInitializeSystem : IInitializeSystem
    {
        private Contexts _contexts;

        public RoadInitializeSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            var roadSetup = _contexts.game.roadSetup.value;
            var roadEntity = _contexts.game.CreateEntity();
            roadEntity.isRoad = true;
            roadEntity.AddPosition(roadSetup.InitializePosition);
            roadEntity.AddResource(roadSetup.roadPrefabs[Random.Range(0, roadSetup.roadPrefabs.Count - 1)]);
        }
    }
}
