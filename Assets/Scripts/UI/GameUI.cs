using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace RoadFresh.View.UI
{
    [Game, Unique]
    public class GameUI : MonoBehaviour
    {
        [SerializeField]
        private GameOverlay _gameOverlay;
        [SerializeField]
        private GameOverOverlay _gameOverOverlay;

        public GameOverlay GameOverlay
        {
            get { return _gameOverlay; }
        }

        public GameOverOverlay GameOverOverlay
        {
            get { return _gameOverOverlay; }
        }
    }
}
