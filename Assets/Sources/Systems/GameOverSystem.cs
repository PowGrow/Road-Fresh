using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public sealed class GameOverSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    private const int STATISTIC_LINES = 5;
    public GameOverSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameOver);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGameOver;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            _contexts.game.gameUI.value.GameOverOverlay.EnableGameOverUI();
            _contexts.game.gameUI.value.GameOverlay.HideGameControlls();
            _contexts.game.isGamePaused = true;
            if (UpdateStatisticData())
                _contexts.game.gameUI.value.GameOverOverlay.EnableRecordLable();
        }
    }

    private bool UpdateStatisticData()
    {
        var gameData = _contexts.game.gameData.value;
        var statisticLine = new Statistic.Line(gameData.Score, Time.timeSinceLevelLoad, gameData.ObstaclePassed);
        if (Statistic.IsThereAreSaveData())
        {
            var statistic = Statistic.LoadStatistic();
            var index = -1;
            foreach(Statistic.Line line in statistic)
            {
                if(gameData.Score > line.Score)
                {
                    index = statistic.IndexOf(line);
                    break;
                }
            }
            if (index != -1)
            {
                statistic.Insert(index, statisticLine);
                if(statistic.Count > STATISTIC_LINES)
                    statistic.RemoveAt(STATISTIC_LINES);
                Statistic.SaveStatistic(statistic);
                return true;
            }
            return false;
        }
        else
        {
            var statistic = new List<Statistic.Line>
            {
                statisticLine
            };
            Statistic.SaveStatistic(statistic);
            return true;
        }
    }
}
