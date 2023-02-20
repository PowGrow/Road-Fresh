using Entitas;
using System;
using System.Collections.Generic;

namespace RoadFresh.View
{
    public sealed class RiderViewSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        private const float CONSTRAINT_POSITION_WEIGHT = 0.8f;

        public RiderViewSystem(Contexts contexts) : base(contexts.game)
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
                    ChangeRiderViewPosition(!entity.isRiding, entity, entity.interactObject.value);
            }
        }

        public void ChangeRiderViewPosition(bool isTryingToRide, GameEntity riderEntity, GameEntity vehicleEntity)
        {
            var rider = riderEntity.view.value;
            var vehicle = riderEntity.interactObject.value.view.value;

            if (isTryingToRide)
            {
                ChangeRiderPhysics(riderEntity, isTryingToRide);
                rider.transform.parent = vehicle.transform;
                rider.transform.localPosition = vehicleEntity.mountPosition.value.transform.localPosition;
                rider.transform.localRotation = vehicleEntity.mountPosition.value.transform.localRotation;
            }
            else
            {
                rider.transform.localPosition = vehicleEntity.unmountPosition.value.localPosition;
                rider.transform.localRotation = vehicleEntity.unmountPosition.value.localRotation;
                rider.transform.parent = null;
                ChangeRiderPhysics(riderEntity, isTryingToRide);
            }
            var weight = CONSTRAINT_POSITION_WEIGHT * Convert.ToInt32(isTryingToRide);
            riderEntity.riderLeftArmPosition.constraint.data.targetPositionWeight = weight;
            riderEntity.riderRightArmPosition.constraint.data.targetPositionWeight = weight;
            riderEntity.riderLeftLegPosition.constraint.data.targetPositionWeight = weight;
            riderEntity.riderRightLegPosition.constraint.data.targetPositionWeight = weight;

            riderEntity.riderLeftArmPosition.constraint.data.targetRotationWeight = weight;
            riderEntity.riderRightArmPosition.constraint.data.targetRotationWeight = weight;
            riderEntity.riderLeftLegPosition.constraint.data.targetRotationWeight = weight;
            riderEntity.riderRightLegPosition.constraint.data.targetRotationWeight = weight;

            riderEntity.riderLeftArmPosition.value.localRotation = vehicleEntity.leftArmPosition.value.localRotation;
            riderEntity.riderRightArmPosition.value.localRotation = vehicleEntity.rightArmPosition.value.localRotation;
            riderEntity.riderLeftLegPosition.value.localRotation = vehicleEntity.leftLegPosition.value.localRotation;
            riderEntity.riderRightLegPosition.value.localRotation = vehicleEntity.rightLegPosition.value.localRotation;

            riderEntity.riderLeftArmPosition.value.position = vehicleEntity.leftArmPosition.value.position;
            riderEntity.riderRightArmPosition.value.position = vehicleEntity.rightArmPosition.value.position;
            riderEntity.riderLeftLegPosition.value.position = vehicleEntity.leftLegPosition.value.position;
            riderEntity.riderRightLegPosition.value.position = vehicleEntity.rightLegPosition.value.position;
        }

        private void ChangeRiderPhysics(GameEntity riderEntity, bool isMounting)
        {
            riderEntity.riderRigidbody.value.isKinematic = isMounting;
            riderEntity.riderCollider.value.enabled = !isMounting;
        }
    }
}
