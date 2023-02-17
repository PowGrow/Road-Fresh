using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game,Unique]
public sealed class VelocityInputComponent : IComponent
{
    public Vector3 value;
}
