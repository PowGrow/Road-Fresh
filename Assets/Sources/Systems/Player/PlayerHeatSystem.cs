using Entitas;
using UnityEngine;

public class PlayerHeatSystem : IExecuteSystem
{

    private Contexts _contexts;

    private IGroup<GameEntity> _group;

    public PlayerHeatSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Heat, GameMatcher.Player));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            if (!_contexts.game.isGamePaused)
            {
                var playerHeat = entity.heat.value;
                if (playerHeat >= 0)
                {
                    playerHeat -= _contexts.game.playerSetup.value.HeatLosePerTick * _contexts.game.gameData.value.GlobalGameSpeed * Time.deltaTime;
                    entity.ReplaceHeat(playerHeat);
                    _contexts.game.gameUI.value.GameOverlay.UpdateHeat(playerHeat);
                }
                else
                {
                    entity.isFell = true;
                }
            }
        }
    }
}
