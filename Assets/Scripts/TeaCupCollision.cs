using Entitas.Unity;
using UnityEngine;

public class TeaCupCollision : CollisionBase
{
    [SerializeField]
    private float _heatAmount;
    private void OnTriggerEnter(Collider other)
    {
        if (HasLinkedEntity(other.gameObject))
        {
            var entity = (GameEntity)other.gameObject.GetEntityLink().entity;
            if (entity.isPlayer)
            {
                var playerHeat = entity.heat.value + _heatAmount;
                entity.ReplaceHeat(playerHeat);
                entity.slurpAudioSource.value.Play();
                Destroy(gameObject);
            }
        }
    }
}
