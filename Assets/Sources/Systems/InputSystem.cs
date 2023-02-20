using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace RoadFresh.Input
{
    [Input, Unique]
    public sealed class InputSystem : IExecuteSystem
    {
        private Contexts _contexts;

        private IGroup<GameEntity> _group;

        public InputSystem(Contexts contexts)
        {
            _contexts = contexts;
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Velocity, GameMatcher.Player));
        }

        public void Execute()
        {
            foreach (var e in _group)
            {
                e.ReplaceVelocity(new Vector3(_contexts.game.velocityInput.value.x, 0, _contexts.game.velocityInput.value.y));
            }
        }
    }
}
