using RoadFresh.Stats;
using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject gameLoopObject;
    [SerializeField]
    private GameObject movementPC;
    [SerializeField]
    private GameObject movementAndroid;
    [SerializeField]
    private GameObject beepPC;
    [SerializeField]
    private GameObject beepAndroid;
    private RuntimePlatform platform;

    private const int INIT_DELAY = 0;
    private const int FIRST_DELAY = 3;
    private const int SECOND_DELAY = 4;
    private const int THIRD_DELAY = 5;

    public bool IsActive { get; private set; } = false;

    private void Start()
    {
        TryToStartTutorial();
    }

    public void TryToStartTutorial()
    {
        platform = Application.platform;
        if (!Statistic.IsThereAreSaveData())
            StartCoroutine(StartTutorial(platform));
    }

    private IEnumerator StartTutorial(RuntimePlatform platform)
    {
        IsActive = true;
        switch(platform)
        {
            case RuntimePlatform.Android:
                StartCoroutine(TutorialSequence(movementAndroid, beepAndroid, gameLoopObject));
                break;
            case RuntimePlatform.WindowsPlayer:
                StartCoroutine(TutorialSequence(movementPC, beepPC, gameLoopObject));
                break;
            case RuntimePlatform.WindowsEditor:
                StartCoroutine(TutorialSequence(movementPC, beepPC, gameLoopObject));
                break;
        }
        yield return null;
    }

    private IEnumerator TutorialSequence(GameObject movement, GameObject beep, GameObject gameLoop)
    {
        yield return new WaitForSeconds(INIT_DELAY);
        movement.SetActive(true);
        yield return new WaitForSeconds(FIRST_DELAY);
        movement.SetActive(false);
        beep.SetActive(true);
        yield return new WaitForSeconds(SECOND_DELAY);
        beep.SetActive(false);
        gameLoop.SetActive(true);
        yield return new WaitForSeconds(THIRD_DELAY);
        gameLoop.SetActive(false);
        IsActive = false;
        yield return null;
    }
}
