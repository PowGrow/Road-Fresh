using Entitas;
using UnityEngine;

public class PlayerAnimationSystem : IExecuteSystem
{
    private Contexts _contexts;

    private IGroup<GameEntity> _group;

    public PlayerAnimationSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Animator,GameMatcher.Player));
    }

    public void Execute()
    {
        foreach(GameEntity entity in _group)
        {
            entity.animator.value.SetFloat("VelocityZ", entity.velocityInput.value.z);
            entity.animator.value.SetFloat("RotationY", entity.rotationInput.value);
        }
    }
}
