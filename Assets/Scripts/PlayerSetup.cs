using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu]
[Game,Unique]
public class PlayerSetup : ScriptableObject
{
    public GameObject Prefab;
    public float StrafeSpeed;
    public float HeatLosePerTick;
    public Vector3 InitialPosition;
    public AudioClip beepSound;
    public AudioClip teaSlurpSound;
    public AudioClip engineSound;
    public AudioClip crashSound;
}
