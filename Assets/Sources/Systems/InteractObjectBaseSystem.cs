using System;
using System.Collections.Generic;
using Entitas;
using Unity.VisualScripting;
using UnityEngine;

public class InteractObjectBaseSystem : ReactiveSystem<GameEntity>
{
    protected Contexts _contexts;

    public InteractObjectBaseSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.ExitCollision,GameMatcher.Collision));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasExitCollision || entity.hasCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var collisionSourceObject = GetSourceCollisionObjects(entity);
            var collisionObject = GetCollisionObject(entity);
            var collisionSourceEntity = _contexts.game.GetEntitiesWithView(collisionSourceObject).SingleEntity();
            var collisionEntity = _contexts.game.GetEntitiesWithView(collisionObject).SingleEntity();
            if (collisionSourceEntity != null)
                DoAction(collisionEntity,collisionSourceEntity);
        }

        for (int i = entities.Count - 1; i >= 0; i--)
        {
            entities[i].isDestroy = true;
        }
    }

    protected virtual GameObject GetSourceCollisionObjects(GameEntity entity)
    {
        throw new NotImplementedException("Base system method GetSourceCollisionObjects must be overrided");
    }

    protected virtual GameObject GetCollisionObject(GameEntity entity)
    {
        throw new NotImplementedException("Base system method GetCollisionObject must be overrided");
    }

    protected virtual void DoAction(GameEntity entity,GameEntity entityToInteract)
    {
        throw new NotImplementedException("Base system method DoAction must be overrided");
    }
}
