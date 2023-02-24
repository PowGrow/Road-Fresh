using Entitas;

namespace RoadFresh.Vehicle.Physics
{
    public class GearSystem : IExecuteSystem
    {

        private Contexts _contexts;

        private IGroup<GameEntity> _group;

        public GearSystem(Contexts contexts)
        {
            _contexts = contexts;
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.VelocityInput,GameMatcher.Riding));
        }

        public void Execute()
        {
            foreach(GameEntity entity in _group)
            {
                var vehicleEntity = entity.interactObject.value;
                var currentRPM = vehicleEntity.engine.value.RPM;
                var currentGear = vehicleEntity.gear.value;
                if(entity.velocityInput.value.z == -1 && currentGear == Gear.N && currentRPM == Constants.ENGINE_IDLING)
                {
                    vehicleEntity.ReplaceGear(Gear.Reverse);
                }
                if (currentRPM >= Constants.GEAR_RPM_NEXT)
                {
                    if(currentGear != Gear.Fourth && currentGear != Gear.Reverse && entity.velocityInput.value.z == 1)
                    {
                        vehicleEntity.ReplaceGear((Gear)((int)currentGear + 1));
                        vehicleEntity.engine.value.RPM = Constants.ENGINE_GEAR_CHANGE_UP;

                    }
                }
                else if(currentRPM <= Constants.GEAR_RPM_PREVIOUS)
                {
                    if(currentGear != Gear.N && currentGear != Gear.Reverse)
                    {
                        vehicleEntity.ReplaceGear((Gear)((int)currentGear - 1));
                        vehicleEntity.engine.value.RPM = Constants.ENGINE_GEAR_CHANGE_DOWN;
                    }
                }
                if(currentGear == Gear.Reverse && currentRPM == Constants.ENGINE_IDLING)
                {
                    vehicleEntity.ReplaceGear(Gear.N);
                }
            }
        }
    }
}
