//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using RoadFresh.View.UI;

public partial class GameContext {

    public GameEntity gameUIEntity { get { return GetGroup(GameMatcher.GameUI).GetSingleEntity(); } }
    public GameUIComponent gameUI { get { return gameUIEntity.gameUI; } }
    public bool hasGameUI { get { return gameUIEntity != null; } }

    public GameEntity SetGameUI(GameUI newValue) {
        if (hasGameUI) {
            throw new Entitas.EntitasException("Could not set GameUI!\n" + this + " already has an entity with GameUIComponent!",
                "You should check if the context already has a gameUIEntity before setting it or use context.ReplaceGameUI().");
        }
        var entity = CreateEntity();
        entity.AddGameUI(newValue);
        return entity;
    }

    public void ReplaceGameUI(GameUI newValue) {
        var entity = gameUIEntity;
        if (entity == null) {
            entity = SetGameUI(newValue);
        } else {
            entity.ReplaceGameUI(newValue);
        }
    }

    public void RemoveGameUI() {
        gameUIEntity.Destroy();
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

    public GameUIComponent gameUI { get { return (GameUIComponent)GetComponent(GameComponentsLookup.GameUI); } }
    public bool hasGameUI { get { return HasComponent(GameComponentsLookup.GameUI); } }

    public void AddGameUI(GameUI newValue) {
        var index = GameComponentsLookup.GameUI;
        var component = (GameUIComponent)CreateComponent(index, typeof(GameUIComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameUI(GameUI newValue) {
        var index = GameComponentsLookup.GameUI;
        var component = (GameUIComponent)CreateComponent(index, typeof(GameUIComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameUI() {
        RemoveComponent(GameComponentsLookup.GameUI);
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

    static Entitas.IMatcher<GameEntity> _matcherGameUI;

    public static Entitas.IMatcher<GameEntity> GameUI {
        get {
            if (_matcherGameUI == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameUI);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameUI = matcher;
            }

            return _matcherGameUI;
        }
    }
}
