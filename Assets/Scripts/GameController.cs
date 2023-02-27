using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerSetup playerSetup;
    [SerializeField]
    private RoadSetup roadSetup;
    [SerializeField]
    private BackgroundSetup backgroundSetup;
    private Systems _systems;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        _systems = new GameSystems(contexts);
        contexts.game.SetPlayerSetup(playerSetup);
        contexts.game.SetRoadSetup(roadSetup);
        contexts.game.SetBackgroundSetup(backgroundSetup);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }
}
