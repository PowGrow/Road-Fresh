//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly VehicleComponent vehicleComponent = new VehicleComponent();

    public bool isVehicle {
        get { return HasComponent(GameComponentsLookup.Vehicle); }
        set {
            if (value != isVehicle) {
                var index = GameComponentsLookup.Vehicle;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : vehicleComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVehicle;

    public static Entitas.IMatcher<GameEntity> Vehicle {
        get {
            if (_matcherVehicle == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Vehicle);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVehicle = matcher;
            }

            return _matcherVehicle;
        }
    }
}
