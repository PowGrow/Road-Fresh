//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameControllerEntity { get { return GetGroup(GameMatcher.GameController).GetSingleEntity(); } }
    public GameControllerComponent gameController { get { return gameControllerEntity.gameController; } }
    public bool hasGameController { get { return gameControllerEntity != null; } }

    public GameEntity SetGameController(GameController newValue) {
        if (hasGameController) {
            throw new Entitas.EntitasException("Could not set GameController!\n" + this + " already has an entity with GameControllerComponent!",
                "You should check if the context already has a gameControllerEntity before setting it or use context.ReplaceGameController().");
        }
        var entity = CreateEntity();
        entity.AddGameController(newValue);
        return entity;
    }

    public void ReplaceGameController(GameController newValue) {
        var entity = gameControllerEntity;
        if (entity == null) {
            entity = SetGameController(newValue);
        } else {
            entity.ReplaceGameController(newValue);
        }
    }

    public void RemoveGameController() {
        gameControllerEntity.Destroy();
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

    public GameControllerComponent gameController { get { return (GameControllerComponent)GetComponent(GameComponentsLookup.GameController); } }
    public bool hasGameController { get { return HasComponent(GameComponentsLookup.GameController); } }

    public void AddGameController(GameController newValue) {
        var index = GameComponentsLookup.GameController;
        var component = (GameControllerComponent)CreateComponent(index, typeof(GameControllerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameController(GameController newValue) {
        var index = GameComponentsLookup.GameController;
        var component = (GameControllerComponent)CreateComponent(index, typeof(GameControllerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameController() {
        RemoveComponent(GameComponentsLookup.GameController);
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

    static Entitas.IMatcher<GameEntity> _matcherGameController;

    public static Entitas.IMatcher<GameEntity> GameController {
        get {
            if (_matcherGameController == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameController);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameController = matcher;
            }

            return _matcherGameController;
        }
    }
}
