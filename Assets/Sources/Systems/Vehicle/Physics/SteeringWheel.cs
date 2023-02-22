using UnityEngine;

namespace RoadFresh.Vehicle.Physics
{
    public sealed class SteeringWheel
    {
        private GameEntity _vehicleEntity;
        private Transform _steeringWheelTransform;
        private Contexts _contexts;

        private const float MAX_ANGLE = 120f;
        private const float MIN_ANGLE = -120f;

        public SteeringWheel(GameEntity vehicleEntity,Contexts contexts)
        {
            _vehicleEntity = vehicleEntity;
            _contexts = contexts;
            _steeringWheelTransform = _vehicleEntity.vehicleViewData.SteeringWheelTransform;
        }

        private void UpdateWheelRotation(float delta)
        {
            if(_steeringWheelTransform.rotation.y + delta <=  MAX_ANGLE && _steeringWheelTransform.rotation.y + delta >= MIN_ANGLE)
                _steeringWheelTransform.Rotate(new Vector3(0, delta * Constants.STEERING_WHEEL_SPEED, 0));
        }

        private void TryToReturnWheelPosition()
        {
            if(_steeringWheelTransform.rotation.y != 0)
            {
                var deltaDirection = new Vector3(0,1,0);
                if (_steeringWheelTransform.rotation.y > 0)
                    deltaDirection = -deltaDirection;
                deltaDirection = deltaDirection * Constants.STEERING_WHEEL_SPEED;
                _steeringWheelTransform.Rotate(deltaDirection);
            }
        }

        public void RotateSteeringWheel(float delta)
        {
            if(delta != 0)
                UpdateWheelRotation(delta);
            else
                TryToReturnWheelPosition();
        }
    }
}
