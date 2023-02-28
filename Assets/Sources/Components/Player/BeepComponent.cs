using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game,Unique]
public class BeepComponent : IComponent
{
    public bool value;
}
