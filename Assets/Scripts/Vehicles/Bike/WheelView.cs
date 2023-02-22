using UnityEngine;

public class WheelView : MonoBehaviour
{
    [SerializeField]
    private WheelCollider wheelPhysic;
    
    void Update()
    {
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        wheelPhysic.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;
    }
}
