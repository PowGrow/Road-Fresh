public sealed class GameSystems: Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new InstantiateViewSystem(contexts));
        Add(new CameraInitializationSystem(contexts));
        Add(new PlayerInitializeSystem(contexts));
        Add(new VehicleFactorySystem(contexts));
        Add(new InputSystem(contexts));
        Add(new InteractObjectAddSystem(contexts));
        Add(new InteractObjectRemoveSystem(contexts));
        Add(new PlayerAnimationSystem(contexts));
        Add(new PlayerMovementSystem(contexts));
        Add(new DestroySystem(contexts));
    }
}