using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace RoadFresh.View
{
    public class RiderView
    {
        public static void AddComponents(GameEntity entity, GameObject gameObject)
        {
            var leftArm = gameObject.GetComponentInChildren<LeftArmPosition>();
            var rightArm = gameObject.GetComponentInChildren<RightArmPosition>();
            var leftLeg = gameObject.GetComponentInChildren<LeftLegPosition>();
            var rightLeg = gameObject.GetComponentInChildren<RightLegPosition>();
            entity.AddRiderLeftArmPosition(leftArm.transform, leftArm.TwoBoneIKConstraint);
            entity.AddRiderRightArmPosition(rightArm.transform, rightArm.TwoBoneIKConstraint);
            entity.AddRiderLeftLegPosition(leftLeg.transform, leftLeg.TwoBoneIKConstraint);
            entity.AddRiderRightLegPosition(rightLeg.transform, rightLeg.TwoBoneIKConstraint);

        }
    }
}
