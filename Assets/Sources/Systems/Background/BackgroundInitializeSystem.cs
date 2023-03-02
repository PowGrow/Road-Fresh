using UnityEngine;
using Entitas;

namespace RoadFresh.Initialize.Systems
{
    public sealed class BackgroundInitializeSystem : IInitializeSystem
    {
        private Contexts _contexts;

        public BackgroundInitializeSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            var backgroundSetup = _contexts.game.backgroundSetup.value;
            var backgroundEntity = _contexts.game.CreateEntity();
            backgroundEntity.isBackground = true;
            backgroundEntity.AddPosition(backgroundSetup.InitializePosition);
            backgroundEntity.AddResource(backgroundSetup.BackgroundPrefabs[Random.Range(0, backgroundSetup.BackgroundPrefabs.Count - 1)]);
            var backgroundEntityFar = _contexts.game.CreateEntity();
            backgroundEntityFar.isBackground = true;
            backgroundEntityFar.AddPosition(new Vector3(0, 3, 172.4492f));
            backgroundEntityFar.AddResource(backgroundSetup.BackgroundPrefabs[Random.Range(0, backgroundSetup.BackgroundPrefabs.Count - 1)]);
        }
    }
}
