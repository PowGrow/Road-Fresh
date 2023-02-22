using UnityEngine;

public class SetupCenterOfMass : MonoBehaviour
{
    [SerializeField]
    private Transform ceneterOfMass;
    [SerializeField]
    private Rigidbody rb;

    private void FixedUpdate()
    {
        rb.centerOfMass = ceneterOfMass.position;
    }
}
