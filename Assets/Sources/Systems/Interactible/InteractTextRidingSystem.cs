using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace RoadFresh.Interactions
{
    public sealed class InteractTextRidingSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public InteractTextRidingSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TryingToControlVehicle));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.hasInteractObject;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                var isTryingToRide = !entity.isRiding;
                if (isTryingToRide)
                    SetInteractionTextAlphaValue(entity.interactObject.value, Constants.HIDE_TEXT);
                else
                    SetInteractionTextAlphaValue(entity.interactObject.value, Constants.SHOW_TEXT);
            }
        }

        private void SetInteractionTextAlphaValue(GameEntity entityToInteract, float value)
        {
            var entityColor = entityToInteract.interactText.value.color;
            entityToInteract.interactText.value.color = new Color(entityColor.r, entityColor.g, entityColor.b, value);
        }
    }
}
