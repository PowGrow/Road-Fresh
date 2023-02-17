using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[CreateAssetMenu]
[Game, Unique]
public class GameSetup : ScriptableObject
{
    public GameObject PlayerPrefab;
    public Vector3 PlayerInitialPosition;
    public float PlayerSpeed;
    public float PlayerRotationSpeed;
}
