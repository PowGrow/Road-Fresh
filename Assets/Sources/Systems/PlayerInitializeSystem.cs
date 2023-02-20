using Entitas;
using UnityEngine;

public sealed class PlayerInitializeSystem : IInitializeSystem
{
    private Contexts _contexts;

    public PlayerInitializeSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddInitialPoistion(_contexts.game.gameSetup.value.PlayerInitialPosition);
        entity.isPlayer = true;
        entity.isRider = true;
        entity.isPhysic = true;
        entity.isAnimated = true;
        entity.AddSpeed(_contexts.game.gameSetup.value.PlayerSpeed);
        entity.AddRotationSpeed(_contexts.game.gameSetup.value.PlayerRotationSpeed);
        entity.AddVelocity(Vector3.zero);
        entity.AddPosition(entity.initialPoistion.value);
        entity.AddRotation(Vector3.zero);
        entity.AddRotationInput(0);
        entity.AddVelocityInput(Vector3.zero);
        entity.AddResource(_contexts.game.gameSetup.value.PlayerPrefab);
    }
}
