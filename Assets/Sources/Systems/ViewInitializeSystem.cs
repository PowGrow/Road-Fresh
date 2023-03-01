using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using static UnityEngine.EventSystems.EventTrigger;

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
                if (entity.hasPosition)
                {
                    gameObject.transform.position = entity.position.value;
                }
                if (entity.isPlayer)
                {
                    entity.AddRigidbody(gameObject.GetComponent<Rigidbody>());
                    entity.AddUnityRigs(gameObject.GetComponent<UnityRigs>());
                    entity.AddBeepAudioSource(CreateAudioSource(gameObject, _contexts.game.playerSetup.value.beepSound,false));
                    entity.AddSlurpAudioSource(CreateAudioSource(gameObject, _contexts.game.playerSetup.value.teaSlurpSound, false));
                    entity.AddEngineAudioSource(CreateAudioSource(gameObject, _contexts.game.playerSetup.value.engineSound, true));
                    entity.engineAudioSource.value.volume = 0.5f;
                    entity.engineAudioSource.value.Play();
                }
                if (entity.isAnimated)
                {
                    entity.AddAnimator(gameObject.GetComponent<Animator>());
                }
                if (entity.isUi)
                {
                    _contexts.game.SetGameUI(gameObject.GetComponent<GameUI>());
                }
                if(entity.isPlayer || entity.isBackground || entity.isRoad)
                {
                    entity.isDestroyOnLoad = true;
                }
            }
        }

        private AudioSource CreateAudioSource(GameObject gameObject, AudioClip clip, bool loop)
        {
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.Pause();
            audioSource.loop = loop;
            audioSource.clip = clip;
            return audioSource;
        }
    }
}
