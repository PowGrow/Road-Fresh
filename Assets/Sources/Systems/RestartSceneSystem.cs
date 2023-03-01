using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RestartSceneSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    private const string GAME_SCENE = "Game";

    public RestartSceneSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.SceneReloading));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isSceneReloading;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var allEntities = _contexts.game.GetEntities();
        GameController.Systems.DeactivateReactiveSystems();
        GameController.Systems.ClearReactiveSystems();
        foreach (GameEntity entity in allEntities)
        {
            if(entity.hasView)
            {
                entity.view.value.Unlink();
                entity.Destroy();
                continue;
            }
            entity.Destroy();
            
        }
        SceneManager.LoadScene(GAME_SCENE);
    }
}
