using Entitas.Unity;
using UnityEngine;

public class EmitTriggerEntityBehavour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(hasEntity(other.gameObject))
        {
            var entity = Contexts.sharedInstance.game.CreateEntity();
            entity.AddCollision(gameObject, other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (hasEntity(other.gameObject))
        {
            var entity = Contexts.sharedInstance.game.CreateEntity();
            entity.AddExitCollision(gameObject, other.gameObject);
        }
    }

    private bool hasEntity(GameObject gameObject)
    {
        return gameObject.GetEntityLink() != null;
    }
}
