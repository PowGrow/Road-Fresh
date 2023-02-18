using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameSetup gameSetup;
    [SerializeField]
    private VehicleSetup vehicleSetup;
    private Systems _systems;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        _systems = new GameSystems(contexts);
        contexts.game.SetGameSetup(gameSetup);
        contexts.game.SetVehicleSetup(vehicleSetup);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }
}
