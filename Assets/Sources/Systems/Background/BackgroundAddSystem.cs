using Entitas;
using System.Collections.Generic;
using UnityEngine;

public sealed class BackgroundAddSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public BackgroundAddSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.AddBackgroundCollision));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAddBackgroundCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var backgroundSetup = _contexts.game.backgroundSetup.value;
            var background = _contexts.game.CreateEntity();
            background.isBackground = true;
            background.AddPosition(backgroundSetup.AddPosition);
            background.AddResource(backgroundSetup.BackgroundPrefabs[Random.Range(0, backgroundSetup.BackgroundPrefabs.Count - 1)]);
        }
        foreach (var entity in entities)
        {
            entity.isDestroyed = true;
        }
    }
}
