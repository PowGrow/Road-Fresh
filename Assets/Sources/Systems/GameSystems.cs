using RoadFresh.View;

public sealed class GameSystems: Feature
{
    public GameSystems(Contexts contexts)
    {
        //Initialize
        Add(new RoadInitializeSystem(contexts));
        Add(new BackgroundInitializeSystem(contexts));
        Add(new PlayerInitializeSystem(contexts));
        Add(new ViewInitializeSystem(contexts));
        //Execute
        Add(new RoadMoveSystem(contexts));
        Add(new BackgroundMoveSystem(contexts));
        Add(new PlayerMoveSystem(contexts));
        //Reactive
        Add(new DestroySystem(contexts));
        Add(new RoadAddSystem(contexts));
        Add(new RoadDestroySystem(contexts));
        Add(new BackgroundDestroySystem(contexts));
        Add(new BackgroundAddSystem(contexts));
    }
}