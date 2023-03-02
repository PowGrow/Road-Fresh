using Entitas;
using System.Collections.Generic;

namespace RoadFresh.Controls.Systems
{
    public class ReturnMenuSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        private const string MENU_SCENE = "Menu";

        public ReturnMenuSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.ReturnMenu));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isReturnMenu;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _contexts.game.gameController.value.LoadScene(MENU_SCENE);
        }
    }
}
