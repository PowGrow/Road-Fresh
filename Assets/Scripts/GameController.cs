using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameSetup gameSetup;
    [SerializeField]
    private VehiclePrefabs vehiclePrefabs;

    private Systems _systems;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        _systems = new GameSystems(contexts);
        contexts.game.SetGameSetup(gameSetup);
        contexts.game.SetVehiclePrefabs(vehiclePrefabs);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }
}
