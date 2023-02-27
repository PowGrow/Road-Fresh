using Entitas;
using UnityEngine;

public class GameSpeedSystem : IInitializeSystem, IExecuteSystem
{

    private Contexts _contexts;

    private float _gameTime = 0f;

    private GameData _gameData;

    public GameSpeedSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _gameData = _contexts.game.gameData.value;
        //reset data to default;
        _gameData.ObstaclePassed = 0;
        _gameData.GlobalGameSpeed = 1f;
    }

    public void Execute()
    {
        _gameTime += Time.deltaTime;
        if(_gameTime >= _gameData.DeltaInterval)
        {
            _gameData.GlobalGameSpeed += _gameData.DeltaSpeed;
            Debug.Log("Current speed: " + _gameData.GlobalGameSpeed);
            _gameTime = 0f;
        }
    }
}
