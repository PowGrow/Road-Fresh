using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[Game, Unique]
public class VehiclePrefabs : ScriptableObject
{
    public List<GameObject> Prefabs;
}
