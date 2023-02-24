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

        transform.position = new Vector3(transform.position.x, position.y, transform.position.z);
        transform.rotation = Quaternion.Euler(rotation.eulerAngles.x, transform.rotation.eulerAngles.y , rotation.eulerAngles.z);
    }
}
