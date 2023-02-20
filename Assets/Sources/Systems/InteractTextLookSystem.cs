using Entitas;

namespace RoadFresh.Interactions
{
    public class InteractTextLookSystem : IExecuteSystem
    {

        private Contexts _contexts;

        private IGroup<GameEntity> _group;

        public InteractTextLookSystem(Contexts contexts)
        {
            _contexts = contexts;
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.InteractText, GameMatcher.InteractTextCanvas));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _group)
            {
                entity.interactTextCanvas.value.transform.LookAt(entity.interactText.lookTarget);
            }
        }
    }
}
