using System.Collections.Generic;
using Entitas;
using UnityEngine;
using RoadFresh.Vehicle.Physics;

namespace RoadFresh.Vehicle
{
    public sealed class VehicleRidingSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        private SteeringWheel _steeringWheel;

        public VehicleRidingSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TryingToControlVehicle));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isRider && entity.hasInteractObject;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                if (entity.interactObject.value.isVehicle)
                    ChangeRiderState(!entity.isRiding, entity);
            }
        }

        public static void MoveVehicle(GameEntity entity,GameEntity vehicleEntity, Contexts contexts)
        {
            
            //var deltaForward = entity.rigidbody.value.transform.forward * contexts.game.velocityInput.value.z * vehicleEntity.speed.value;
            //var deltaAngle = new Vector3(0, 0, contexts.game.rotationInput.value) * vehicleEntity.speed.value * Time.fixedDeltaTime;

            //entity.rigidbody.value.AddForce(deltaForward);
            //entity.rigidbody.value.AddTorque(deltaAngle);

            //entity.ReplaceVelocity(entity.rigidbody.value.velocity);
            //entity.ReplacePosition(entity.rigidbody.value.position);
            //entity.ReplaceRotation(entity.rigidbody.value.rotation.eulerAngles);
        }

        private void ChangeRiderState(bool isMounting, GameEntity riderEntity)
        {
            riderEntity.isRiding = isMounting;
            var vehicleEntity = riderEntity.interactObject.value;
            vehicleEntity.rigidbodyUnderControl.value.isKinematic = !isMounting;
            if (isMounting)
            {
                riderEntity.rigidbodyUnderControl.value = vehicleEntity.rigidbodyUnderControl.value;
                _steeringWheel = new SteeringWheel(vehicleEntity, _contexts);
            }
            else
            { 
                riderEntity.rigidbodyUnderControl.value = riderEntity.riderRigidbody.value;
            }
            riderEntity.isTryingToControlVehicle = false;
        }
    }
}