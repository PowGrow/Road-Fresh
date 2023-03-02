using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace RoadFresh.Initialize.Setups
{
    [CreateAssetMenu]
    [Game, Unique]
    public class UISetup : ScriptableObject
    {
        public GameObject GameUI;
    }
}
