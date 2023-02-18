using Entitas;

public sealed class VehicleToCreateComponent: IComponent
{
    //Add this component to Entity to trigger VehicleFactorySystem to create Vehicle with added params;
    public int value; // Vehicle index from VehicleSetup to create
}