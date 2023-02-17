using Entitas;
using UnityEngine;

public class PlayerMovementSystem : IExecuteSystem
{

    private Contexts _contexts;

    private IGroup<GameEntity> _group;

    public PlayerMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.VelocityInput,GameMatcher.RotationInput, GameMatcher.Player));
    }

    public void Execute()
    {
        foreach(var entity in _group)
        {
            var deltaRotation = Quaternion.Euler(new Vector3(0, _contexts.game.rotationInput.value, 0) * entity.rotationSpeed.value * Time.fixedDeltaTime);
            var deltaPosition = entity.rigidbody.value.transform.forward * _contexts.game.velocityInput.value.z * entity.speed.value * Time.fixedDeltaTime;

            entity.rigidbody.value.MoveRotation(entity.rigidbody.value.rotation * deltaRotation);
            entity.rigidbody.value.MovePosition(entity.rigidbody.value.position + deltaPosition);

            entity.ReplaceVelocity(entity.rigidbody.value.velocity);
            entity.ReplaceRotation(entity.rigidbody.value.rotation.eulerAngles);
            entity.ReplacePosition(entity.rigidbody.value.position);
        }
    }
}
