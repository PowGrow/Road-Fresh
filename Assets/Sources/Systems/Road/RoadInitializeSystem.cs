using Entitas;
using RoadFresh.Stats;
using System.Security.Principal;
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
            if(!Statistic.IsThereAreSaveData())
                roadEntity.AddResource(roadSetup.roadPrefabs[0]);
            else
                roadEntity.AddResource(roadSetup.roadPrefabs[1]);
        }
    }
}
