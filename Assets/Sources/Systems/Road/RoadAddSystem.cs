using Entitas;
using System.Collections.Generic;
using UnityEngine;

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
            background.AddResource(roadSetup.roadPrefabs[Random.Range(0, roadSetup.roadPrefabs.Count - 1)]);
        }
        foreach (var entity in entities)
        {
            entity.isDestroyed = true;
        }
    }
}
