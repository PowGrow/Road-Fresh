using TMPro;
using UnityEngine;

public class GameOverOverlay : MonoBehaviour
{
    [SerializeField]
    private GameObject loseLabelObject;
    [SerializeField]
    private GameObject scoreRecordObject;

    public void EnableGameOverUI()
    {
        loseLabelObject.SetActive(true);
    }

    public void EnableRecordLable()
    {
        scoreRecordObject.SetActive(true);
    }
}
