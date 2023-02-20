using UnityEngine;

public class ScooterMaterial : MonoBehaviour
{
    [SerializeField]
    private Vespa vespaSetup;
    private void Awake()
    {
        var baseParts = GetComponentsInChildren<BaseMaterialMarker>();
        foreach(BaseMaterialMarker baseMaterialMarker in baseParts)
        {
            baseMaterialMarker.GetComponent<MeshRenderer>().material = vespaSetup.BaseMaterial;
        }
    }
}
