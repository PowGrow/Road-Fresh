using UnityEngine;
using UnityEngine.Animations.Rigging;

public class UnityRigs : MonoBehaviour
{
    [SerializeField]
    private RigBuilder _rigBuilder;
    [SerializeField]
    private Transform _unityRigsTransform;
    [SerializeField]
    private Animator _characterAnimator;

    public RigBuilder RigBuilder
    {
        get { return _rigBuilder; }
    }

    public Transform UnityRigsTransform
    {
        get { return _unityRigsTransform; }
    }

    public Animator CharacterAnimator
    {
        get { return _characterAnimator; }
    }
}
