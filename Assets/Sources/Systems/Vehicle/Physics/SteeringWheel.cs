using UnityEngine;

namespace RoadFresh.Vehicle.Physics
{
    public sealed class SteeringWheel
    {
        private GameEntity _vehicleEntity;
        private Transform _steeringWheelTransform;
        private Contexts _contexts;

        public SteeringWheel(GameEntity vehicleEntity,Contexts contexts)
        {
            _vehicleEntity = vehicleEntity;
            _contexts = contexts;
            _steeringWheelTransform = _vehicleEntity.vehicleViewData.SteeringWheelTransform;
        }

        private void UpdateWheelRotation(float delta)
        {
            var wheelRotation = InspectorAngleValue(_steeringWheelTransform.localEulerAngles.y);
            
            if (wheelRotation + delta <= Constants.WHEEL_MAX_ANGLE && wheelRotation + delta >= Constants.WHEEL_MIN_ANGLE)
                _steeringWheelTransform.Rotate(new Vector3(0, delta * Constants.STEERING_WHEEL_SPEED, 0));
        }

        private void TryToReturnWheelPosition()
        {
            var wheelRotation = _steeringWheelTransform.rotation.y;
            if(wheelRotation != 0)
            {
                Debug.Log("Rotation: " + wheelRotation);
                if(Mathf.Abs(wheelRotation) <= Constants.STEERING_WHEEL_SPEED)
                {
                    _steeringWheelTransform.rotation = Quaternion.Euler(Vector3.zero);
                }
                else
                {
                    var deltaDirection = new Vector3(0, 1, 0);
                    if (wheelRotation > 0)
                        deltaDirection = -deltaDirection;
                    deltaDirection = deltaDirection * Constants.STEERING_WHEEL_SPEED;
                    _steeringWheelTransform.Rotate(deltaDirection);
                }

            }
        }

        public void RotateSteeringWheel(float delta)
        {
            if(delta != 0)
                UpdateWheelRotation(delta);
            //else
            //    TryToReturnWheelPosition();
        }

        private static float InspectorAngleValue(float angle)
        {
            angle %= 360;
            if (angle > 180)
                return angle - 360;

            return angle;
        }

    }
}
