using RoadFresh.View;

public sealed class GameSystems: Feature
{
    public GameSystems(Contexts contexts)
    {
        //Initialize
        Add(new GameUIInitializeSystem(contexts));
        Add(new RoadInitializeSystem(contexts));
        Add(new BackgroundInitializeSystem(contexts));
        Add(new PlayerInitializeSystem(contexts));
        Add(new ViewInitializeSystem(contexts));
        Add(new GameSpeedSystem(contexts));
        //Execute
        Add(new PlayerBeepSystem(contexts));
        Add(new RoadMoveSystem(contexts));
        Add(new BackgroundMoveSystem(contexts));
        Add(new PlayerMoveSystem(contexts));
        //Reactive
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