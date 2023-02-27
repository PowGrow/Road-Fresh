using Entitas;
using UnityEngine;

public class BackgroundMoveSystem : IExecuteSystem
{
    private Contexts _contexts;

    private IGroup<GameEntity> _group;

    public BackgroundMoveSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Background));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            if(entity.hasView)
            {
                entity.view.value.transform.Translate(new Vector3(0,0,-_contexts.game.backgroundSetup.value.BackgroundSpeed * _contexts.game.gameData.value.GlobalGameSpeed) * Time.deltaTime);
                entity.ReplacePosition(entity.view.value.transform.position);
            }
        }
    }
}
