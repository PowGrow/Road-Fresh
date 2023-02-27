using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public GameOverSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.GameOver));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGameOver;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {

        }
    }
}
