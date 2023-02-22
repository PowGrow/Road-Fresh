using UnityEngine;

public class SetupCenterOfMass : MonoBehaviour
{
    [SerializeField]
    private Transform ceneterOfMass;
    [SerializeField]
    private Rigidbody rb;

    private void Awake()
    {
        rb.centerOfMass = ceneterOfMass.position;
    }
}
