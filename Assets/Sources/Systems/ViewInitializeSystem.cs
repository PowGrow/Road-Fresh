using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace RoadFresh.View
{
    public sealed class ViewInitializeSystem : ReactiveSystem<GameEntity>
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
                if(entity.hasPosition)
                    gameObject.transform.position = entity.position.value;
                if (entity.isPlayer)
                {
                    entity.AddRigidbody(gameObject.GetComponent<Rigidbody>());
                    entity.AddUnityRigs(gameObject.GetComponent<UnityRigs>());
                    var beepAudioSource = gameObject.AddComponent<AudioSource>();
                    beepAudioSource.Pause();
                    beepAudioSource.loop = true;
                    beepAudioSource.clip = _contexts.game.playerSetup.value.beepSound;
                    entity.AddBeepAudioSource(beepAudioSource);
                }
                if (entity.isAnimated)
                    entity.AddAnimator(gameObject.GetComponent<Animator>());
                if (entity.isUi)
                {
                    _contexts.game.SetGameUI(gameObject.GetComponent<GameUI>());
                    var test = _contexts.game.gameUI.value;
                }
            }
        }
    }
}
