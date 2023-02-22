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
                entity.steeringWheel.value.RotateSteeringWheel(entity.rotationInput.value);
            }
        }
    }
}
