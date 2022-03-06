using System.Collections.Generic;
using UnityEngine;

public class GameInitialisation
{
    private Controllers _controllers;

    public GameInitialisation(Controllers controllers,Camera camera, Transform background,ICongig<SpriteSequence> spriteAnimationConfig,PlayerProvider characterView,
        CannonProvider cannon,List<BulletProvider> bullets)
    {
        _controllers = controllers;

        var paralaxManager = new ParalaxController(camera, background.transform);
        var spriteAnimator = new SpriteAnimatorController(spriteAnimationConfig);
       // var playerMoveController = new PlayerMoveController(characterView, spriteAnimator);
        var playerMoveController = new PlayerPhysicsMoveController(characterView, spriteAnimator);
        var cannonAim = new CannonAimmingController(cannon.transform, characterView.transform);
        var bulletController = new BulletController(bullets, cannon.CannonTransform);
        spriteAnimator.StartAnimation(characterView.SpriteRenderer, AnimationType.IDLE, true, EntityData.GameSetting._playerAnimationSpeed);

        _controllers.Add(paralaxManager);
        _controllers.Add(spriteAnimator);
        _controllers.Add(playerMoveController);
        _controllers.Add(cannonAim);
        _controllers.Add(bulletController);



    }
}
