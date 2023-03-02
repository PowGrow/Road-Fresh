using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameController.LoadScene(MENU_SCENE, _contexts);
    }
}
