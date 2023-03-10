//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity strafeInputEntity { get { return GetGroup(GameMatcher.StrafeInput).GetSingleEntity(); } }
    public StrafeInputComponent strafeInput { get { return strafeInputEntity.strafeInput; } }
    public bool hasStrafeInput { get { return strafeInputEntity != null; } }

    public GameEntity SetStrafeInput(float newValue) {
        if (hasStrafeInput) {
            throw new Entitas.EntitasException("Could not set StrafeInput!\n" + this + " already has an entity with StrafeInputComponent!",
                "You should check if the context already has a strafeInputEntity before setting it or use context.ReplaceStrafeInput().");
        }
        var entity = CreateEntity();
        entity.AddStrafeInput(newValue);
        return entity;
    }

    public void ReplaceStrafeInput(float newValue) {
        var entity = strafeInputEntity;
        if (entity == null) {
            entity = SetStrafeInput(newValue);
        } else {
            entity.ReplaceStrafeInput(newValue);
        }
    }

    public void RemoveStrafeInput() {
        strafeInputEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public StrafeInputComponent strafeInput { get { return (StrafeInputComponent)GetComponent(GameComponentsLookup.StrafeInput); } }
    public bool hasStrafeInput { get { return HasComponent(GameComponentsLookup.StrafeInput); } }

    public void AddStrafeInput(float newValue) {
        var index = GameComponentsLookup.StrafeInput;
        var component = (StrafeInputComponent)CreateComponent(index, typeof(StrafeInputComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceStrafeInput(float newValue) {
        var index = GameComponentsLookup.StrafeInput;
        var component = (StrafeInputComponent)CreateComponent(index, typeof(StrafeInputComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveStrafeInput() {
        RemoveComponent(GameComponentsLookup.StrafeInput);
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

    static Entitas.IMatcher<GameEntity> _matcherStrafeInput;

    public static Entitas.IMatcher<GameEntity> StrafeInput {
        get {
            if (_matcherStrafeInput == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StrafeInput);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStrafeInput = matcher;
            }

            return _matcherStrafeInput;
        }
    }
}
