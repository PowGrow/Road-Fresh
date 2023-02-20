//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public RiderLeftArmPositionComponent riderLeftArmPosition { get { return (RiderLeftArmPositionComponent)GetComponent(GameComponentsLookup.RiderLeftArmPosition); } }
    public bool hasRiderLeftArmPosition { get { return HasComponent(GameComponentsLookup.RiderLeftArmPosition); } }

    public void AddRiderLeftArmPosition(UnityEngine.Transform newValue, UnityEngine.Animations.Rigging.TwoBoneIKConstraint newConstraint) {
        var index = GameComponentsLookup.RiderLeftArmPosition;
        var component = (RiderLeftArmPositionComponent)CreateComponent(index, typeof(RiderLeftArmPositionComponent));
        component.value = newValue;
        component.constraint = newConstraint;
        AddComponent(index, component);
    }

    public void ReplaceRiderLeftArmPosition(UnityEngine.Transform newValue, UnityEngine.Animations.Rigging.TwoBoneIKConstraint newConstraint) {
        var index = GameComponentsLookup.RiderLeftArmPosition;
        var component = (RiderLeftArmPositionComponent)CreateComponent(index, typeof(RiderLeftArmPositionComponent));
        component.value = newValue;
        component.constraint = newConstraint;
        ReplaceComponent(index, component);
    }

    public void RemoveRiderLeftArmPosition() {
        RemoveComponent(GameComponentsLookup.RiderLeftArmPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherRiderLeftArmPosition;

    public static Entitas.IMatcher<GameEntity> RiderLeftArmPosition {
        get {
            if (_matcherRiderLeftArmPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RiderLeftArmPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRiderLeftArmPosition = matcher;
            }

            return _matcherRiderLeftArmPosition;
        }
    }
}
