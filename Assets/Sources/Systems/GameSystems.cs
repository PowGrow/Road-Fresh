using RoadFresh.Controls.Systems;
using RoadFresh.GameLoop.Systems;
using RoadFresh.Initialize.Systems;
using RoadFresh.View.Systems;

public sealed class GameSystems: Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new ViewInitializeSystem(contexts));
        Add(new PlayerViewInitializeSystem(contexts));
        Add(new GameUIInitializeSystem(contexts));
        Add(new RoadInitializeSystem(contexts));
        Add(new BackgroundInitializeSystem(contexts));
        Add(new PlayerInitializeSystem(contexts));

        Add(new GameSpeedSystem(contexts));
        Add(new PlayerHeatSystem(contexts));
        Add(new PlayerBeepSystem(contexts));
        Add(new RoadMoveSystem(contexts));
        Add(new BackgroundMoveSystem(contexts));
        Add(new PlayerMoveSystem(contexts));

        Add(new RestartSceneSystem(contexts));
        Add(new ReturnMenuSystem(contexts));
        Add(new GameOverSystem(contexts));
        Add(new ScoreSystem(contexts));
        Add(new ObstacleCounterSystem(contexts));
        Add(new PlayerFallSystem(contexts));
        Add(new DestroySystem(contexts));
        Add(new RoadAddSystem(contexts));
        Add(new RoadDestroySystem(contexts));
        Add(new BackgroundDestroySystem(contexts));
        Add(new BackgroundAddSystem(contexts));
    }
}