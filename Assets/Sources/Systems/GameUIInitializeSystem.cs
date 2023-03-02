using Entitas;

namespace RoadFresh.View.Systems
{
    public class GameUIInitializeSystem : IInitializeSystem
    {
        private Contexts _contexts;

        public GameUIInitializeSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            var uiSetup = _contexts.game.uISetup.value;
            var uiEntity = _contexts.game.CreateEntity();
            uiEntity.isUi = true;
            uiEntity.AddResource(uiSetup.GameUI);
        }
    }
}
