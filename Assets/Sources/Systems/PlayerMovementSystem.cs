using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class PlayerMovementSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public PlayerMovementSystem(Contexts contexts): base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.VelocityInput, GameMatcher.Velocity,GameMatcher.RotationInput,GameMatcher.Rotation));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPlayer;
    }

    protected override void Execute(List<GameEntity> entites)
    {
        foreach(var entity in entites)
        {
            entity.ReplaceVelocity(_contexts.game.velocityInput.value);
            entity.ReplaceRotation(new Vector3(0, _contexts.game.rotationInput.value, 0));
        }
    }


}
