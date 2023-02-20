using UnityEngine;

namespace RoadFresh.View
{
    public class VehicleView
    {
        public static void AddComponents(GameEntity entity, GameObject gameObject)
        {
            var vehicleSetupData = gameObject.GetComponentInChildren<Vespa>();
            entity.AddVehicleViewData(  vehicleSetupData.Speed, 
                                        vehicleSetupData.RotationSpeed, 
                                        vehicleSetupData.Body, 
                                        vehicleSetupData.SteeringWheel, 
                                        vehicleSetupData.FrontWheel, 
                                        vehicleSetupData.BackWheel);
            entity.AddSpeed(entity.vehicleViewData.Speed);
            entity.AddRotationSpeed(entity.vehicleViewData.RotationSpeed);
            entity.AddUnmountPosition(gameObject.GetComponentInChildren<UnmountPosition>().Transform);
            entity.AddMountPosition(gameObject.GetComponentInChildren<MountPosition>().Transform);
            entity.AddLeftArmPosition(gameObject.GetComponentInChildren<LeftArmPosition>().Transform);
            entity.AddRightArmPosition(gameObject.GetComponentInChildren<RightArmPosition>().Transform);
            entity.AddLeftLegPosition(gameObject.GetComponentInChildren<LeftLegPosition>().Transform);
            entity.AddRightLegPosition(gameObject.GetComponentInChildren<RightLegPosition>().Transform);
        }
    }
}
