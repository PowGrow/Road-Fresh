using Entitas;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

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
            isStrafing(entity);
            entity.animator.value.SetFloat("VelocityZ", entity.velocityInput.value.z);
            entity.animator.value.SetFloat("VelocityX", entity.velocityInput.value.x);
            entity.animator.value.SetFloat("RotationY", entity.rotationInput.value);
        }
    }

    private void isStrafing(GameEntity entity)
    {
        if (entity.velocityInput.value.x != 0)
        {
            entity.animator.value.SetBool("isStrafing", true);
        }
        else
        {
            entity.animator.value.SetBool("isStrafing", false);
        }
    }
}
