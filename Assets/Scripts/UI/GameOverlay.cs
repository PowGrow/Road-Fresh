using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RoadFresh.View.UI
{
    public class GameOverlay : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreCounter;
        [SerializeField]
        private TextMeshProUGUI _obstaclesCounter;
        [SerializeField]
        private Image heatImage;
        [SerializeField]
        private GameObject heatBarObject;
        [SerializeField]
        private GameObject joystick;
        [SerializeField]
        private GameObject beepButton;

        private void Awake()
        {
            if (Application.platform != RuntimePlatform.Android)
                HideMobileControlls();
        }

        public void UpdateScore(float value)
        {
            _scoreCounter.text = Convert.ToString((int)value);
        }

        public void UpdateObstaclesCount(float value)
        {
            _obstaclesCounter.text = Convert.ToString((int)value);
        }

        public void UpdateHeat(float value)
        {
            heatImage.fillAmount = value;
        }

        public void HideGameControlls()
        {
            heatBarObject.SetActive(false);
            HideMobileControlls();
        }

        public void HideMobileControlls()
        {
            joystick.SetActive(false);
            beepButton.SetActive(false);
        }

        public void OnBeepButtonPress()
        {
            Contexts.sharedInstance.game.ReplaceBeep(true);
        }

        public void OnBeepButtonRelease()
        {
            Contexts.sharedInstance.game.ReplaceBeep(false);
        }

    }
}
