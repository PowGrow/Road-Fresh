using UnityEngine;

public class UIRotator : MonoBehaviour
{
    private Canvas _canvas;
    private Contexts _contexts;
    private Transform _mainCamera;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _contexts = Contexts.sharedInstance;
    }

    void FixedUpdate()
    {
        _canvas.transform.LookAt(_contexts.game.mainCamera.value);
    }

}
