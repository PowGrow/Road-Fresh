using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using UnityEngine;

namespace RoadFresh.Initialize.Setups
{
    [CreateAssetMenu]
    [Game, Unique]
    public class RoadSetup : ScriptableObject
    {
        public List<GameObject> roadPrefabs;
        public float RoadSpeed;
        public Vector3 InitializePosition;
        public Vector3 AddPosition;
    }
}
