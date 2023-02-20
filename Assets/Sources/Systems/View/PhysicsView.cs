using UnityEngine;

namespace RoadFresh.View
{
    public class PhysicsView
    {
        public static void AddComponents(GameEntity entity, GameObject gameObject)
        {
            entity.AddRigidbody(gameObject.GetComponent<Rigidbody>());
        }
    }
}
