using Entitas;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraInitializationSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public CameraInitializationSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.MainCamera));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMainCamera;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var rotatingUIObjects = Object.FindObjectsOfType<RotatingUI>();
        foreach (var entity in entities)
        {
            foreach (RotatingUI obj in rotatingUIObjects)
            {
                obj.gameObject.AddComponent<UIRotator>();
            }
        }

    }
}
