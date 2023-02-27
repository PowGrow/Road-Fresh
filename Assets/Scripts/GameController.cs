using Entitas;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerSetup playerSetup;
    [SerializeField]
    private RoadSetup roadSetup;
    [SerializeField]
    private BackgroundSetup backgroundSetup;
    [SerializeField]
    private GameData gameData;
    private Systems _systems;
    private Contexts _contexts;

    private void Start()
    {
        _contexts = Contexts.sharedInstance;
        _systems = new GameSystems(_contexts);
        _contexts.game.SetPlayerSetup(playerSetup);
        _contexts.game.SetRoadSetup(roadSetup);
        _contexts.game.SetBackgroundSetup(backgroundSetup);
        _contexts.game.SetGameData(gameData);
        _systems.Initialize();
    }

    private void Update()
    {
        if (!_contexts.game.isGamePaused)
        {
            _systems.Execute();
        }
    }
}
