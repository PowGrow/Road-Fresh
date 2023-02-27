using Entitas;
using Entitas.Unity;
using System.Collections.Generic;

public class RoadDestroySystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public RoadDestroySystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.DestroyRoadCollision));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDestroyRoadCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameEntity entityToDestroy = (GameEntity)entity.destroyRoadCollision.collisionObject.GetEntityLink().entity;
            entityToDestroy.isDestroyed = true;
        }

        foreach (var entity in entities)
        {
           entity.isDestroyed = true;
        }
    }
}
