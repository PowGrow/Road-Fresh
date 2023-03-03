using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace RoadFresh.GameLoop.Systems
{
    public sealed class RoadAddSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public RoadAddSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.AddRoadCollision));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAddRoadCollision;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var roadSetup = _contexts.game.roadSetup.value;
                var background = _contexts.game.CreateEntity();
                background.isRoad = true;
                background.AddPosition(roadSetup.AddPosition);
                var randomRoadIndex = Random.Range(0, roadSetup.roadPrefabs.Count);
                background.AddResource(roadSetup.roadPrefabs[randomRoadIndex]);
            }
            foreach (var entity in entities)
            {
                entity.isDestroyed = true;
            }
        }
    }
}
