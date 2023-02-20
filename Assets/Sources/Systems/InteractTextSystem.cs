using Entitas;
using System.Collections.Generic;

public class InteractTextSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public InteractTextSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.InteractText);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasInteractText;
    }

    protected override void Execute(List<GameEntity> entites)
    {
        foreach (var entity in entites) 
        {
            if(InteractTextHasNoValue(entity))
                SetInteractText(entity);
            if (DoesPlayerInitialized(entity) && InteractTextHasNoTarget(entity))
                entity.ReplaceInteractText(entity.interactText.value, _contexts.game.mainCamera.value.transform);
        }

    }

    private void SetInteractText(GameEntity entity)
    {
        var linkedGameObject = entity.view.value;
        var interactText = linkedGameObject.GetComponent<InteractText>().InteractTextMeshProUGUI;
        entity.ReplaceInteractText(interactText,_contexts.game.mainCamera.value);
    }

    private bool InteractTextHasNoValue(GameEntity entity)
    {
        return entity.interactText == null;
    }

    private bool InteractTextHasNoTarget(GameEntity entity)
    {
        return entity.interactText.lookTarget == null;
    }

    private bool DoesPlayerInitialized(GameEntity entity)
    {
        return _contexts.game.playerEntity != null;
    }
}
