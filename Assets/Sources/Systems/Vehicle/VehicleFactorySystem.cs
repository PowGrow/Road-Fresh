using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace RoadFresh.Vehicle
{
    public sealed class VehicleFactorySystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public VehicleFactorySystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.VehicleToCreate));
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.isVehicle;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                CreateVehicleEntity(entity.vehicleToCreate.value, entity);
            }
        }

        private void CreateVehicleEntity(int vehicleIndex, GameEntity entity)
        {
            entity.isVehicle = true;
            entity.isInteractable = true;
            entity.isPhysic = true;
            entity.isAnimated = true;
            entity.AddVelocity(Vector3.zero);
            entity.AddPosition(entity.initialPoistion.value);
            entity.AddRotation(Vector3.zero);
            entity.AddResource(_contexts.game.vehiclePrefabs.value.Prefabs[vehicleIndex]);
            entity.RemoveVehicleToCreate();
        }
    }
}