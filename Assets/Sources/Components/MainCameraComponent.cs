using Entitas.CodeGeneration.Attributes;
using Entitas;
using UnityEngine;

[Game,Unique]

public sealed class MainCameraComponent : IComponent
{
    public Transform value;
}
