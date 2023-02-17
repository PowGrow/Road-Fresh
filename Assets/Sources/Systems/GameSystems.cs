public sealed class GameSystems: Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new InstantiateViewSystem(contexts));
        Add(new PlayerInitializeSystem(contexts));
        Add(new InputSystem(contexts));
        Add(new PlayerAnimationSystem(contexts));
        Add(new PlayerMovementSystem(contexts));
    }
}