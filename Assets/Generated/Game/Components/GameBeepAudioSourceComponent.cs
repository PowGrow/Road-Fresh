//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BeepAudioSourceComponent beepAudioSource { get { return (BeepAudioSourceComponent)GetComponent(GameComponentsLookup.BeepAudioSource); } }
    public bool hasBeepAudioSource { get { return HasComponent(GameComponentsLookup.BeepAudioSource); } }

    public void AddBeepAudioSource(UnityEngine.AudioSource newValue) {
        var index = GameComponentsLookup.BeepAudioSource;
        var component = (BeepAudioSourceComponent)CreateComponent(index, typeof(BeepAudioSourceComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceBeepAudioSource(UnityEngine.AudioSource newValue) {
        var index = GameComponentsLookup.BeepAudioSource;
        var component = (BeepAudioSourceComponent)CreateComponent(index, typeof(BeepAudioSourceComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBeepAudioSource() {
        RemoveComponent(GameComponentsLookup.BeepAudioSource);
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

    static Entitas.IMatcher<GameEntity> _matcherBeepAudioSource;

    public static Entitas.IMatcher<GameEntity> BeepAudioSource {
        get {
            if (_matcherBeepAudioSource == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BeepAudioSource);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBeepAudioSource = matcher;
            }

            return _matcherBeepAudioSource;
        }
    }
}
