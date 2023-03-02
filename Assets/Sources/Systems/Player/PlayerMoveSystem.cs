using Entitas;
using UnityEngine;

namespace RoadFresh.Controls.Systems
{
    public class PlayerMoveSystem : IExecuteSystem
    {

        private Contexts _contexts;

        private IGroup<GameEntity> _group;

        public PlayerMoveSystem(Contexts contexts)
        {
            _contexts = contexts;
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.StrafeInput, GameMatcher.Player));
        }

        public void Execute()
        {
            foreach (var entity in _group)
            {
                if (!_contexts.game.isGamePaused)
                {
                    var deltaStrafe = entity.rigidbody.value.transform.right * _contexts.game.strafeInput.value;
                    var deltaPosition = deltaStrafe * entity.strafeSpeed.value * Time.deltaTime;

                    entity.rigidbody.value.MovePosition(entity.rigidbody.value.position + deltaPosition);
                    entity.animator.value.SetFloat("StrafeInput", _contexts.game.strafeInput.value);
                    entity.ReplacePosition(entity.rigidbody.value.position);
                }
            }
        }
    }
}
