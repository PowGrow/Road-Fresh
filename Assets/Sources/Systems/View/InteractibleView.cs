using UnityEngine;

namespace RoadFresh.View
{
    public class InteractibleView
    {
        public static void AddComponents(GameEntity entity, GameObject gameObject)
        {
            entity.AddInteractText(gameObject.GetComponent<InteractText>().InteractTextMeshProUGUI, null);
            entity.AddInteractTextCanvas(gameObject.GetComponentInChildren<Canvas>());
        }
    }
}
