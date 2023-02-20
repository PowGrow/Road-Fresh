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
            _steeringWheelTransform.Rotate(new Vector3(0, Mathf.Clamp(delta,MIN_ANGLE,MAX_ANGLE), 0));
        }

        private void TryToReturnWheelPosition()
        {
            if(_steeringWheelTransform.rotation.eulerAngles.y != 0)
            {
                float delta = 1;
                if (_steeringWheelTransform.rotation.eulerAngles.y > 0) delta = 1;
                else delta = -1;
                delta = delta * _vehicleEntity.vehicleViewData.RotationSpeed * Time.fixedDeltaTime;
                UpdateWheelRotation(delta);
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
