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
            if (entity.isRiding)
            {
                VehicleRidingSystem.MoveVehicle(entity,entity.interactObject.value, _contexts);
            }
            else
            {
                var deltaRotation = Quaternion.Euler(new Vector3(0, _contexts.game.rotationInput.value, 0) * entity.rotationSpeed.value * Time.fixedDeltaTime);
                var deltaForward = entity.rigidbody.value.transform.forward * _contexts.game.velocityInput.value.z;
                var deltaRight = entity.rigidbody.value.transform.right * _contexts.game.velocityInput.value.x;
                var deltaPosition = (Vector3.Normalize(deltaRight + deltaForward)) * entity.speed.value * Time.fixedDeltaTime;

                entity.rigidbody.value.MoveRotation(entity.rigidbody.value.rotation * deltaRotation);
                entity.rigidbody.value.MovePosition(entity.rigidbody.value.position + deltaPosition);

                entity.ReplaceVelocity(entity.rigidbody.value.velocity);
                entity.ReplaceRotation(entity.rigidbody.value.rotation.eulerAngles);
                entity.ReplacePosition(entity.rigidbody.value.position);
            }
        }
    }
}
