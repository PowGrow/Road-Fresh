using Entitas;
using UnityEngine;
using RoadFresh.Vehicle;

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
            if(!entity.isRiding)
            {
                var deltaRotation = Quaternion.Euler(new Vector3(0, _contexts.game.rotationInput.value, 0) * entity.rotationSpeed.value * Time.fixedDeltaTime);
                var deltaForward = entity.rigidbodyUnderControl.value.transform.forward * _contexts.game.velocityInput.value.z;
                var deltaRight = entity.rigidbodyUnderControl.value.transform.right * _contexts.game.velocityInput.value.x;
                var deltaPosition = (Vector3.Normalize(deltaRight + deltaForward)) * entity.speed.value * Time.fixedDeltaTime;

                entity.rigidbodyUnderControl.value.MoveRotation(entity.rigidbodyUnderControl.value.rotation * deltaRotation);
                entity.rigidbodyUnderControl.value.MovePosition(entity.rigidbodyUnderControl.value.position + deltaPosition);

                entity.ReplaceVelocity(entity.rigidbodyUnderControl.value.velocity);
                entity.ReplaceRotation(entity.rigidbodyUnderControl.value.rotation.eulerAngles);
                entity.ReplacePosition(entity.rigidbodyUnderControl.value.position);
            }
        }
    }
}
