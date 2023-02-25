using Entitas;
using UnityEngine;

namespace RoadFresh.Vehicle.Physics
{
    public class VehicleMovmentSystem : IExecuteSystem
    {

        private Contexts _contexts;

        private IGroup<GameEntity> _group;

        public VehicleMovmentSystem(Contexts contexts)
        {
            _contexts = contexts;
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.VelocityInput, GameMatcher.RotationInput, GameMatcher.Riding));
        }

        public void Execute()
        {
            foreach (var entity in _group)
            {
                var vehicleEntity = entity.interactObject.value;
                vehicleEntity.steeringWheel.value.RotateSteeringWheel(entity.rotationInput.value);
                vehicleEntity.engine.value.ControllEngine(entity.velocityInput.value.z);

                if(vehicleEntity.gear.value != Gear.N)
                    vehicleEntity.vehicleViewData.RearWheelCollider.motorTorque = ((((float)vehicleEntity.gear.value / 10) + Mathf.Sign((int)vehicleEntity.gear.value)) * vehicleEntity.engine.value.RPM) / 1000;

            }
        }
    }
}
