using Entitas;
using RoadFresh.Interactions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoadFresh.Vehicle
{
    public sealed class VehicleRidingSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        private const float CONSTRAINT_POSITION_WEIGHT = 0.8f;

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
            return entity.isPlayer && entity.interactObject != null && entity.interactObject.value.isVehicle;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                MountEntityOnVehicle(entity);
            }
        }

        public static void MoveVehicle(GameEntity entity,GameEntity vehicleEntity, Contexts contexts)
        {
            //var deltaRotation = Quaternion.Euler(new Vector3(0, contexts.game.rotationInput.value, 0) * entity.rotationSpeed.value * Time.fixedDeltaTime);
            //var deltaForward = entity.rigidbody.value.transform.forward * contexts.game.velocityInput.value.z;
            //var deltaRight = entity.rigidbody.value.transform.right * contexts.game.velocityInput.value.x;
            //var deltaPosition = (Vector3.Normalize(deltaRight + deltaForward)) * entity.speed.value * Time.fixedDeltaTime;

            //entity.rigidbody.value.MoveRotation(entity.rigidbody.value.rotation * deltaRotation);
            //entity.rigidbody.value.MovePosition(entity.rigidbody.value.position + deltaPosition);

            //entity.ReplaceVelocity(entity.rigidbody.value.velocity);
            //entity.ReplaceRotation(entity.rigidbody.value.rotation.eulerAngles);
            //entity.ReplacePosition(entity.rigidbody.value.position);

            var deltaForward = entity.rigidbody.value.transform.forward * contexts.game.velocityInput.value.z * vehicleEntity.speed.value;
            //var deltaPosition = deltaForward * vehicleEntity.speed.value * Time.fixedDeltaTime;

            var deltaAngle = new Vector3(0, 0, contexts.game.rotationInput.value) * vehicleEntity.speed.value * Time.fixedDeltaTime;

            entity.rigidbody.value.AddForce(deltaForward);
            entity.rigidbody.value.AddTorque(deltaAngle);

            entity.ReplaceVelocity(entity.rigidbody.value.velocity);
            entity.ReplacePosition(entity.rigidbody.value.position);
            entity.ReplaceRotation(entity.rigidbody.value.rotation.eulerAngles);
        }

        private void MountEntityOnVehicle(GameEntity riderEntity)
        {
            riderEntity.isTryingToControlVehicle = false;
            if (riderEntity.isRiding)
                ChangeRiderState(false, riderEntity);
            else
                ChangeRiderState(true, riderEntity);
        }

        private void ChangeRiderState(bool isMounting, GameEntity riderEntity)
        {
            riderEntity.isRiding = isMounting;
            var rider = riderEntity.view.value;
            var vehicleEntity = riderEntity.interactObject.value;
            var vehicle = riderEntity.interactObject.value.view.value;
            if (isMounting)
            {
                rider.transform.parent = vehicle.transform;
                ChangeRiderPhysics(rider, riderEntity, isMounting);
                rider.transform.localPosition = vehicleEntity.mountPosition.value.transform.localPosition;
                rider.transform.localRotation = vehicleEntity.mountPosition.value.transform.localRotation;
                ChangeRiderConstraints(isMounting, riderEntity, vehicleEntity);
                riderEntity.rigidbody.value = vehicleEntity.view.value.gameObject.GetComponent<Rigidbody>();
                InteractObjectBaseSystem.TryToHideInteractionTextOnRiding(riderEntity);
            }
            else
            {
                ChangeRiderConstraints(isMounting, riderEntity, vehicleEntity);
                rider.transform.localPosition = vehicleEntity.unmountPosition.value.localPosition;
                rider.transform.localRotation = vehicleEntity.unmountPosition.value.localRotation;
                rider.transform.parent = null;
                riderEntity.rigidbody.value = riderEntity.view.value.gameObject.GetComponent<Rigidbody>();
                InteractObjectBaseSystem.TryToShowInteractionTextAfterRiding(riderEntity);
                ChangeRiderPhysics(rider, riderEntity, isMounting);
            }
        }

        private void ChangeRiderPhysics(GameObject rider, GameEntity riderEntity, bool isMounting)
        {
            riderEntity.rigidbody.value.isKinematic = isMounting;
            rider.GetComponent<CapsuleCollider>().enabled = !isMounting;
        }

        public void ChangeRiderConstraints(bool isMounting,GameEntity riderEntity,GameEntity vehicleEntity)
        {
            riderEntity.riderLeftArmPosition.value.position = vehicleEntity.leftArmPosition.value.position;
            riderEntity.riderRightArmPosition.value.position = vehicleEntity.rightArmPosition.value.position;
            riderEntity.riderLeftLegPosition.value.position = vehicleEntity.leftLegPosition.value.position;
            riderEntity.riderRightLegPosition.value.position = vehicleEntity.rightLegPosition.value.position;

            riderEntity.riderLeftArmPosition.value.localRotation = vehicleEntity.leftArmPosition.value.localRotation;
            riderEntity.riderRightArmPosition.value.localRotation = vehicleEntity.rightArmPosition.value.localRotation;
            riderEntity.riderLeftLegPosition.value.localRotation = vehicleEntity.leftLegPosition.value.localRotation;
            riderEntity.riderRightLegPosition.value.localRotation = vehicleEntity.rightLegPosition.value.localRotation;

            var weight = CONSTRAINT_POSITION_WEIGHT * Convert.ToInt32(isMounting);
            riderEntity.riderLeftArmPosition.constraint.data.targetPositionWeight = weight;
            riderEntity.riderRightArmPosition.constraint.data.targetPositionWeight = weight;
            riderEntity.riderLeftLegPosition.constraint.data.targetPositionWeight = weight;
            riderEntity.riderRightLegPosition.constraint.data.targetPositionWeight = weight;

            riderEntity.riderLeftArmPosition.constraint.data.targetRotationWeight = weight;
            riderEntity.riderRightArmPosition.constraint.data.targetRotationWeight = weight;
            riderEntity.riderLeftLegPosition.constraint.data.targetRotationWeight = weight;
            riderEntity.riderRightLegPosition.constraint.data.targetRotationWeight = weight;
        }
    }
}
