using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    private const string SCOOTER_CRUSH_TRIGGER = "Crush";
    private const string CHARACTER_FALLEN_TRIGGER = "Fallen";

    public PlayerFallSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Fell));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPlayer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            _contexts.game.isGamePaused = true;
            entity.unityRigs.value.RigBuilder.enabled = false;
            entity.unityRigs.value.UnityRigsTransform.gameObject.SetActive(false);
            entity.animator.value.SetTrigger(SCOOTER_CRUSH_TRIGGER);
            entity.unityRigs.value.CharacterAnimator.SetTrigger(CHARACTER_FALLEN_TRIGGER);
            _contexts.game.isGameOver = true;
        }
    }
}
