using Entitas;
using Entitas.Unity;
using RoadFresh.Initialize.Setups;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    private Contexts _contexts;
    private Systems _systems;

    public void LoadScene(string sceneName)
    {
        var allEntities = _contexts.game.GetEntities();
        _systems.DeactivateReactiveSystems();
        _systems.ClearReactiveSystems();
        foreach (GameEntity entity in allEntities)
        {
            if (entity.hasView)
            {
                entity.view.value.Unlink();
                entity.Destroy();
                continue;
            }
            entity.Destroy();

        }
        SceneManager.LoadScene(sceneName);
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
        _contexts.game.SetGameController(this);
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
