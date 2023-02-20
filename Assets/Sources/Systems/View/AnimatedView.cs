using UnityEngine;

namespace RoadFresh.View
{
    public class AnimatedView
    {
        public static void AddComponents(GameEntity entity, GameObject gameObject)
        {
            entity.AddAnimator(gameObject.GetComponent<Animator>());
        }
    }
}
