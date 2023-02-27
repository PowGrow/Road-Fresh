//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ObastacleCollisionComponent obastacleCollision { get { return (ObastacleCollisionComponent)GetComponent(GameComponentsLookup.ObastacleCollision); } }
    public bool hasObastacleCollision { get { return HasComponent(GameComponentsLookup.ObastacleCollision); } }

    public void AddObastacleCollision(UnityEngine.GameObject newCollisionObject, UnityEngine.GameObject newCollisionSource) {
        var index = GameComponentsLookup.ObastacleCollision;
        var component = (ObastacleCollisionComponent)CreateComponent(index, typeof(ObastacleCollisionComponent));
        component.collisionObject = newCollisionObject;
        component.collisionSource = newCollisionSource;
        AddComponent(index, component);
    }

    public void ReplaceObastacleCollision(UnityEngine.GameObject newCollisionObject, UnityEngine.GameObject newCollisionSource) {
        var index = GameComponentsLookup.ObastacleCollision;
        var component = (ObastacleCollisionComponent)CreateComponent(index, typeof(ObastacleCollisionComponent));
        component.collisionObject = newCollisionObject;
        component.collisionSource = newCollisionSource;
        ReplaceComponent(index, component);
    }

    public void RemoveObastacleCollision() {
        RemoveComponent(GameComponentsLookup.ObastacleCollision);
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

    static Entitas.IMatcher<GameEntity> _matcherObastacleCollision;

    public static Entitas.IMatcher<GameEntity> ObastacleCollision {
        get {
            if (_matcherObastacleCollision == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ObastacleCollision);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherObastacleCollision = matcher;
            }

            return _matcherObastacleCollision;
        }
    }
}
