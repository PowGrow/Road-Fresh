using Entitas;
using UnityEngine;

public class RoadMoveSystem : IExecuteSystem
{
    private Contexts _contexts;

    private IGroup<GameEntity> _group;

    public RoadMoveSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Road));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            if(entity.hasView && !_contexts.game.isGamePaused)
            {
                entity.view.value.transform.Translate(new Vector3(0,0,-_contexts.game.roadSetup.value.RoadSpeed * _contexts.game.gameData.value.GlobalGameSpeed) * Time.deltaTime);
                entity.ReplacePosition(entity.view.value.transform.position);
            }
        }
    }
}
