using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace RoadFresh.View
{

    public sealed class InstantiateViewSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public InstantiateViewSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Resource));
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var gameObject = Object.Instantiate(entity.resource.ViewPrefab);
                entity.AddView(gameObject);
                gameObject.Link(entity);
                if (entity.hasInitialPoistion)
                    gameObject.transform.position = entity.position.value;
                if (entity.isPhysic)
                    PhysicsView.AddComponents(entity, gameObject);
                if (entity.isAnimated)
                    AnimatedView.AddComponents(entity, gameObject);
                if (entity.isPlayer)
                    PlayerView.AddComponents(entity, gameObject);
                if (entity.isInteractable)
                    InteractibleView.AddComponents(entity, gameObject);
                if (entity.isVehicle)
                    VehicleView.AddComponents(entity, gameObject);
                if (entity.isRider)
                    RiderView.AddComponents(entity, gameObject);

            }
        }
    }
}