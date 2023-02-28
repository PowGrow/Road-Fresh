using System;
using TMPro;
using UnityEngine;

public class GameOverlay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreCounter;
    [SerializeField]
    private TextMeshProUGUI _obstaclesCounter;


    public void UpdateScore(float value)
    {
        _scoreCounter.text = Convert.ToString((int)value);
    }

    public void UpdateObstaclesCount(float value)
    {
        _obstaclesCounter.text = Convert.ToString((int)value);
    }
}
