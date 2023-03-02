using UnityEngine;
using Entitas;

namespace RoadFresh.Controls.Systems
{
    public sealed class PlayerBeepSystem : IInitializeSystem, IExecuteSystem
    {

        private Contexts _contexts;

        private IGroup<GameEntity> _group;

        public PlayerBeepSystem(Contexts contexts)
        {
            _contexts = contexts;
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
        }

        public void Initialize()
        {
            _contexts.game.SetBeep(false);
        }

        public void Execute()
        {
            foreach (var entity in _group)
            {
                if (!_contexts.game.isGamePaused)
                {
                    if (_contexts.game.beep.value)
                    {
                        if (!entity.beepAudioSource.value.isPlaying)
                            entity.beepAudioSource.value.Play();
                        Ray frontRay = new Ray(entity.rigidbody.value.transform.position, Vector3.forward);
                        if (Physics.SphereCast(frontRay, 3, out RaycastHit raycastHit, 3, 1 << 8))
                        {
                            var deerObject = raycastHit.collider.gameObject;
                            var deerAnimator = deerObject.GetComponent<Animator>();
                            deerAnimator.SetTrigger("Run");
                        }
                    }
                    else
                    {
                        if (entity.beepAudioSource.value.isPlaying)
                            entity.beepAudioSource.value.Stop();
                    }
                }
            }
        }
    }
}
