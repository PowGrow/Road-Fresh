using UnityEngine;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

[CreateAssetMenu]
[Game, Unique]

public class VehicleSetup : ScriptableObject
{
    public List<GameObject> VehiclePrefabs;
    public List<float> VehicleSpeed;
    public List<string> VehicleName;
}
