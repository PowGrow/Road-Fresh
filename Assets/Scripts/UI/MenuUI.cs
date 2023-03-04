using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoadFresh.View.UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject menuObject;
        [SerializeField]
        private GameObject scoreTableObject;
        [SerializeField]
        private GameObject quitGameButtonObject;

        private AudioSource _clickAudioSource;

        private const string GAME_SCENE = "Game";
        private void Awake()
        {
            if (Application.platform == RuntimePlatform.Android)
                quitGameButtonObject.SetActive(false);
            _clickAudioSource = GetComponent<AudioSource>();
        }

        public void OnButtonClick()
        {
            _clickAudioSource.Play();
        }

        public void OnPlayButtonClick()
        {
            SceneManager.LoadSceneAsync(GAME_SCENE);
        }

        public void OnScoreButtonClick()
        {
            menuObject.SetActive(false);
            scoreTableObject.SetActive(true);
        }

        public void OnMenuReturnButtonClick()
        {
            menuObject.SetActive(true);
            scoreTableObject.SetActive(false);
        }

        public void OnQuitButtonClick()
        {
            Application.Quit();
        }

    }
}
