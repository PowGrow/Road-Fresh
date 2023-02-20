//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MountPositionComponent mountPosition { get { return (MountPositionComponent)GetComponent(GameComponentsLookup.MountPosition); } }
    public bool hasMountPosition { get { return HasComponent(GameComponentsLookup.MountPosition); } }

    public void AddMountPosition(UnityEngine.Transform newValue) {
        var index = GameComponentsLookup.MountPosition;
        var component = (MountPositionComponent)CreateComponent(index, typeof(MountPositionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMountPosition(UnityEngine.Transform newValue) {
        var index = GameComponentsLookup.MountPosition;
        var component = (MountPositionComponent)CreateComponent(index, typeof(MountPositionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMountPosition() {
        RemoveComponent(GameComponentsLookup.MountPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherMountPosition;

    public static Entitas.IMatcher<GameEntity> MountPosition {
        get {
            if (_matcherMountPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MountPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMountPosition = matcher;
            }

            return _matcherMountPosition;
        }
    }
}