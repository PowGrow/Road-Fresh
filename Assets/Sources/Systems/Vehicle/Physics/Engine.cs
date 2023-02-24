using Entitas;
using UnityEngine;

namespace RoadFresh.Vehicle.Physics
{
    public sealed class Engine
    {
        private GameEntity _vehicleEntity;
        private Contexts _contexts;

        private float _rpm = Constants.ENGINE_IDLING;

        public float RPM
        {
            get { return _rpm; }
            set { _rpm = value; }
        }

        public Engine(GameEntity vehicleEntity, Contexts contexts)
        {
            _vehicleEntity = vehicleEntity;
            _contexts = contexts;
        }

        public void ControllEngine(float velocityInput)
        {
            switch (velocityInput)
            {
                case 1:
                    IncreaseRPM();
                    break;
                case -1:
                    IncreaseReverseRPM();
                    break;
                case 0:
                    DecreaseRPM();
                    break;
            }
        }

        private void IncreaseRPM()
        {
            if(_rpm < Constants.ENGINE_RPM_MAX && _vehicleEntity.gear.value != Gear.Reverse)
                    _rpm += Constants.ENGINE_RPM_STEP;
            else
                DecreaseRPM();
        }

        private void IncreaseReverseRPM()
        {
            if (_rpm < Constants.ENGINE_RPM_MAX && _vehicleEntity.gear.value == Gear.Reverse)
                _rpm += Constants.ENGINE_REVERSE_RPM_STEP;
            else
                DecreaseRPM();
        }

        private void DecreaseRPM()
        {
            _rpm -= Constants.ENGINE_RPM_STEP;
            if (_rpm < Constants.ENGINE_IDLING)
                _rpm = Constants.ENGINE_IDLING;
        }
    }
}
