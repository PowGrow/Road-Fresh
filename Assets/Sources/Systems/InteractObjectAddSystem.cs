using Entitas;
using UnityEngine;

namespace RoadFresh.Interactions
{
    public sealed class InteractObjectAddSystem : InteractObjectBaseSystem
    {
        protected Contexts _contexts;

        private const float SHOW = 1f;

        public InteractObjectAddSystem(Contexts contexts) : base(contexts)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Collision);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCollision;
        }

        protected override GameObject GetSourceCollisionObjects(GameEntity entity)
        {
            return entity.collision.collisionSourceObject;
        }

        protected override GameObject GetCollisionObject(GameEntity entity)
        {
            return entity.collision.collisionObject;
        }

        protected override void DoAction(GameEntity entity, GameEntity entityToInteract)
        {
            if (!entity.hasInteractObject)
            {
                entity.AddInteractObject(entityToInteract);
                if (entity.isPlayer)
                    SetInteractionTextAlphaValue(entityToInteract, SHOW);
            }
        }
    }
}
