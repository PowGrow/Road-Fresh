using UnityEngine;

namespace RoadFresh.View
{ 
    public class PlayerView
    {
        public static void AddComponents(GameEntity entity, GameObject gameObject)
        {
            entity.AddMainCamera(gameObject.GetComponentInChildren<Camera>().transform);
        }
    }
}
