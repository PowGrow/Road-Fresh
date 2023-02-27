using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[Game,Unique]
public class BackgroundSetup : ScriptableObject
{
    public List<GameObject> BackgroundPrefabs;
    public float BackgroundSpeed;
    public Vector3 InitializePosition;
    public Vector3 AddPosition;
}
