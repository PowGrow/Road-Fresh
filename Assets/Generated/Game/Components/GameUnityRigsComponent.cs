//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UnityRigsComponent unityRigs { get { return (UnityRigsComponent)GetComponent(GameComponentsLookup.UnityRigs); } }
    public bool hasUnityRigs { get { return HasComponent(GameComponentsLookup.UnityRigs); } }

    public void AddUnityRigs(UnityRigs newValue) {
        var index = GameComponentsLookup.UnityRigs;
        var component = (UnityRigsComponent)CreateComponent(index, typeof(UnityRigsComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUnityRigs(UnityRigs newValue) {
        var index = GameComponentsLookup.UnityRigs;
        var component = (UnityRigsComponent)CreateComponent(index, typeof(UnityRigsComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUnityRigs() {
        RemoveComponent(GameComponentsLookup.UnityRigs);
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

    static Entitas.IMatcher<GameEntity> _matcherUnityRigs;

    public static Entitas.IMatcher<GameEntity> UnityRigs {
        get {
            if (_matcherUnityRigs == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UnityRigs);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUnityRigs = matcher;
            }

            return _matcherUnityRigs;
        }
    }
}