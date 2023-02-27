using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class ObstacleCounterSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public ObstacleCounterSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.ObstaclePassedCollision));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasObstaclePassedCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var collisionSource = (GameEntity)entity.obstaclePassedCollision.collisionObject.GetEntityLink().entity;
            if(collisionSource.isPlayer)
            {
                _contexts.game.gameData.value.ObstaclePassed += 1;
                Debug.Log("Obstacle passed: " + _contexts.game.gameData.value.ObstaclePassed);
            }
        }
        foreach (var entity in entities)
        {
            entity.isDestroyed = true;
        }
    }
}
