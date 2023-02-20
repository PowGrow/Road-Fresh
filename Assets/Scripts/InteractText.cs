using TMPro;
using UnityEngine;

public class InteractText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _interactTextMeshProUGUI;

    public TextMeshProUGUI InteractTextMeshProUGUI
    {
        get { return _interactTextMeshProUGUI; }
    }
}
