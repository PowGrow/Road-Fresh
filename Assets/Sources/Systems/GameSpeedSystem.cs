using Entitas;
using RoadFresh.Initialize.Setups;
using UnityEngine;

namespace RoadFresh.GameLoop.Systems
{
    public sealed class GameSpeedSystem : IInitializeSystem, IExecuteSystem
    {

        private Contexts _contexts;

        private float _timePassed = 0f;

        private GameData _gameData;
        private const float MAX_SPEED = 2.5f;

        public GameSpeedSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _gameData = _contexts.game.gameData.value;
            _gameData.GlobalGameSpeed = 1f;
        }

        public void Execute()
        {
            if (!_contexts.game.isGamePaused && _gameData.GlobalGameSpeed < MAX_SPEED)
            {
                _timePassed += Time.deltaTime;
                if (_timePassed >= _gameData.DeltaInterval)
                {
                    _gameData.GlobalGameSpeed += _gameData.DeltaSpeed;
                    _timePassed = 0f;
                }
            }
        }
    }
}
