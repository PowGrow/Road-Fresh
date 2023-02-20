using UnityEngine;

namespace RoadFresh.View
{
    public class RiderView
    {
        public static void AddComponents(GameEntity entity, GameObject gameObject)
        {
            var collider = gameObject.GetComponent<CapsuleCollider>();
            var rigidbody = gameObject.GetComponent<Rigidbody>();
            var leftArm = gameObject.GetComponentInChildren<LeftArmPosition>();
            var rightArm = gameObject.GetComponentInChildren<RightArmPosition>();
            var leftLeg = gameObject.GetComponentInChildren<LeftLegPosition>();
            var rightLeg = gameObject.GetComponentInChildren<RightLegPosition>();
            entity.AddRiderCollider(collider);
            entity.AddRiderRigidbody(rigidbody);
            entity.AddRiderLeftArmPosition(leftArm.transform, leftArm.TwoBoneIKConstraint);
            entity.AddRiderRightArmPosition(rightArm.transform, rightArm.TwoBoneIKConstraint);
            entity.AddRiderLeftLegPosition(leftLeg.transform, leftLeg.TwoBoneIKConstraint);
            entity.AddRiderRightLegPosition(rightLeg.transform, rightLeg.TwoBoneIKConstraint);
        }
    }
}
