using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOverlay : MonoBehaviour
{
    [SerializeField]
    private GameObject loseLabelObject;
    [SerializeField]
    private GameObject scoreRecordObject;
    [SerializeField]
    private GameObject restartButtonObject;
    [SerializeField]
    private GameObject mainMenuButtonObject;

    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void EnableGameOverUI()
    {
        loseLabelObject.SetActive(true);
        restartButtonObject.SetActive(true);
        mainMenuButtonObject.SetActive(true);
    }

    public void EnableRecordLable()
    {
        scoreRecordObject.SetActive(true);
    }

    public void OnRestartButtonClick()
    {
        Contexts.sharedInstance.game.isSceneReloading = true;
    }

    public void OnMainMenuButtonClick()
    {
        Contexts.sharedInstance.game.isReturnMenu = true;
    }

    public void OnPointerDown()
    {
        _audioSource.Play();
    }
}
