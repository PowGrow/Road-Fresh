using Entitas;
using Entitas.Unity;
using RoadFresh.View.UI;
using System.Collections.Generic;
using UnityEngine;

namespace RoadFresh.View.Systems
{
    public class ViewInitializeSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public ViewInitializeSystem(Contexts contexts) : base(contexts.game)
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
                var gameObject = Object.Instantiate(entity.resource.value);
                entity.AddView(gameObject);
                gameObject.Link(entity);
                if (entity.hasPosition) 
                    gameObject.transform.position = entity.position.value;
                if (entity.isAnimated) 
                    entity.AddAnimator(gameObject.GetComponent<Animator>());
                if (entity.isUi) 
                    _contexts.game.SetGameUI(gameObject.GetComponent<GameUI>());
            }
        }
    }
}
