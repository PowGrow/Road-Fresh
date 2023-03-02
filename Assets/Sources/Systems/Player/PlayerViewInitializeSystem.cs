using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace RoadFresh.View.Systems
{
    public class PlayerViewInitializeSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public PlayerViewInitializeSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.View));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var playerObject = entity.view.value;
                entity.AddRigidbody(playerObject.GetComponent<Rigidbody>());
                entity.AddUnityRigs(playerObject.GetComponent<UnityRigs>());
                entity.AddBeepAudioSource(CreateAudioSource(playerObject, _contexts.game.playerSetup.value.beepSound, false));
                entity.AddSlurpAudioSource(CreateAudioSource(playerObject, _contexts.game.playerSetup.value.teaSlurpSound, false));
                entity.AddEngineAudioSource(CreateAudioSource(playerObject, _contexts.game.playerSetup.value.engineSound, true));
                entity.engineAudioSource.value.volume = 0.5f;
                entity.engineAudioSource.value.Play();
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
