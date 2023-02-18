using Entitas;
using UnityEngine;

public class InteractObjectAddSystem : InteractObjectBaseSystem
{
    protected Contexts _contexts;

    public InteractObjectAddSystem(Contexts contexts) : base(contexts)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }

    protected override GameObject GetSourceCollisionObjects(GameEntity entity)
    {
        return entity.collision.collisionSourceObject;
    }

    protected override GameObject GetCollisionObject(GameEntity entity)
    {
        return entity.collision.collisionObject;
    }

    protected override void DoAction(GameEntity entity, GameEntity entityToInteract)
    {
        entity.AddInteractObject(entityToInteract);
    }
}
