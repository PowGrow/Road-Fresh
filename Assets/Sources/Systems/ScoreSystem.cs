using Entitas;
using Entitas.Unity;
using System.Collections.Generic;

public class ScoreSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public ScoreSystem(Contexts contexts) : base(contexts.game)
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
            if (collisionSource.isPlayer)
            {
                var gameData = _contexts.game.gameData.value;
                gameData.Score += gameData.GlobalGameSpeed * gameData.ScorePerObstacle;
            }
        }
    }
}
