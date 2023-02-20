using UnityEngine;

public class TestVehicleFactory : MonoBehaviour
{
    private Contexts _contexts;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
    }

    private void Start()
    {
        CreateVespa();
    }

    [ContextMenu("CreateVespa")]
    public void CreateVespa()
    {
        var entity = _contexts.game.CreateEntity();
        entity.AddInitialPoistion(transform.position);
        entity.AddVehicleToCreate(0);
    }
}
