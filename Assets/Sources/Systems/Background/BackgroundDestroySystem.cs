using Entitas;
using Entitas.Unity;
using System.Collections.Generic;

public class BackgroundDestroySystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public BackgroundDestroySystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.DestroyBackgroundCollision));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDestroyBackgroundCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameEntity entityToDestroy = (GameEntity)entity.destroyBackgroundCollision.collisionObject.GetEntityLink().entity;
            entityToDestroy.isDestroyed = true;
        }

        foreach (var entity in entities)
        {
           entity.isDestroyed = true;
        }
    }
}
