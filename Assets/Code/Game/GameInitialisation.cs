using UnityEngine;

public class GameInitialisation
{
    private Controllers _controllers;

    public GameInitialisation(Controllers controllers,Camera camera, Transform background,ICongig<SpriteSequence> spriteAnimationConfig,PlayerProvider characterView,Transform cannonTransform)
    {
        _controllers = controllers;

        var paralaxManager = new ParalaxController(camera, background.transform);
        var spriteAnimator = new SpriteAnimatorController(spriteAnimationConfig);
        var playerMoveController = new PlayerMoveController(characterView, spriteAnimator);
        var cannonAim = new CannonAimmingController(cannonTransform.transform, characterView.transform);
        spriteAnimator.StartAnimation(characterView.SpriteRenderer, AnimationType.IDLE, true, EntityData.GameSetting._playerAnimationSpeed);

        _controllers.Add(paralaxManager);
        _controllers.Add(spriteAnimator);
        _controllers.Add(playerMoveController);
        _controllers.Add(cannonAim);


    }
}
