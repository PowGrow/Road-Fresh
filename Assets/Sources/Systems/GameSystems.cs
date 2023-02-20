using RoadFresh.View;
using RoadFresh.Vehicle;
using RoadFresh.Interactions;
using RoadFresh.Input;

public sealed class GameSystems: Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new InstantiateViewSystem(contexts));
        Add(new PlayerInitializeSystem(contexts));
        Add(new VehicleFactorySystem(contexts));
        Add(new InputSystem(contexts));
        Add(new InteractObjectAddSystem(contexts));
        Add(new InteractObjectRemoveSystem(contexts));
        Add(new InteractTextSystem(contexts));
        Add(new InteractTextRidingSystem(contexts));
        Add(new InteractTextLookSystem(contexts));
        Add(new RiderViewSystem(contexts));
        Add(new VehicleRidingSystem(contexts));
        Add(new PlayerAnimationSystem(contexts));
        Add(new PlayerMovementSystem(contexts));
        Add(new DestroySystem(contexts));
    }
}