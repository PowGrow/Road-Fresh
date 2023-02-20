//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UnmountPositionComponent unmountPosition { get { return (UnmountPositionComponent)GetComponent(GameComponentsLookup.UnmountPosition); } }
    public bool hasUnmountPosition { get { return HasComponent(GameComponentsLookup.UnmountPosition); } }

    public void AddUnmountPosition(UnityEngine.Transform newValue) {
        var index = GameComponentsLookup.UnmountPosition;
        var component = (UnmountPositionComponent)CreateComponent(index, typeof(UnmountPositionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUnmountPosition(UnityEngine.Transform newValue) {
        var index = GameComponentsLookup.UnmountPosition;
        var component = (UnmountPositionComponent)CreateComponent(index, typeof(UnmountPositionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUnmountPosition() {
        RemoveComponent(GameComponentsLookup.UnmountPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherUnmountPosition;

    public static Entitas.IMatcher<GameEntity> UnmountPosition {
        get {
            if (_matcherUnmountPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UnmountPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUnmountPosition = matcher;
            }

            return _matcherUnmountPosition;
        }
    }
}
