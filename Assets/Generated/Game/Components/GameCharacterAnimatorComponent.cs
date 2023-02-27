//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CharacterAnimatorComponent characterAnimator { get { return (CharacterAnimatorComponent)GetComponent(GameComponentsLookup.CharacterAnimator); } }
    public bool hasCharacterAnimator { get { return HasComponent(GameComponentsLookup.CharacterAnimator); } }

    public void AddCharacterAnimator(UnityEngine.Animator newValue) {
        var index = GameComponentsLookup.CharacterAnimator;
        var component = (CharacterAnimatorComponent)CreateComponent(index, typeof(CharacterAnimatorComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCharacterAnimator(UnityEngine.Animator newValue) {
        var index = GameComponentsLookup.CharacterAnimator;
        var component = (CharacterAnimatorComponent)CreateComponent(index, typeof(CharacterAnimatorComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCharacterAnimator() {
        RemoveComponent(GameComponentsLookup.CharacterAnimator);
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

    static Entitas.IMatcher<GameEntity> _matcherCharacterAnimator;

    public static Entitas.IMatcher<GameEntity> CharacterAnimator {
        get {
            if (_matcherCharacterAnimator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CharacterAnimator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCharacterAnimator = matcher;
            }

            return _matcherCharacterAnimator;
        }
    }
}
