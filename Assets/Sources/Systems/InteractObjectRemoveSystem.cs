using Entitas;
using System;
using UnityEngine;

public class InteractObjectRemoveSystem : InteractObjectBaseSystem
{
    protected Contexts _contexts;

    public InteractObjectRemoveSystem(Contexts contexts) : base(contexts)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ExitCollision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasExitCollision;
    }

    protected override GameObject GetSourceCollisionObjects(GameEntity entity)
    {
        return entity.exitCollision.collisionSourceObject;
    }

    protected override GameObject GetCollisionObject(GameEntity entity)
    {
        return entity.exitCollision.collisionObject;
    }

    protected override void DoAction(GameEntity entity,GameEntity entityToInteract)
    {
        entity.RemoveInteractObject();
    }
}
