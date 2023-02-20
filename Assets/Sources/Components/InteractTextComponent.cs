using Entitas;
using TMPro;
using UnityEngine;

[Game]
public sealed class InteractTextComponent: IComponent
{
    public TextMeshProUGUI value;
    public Transform lookTarget = null;
}