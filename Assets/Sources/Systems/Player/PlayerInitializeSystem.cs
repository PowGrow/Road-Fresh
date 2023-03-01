using UnityEngine;
using Entitas;

public sealed class PlayerInitializeSystem : IInitializeSystem
{
    private Contexts _contexts;

    public PlayerInitializeSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var playerSetup = _contexts.game.playerSetup.value;
        var playerEntity = _contexts.game.CreateEntity();
        playerEntity.isPlayer = true;
        playerEntity.isAnimated = true;
        playerEntity.AddStrafeSpeed(playerSetup.StrafeSpeed);
        playerEntity.AddStrafeInput(0);
        playerEntity.AddPosition(playerSetup.InitialPosition);
        playerEntity.AddHeat(1);
        playerEntity.AddResource(playerSetup.Prefab);
    }
}
