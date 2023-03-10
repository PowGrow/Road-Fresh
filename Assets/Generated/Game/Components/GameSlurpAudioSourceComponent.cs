//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SlurpAudioSourceComponent slurpAudioSource { get { return (SlurpAudioSourceComponent)GetComponent(GameComponentsLookup.SlurpAudioSource); } }
    public bool hasSlurpAudioSource { get { return HasComponent(GameComponentsLookup.SlurpAudioSource); } }

    public void AddSlurpAudioSource(UnityEngine.AudioSource newValue) {
        var index = GameComponentsLookup.SlurpAudioSource;
        var component = (SlurpAudioSourceComponent)CreateComponent(index, typeof(SlurpAudioSourceComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSlurpAudioSource(UnityEngine.AudioSource newValue) {
        var index = GameComponentsLookup.SlurpAudioSource;
        var component = (SlurpAudioSourceComponent)CreateComponent(index, typeof(SlurpAudioSourceComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSlurpAudioSource() {
        RemoveComponent(GameComponentsLookup.SlurpAudioSource);
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

    static Entitas.IMatcher<GameEntity> _matcherSlurpAudioSource;

    public static Entitas.IMatcher<GameEntity> SlurpAudioSource {
        get {
            if (_matcherSlurpAudioSource == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SlurpAudioSource);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSlurpAudioSource = matcher;
            }

            return _matcherSlurpAudioSource;
        }
    }
}
