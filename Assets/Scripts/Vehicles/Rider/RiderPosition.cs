using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RiderPosition : MonoBehaviour
{
    [SerializeField]
    private TwoBoneIKConstraint _twoBoneIKConstraint;

    public TwoBoneIKConstraint TwoBoneIKConstraint
    {
        get { return _twoBoneIKConstraint; }
    }

    public Transform Transform
    {
        get { return gameObject.transform; }
    }

    private void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.05f);
    }
}
