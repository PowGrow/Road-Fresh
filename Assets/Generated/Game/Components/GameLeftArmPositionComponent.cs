//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LeftArmPositionComponent leftArmPosition { get { return (LeftArmPositionComponent)GetComponent(GameComponentsLookup.LeftArmPosition); } }
    public bool hasLeftArmPosition { get { return HasComponent(GameComponentsLookup.LeftArmPosition); } }

    public void AddLeftArmPosition(UnityEngine.Transform newValue) {
        var index = GameComponentsLookup.LeftArmPosition;
        var component = (LeftArmPositionComponent)CreateComponent(index, typeof(LeftArmPositionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLeftArmPosition(UnityEngine.Transform newValue) {
        var index = GameComponentsLookup.LeftArmPosition;
        var component = (LeftArmPositionComponent)CreateComponent(index, typeof(LeftArmPositionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLeftArmPosition() {
        RemoveComponent(GameComponentsLookup.LeftArmPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherLeftArmPosition;

    public static Entitas.IMatcher<GameEntity> LeftArmPosition {
        get {
            if (_matcherLeftArmPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LeftArmPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLeftArmPosition = matcher;
            }

            return _matcherLeftArmPosition;
        }
    }
}