using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public class ObstacleCounterSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private Contexts _contexts;

    public ObstacleCounterSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.game.gameData.value.ObstaclePassed = 0;
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
            if (!_contexts.game.isGamePaused)
            {
                var collisionSource = (GameEntity)entity.obstaclePassedCollision.collisionObject.GetEntityLink().entity;
                if (collisionSource.isPlayer)
                {
                    _contexts.game.gameData.value.ObstaclePassed += 1;
                    _contexts.game.gameUI.value.GameOverlay.UpdateObstaclesCount(_contexts.game.gameData.value.ObstaclePassed);
                }
            }
        }
        foreach (var entity in entities)
        {
            entity.isDestroyed = true;
        }
    }
}
