using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerSetup playerSetup;
    [SerializeField]
    private UISetup uiSetup;
    [SerializeField]
    private RoadSetup roadSetup;
    [SerializeField]
    private BackgroundSetup backgroundSetup;
    [SerializeField]
    private GameData gameData;
    [SerializeField]
    private int targetFrameRateWindows;
    [SerializeField]
    private int targetFrameRateAndroid;
    private static Systems _systems;
    private Contexts _contexts;
    

    public static Systems Systems
    {
        get { return _systems; }
    }

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
            Application.targetFrameRate = targetFrameRateAndroid;
        else
            Application.targetFrameRate = targetFrameRateWindows;

    }

    private void Start()
    {
        _contexts = Contexts.sharedInstance;
        _systems = new GameSystems(_contexts);
        _contexts.game.SetPlayerSetup(playerSetup);
        _contexts.game.SetRoadSetup(roadSetup);
        _contexts.game.SetBackgroundSetup(backgroundSetup);
        _contexts.game.SetGameData(gameData);
        _contexts.game.SetUISetup(uiSetup);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }
}
