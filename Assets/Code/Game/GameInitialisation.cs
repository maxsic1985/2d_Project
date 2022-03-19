using Pathfinding;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInitialisation
{
    private Controllers _controllers;



    public GameInitialisation(Controllers controllers,
                              Camera camera,
                              Transform background,
                              ICongig<SpriteSequence> spriteAnimationConfig,
                              PlayerProvider characterView,
                              List<CannonProvider> cannon,
                              GameObject bullets,
                              List<LevelObjectView> coins,
                              List<LevelObjectView> winZones,
                              List<LevelObjectView> deathZone,
                              Text coinsText,
                              Image[] playerLives,
                              AIDestinationSetter aIDestinationSetter,
                              AIPatrolPath aIPatrolPath,
                              LevelObjectTrigger levelObjectTrigger,
                              Transform[] protectorWaypoints)
    {
        _controllers = controllers;


        var paralaxManager = new ParalaxController(camera, background.transform);
        var spriteAnimator = new SpriteAnimatorController(spriteAnimationConfig);
        characterView.gameObject.TryGetComponent<BackGroundController>(out BackGroundController groundController);
        var playerMoveController = new PlayerPhysicsMoveController(characterView, spriteAnimator, groundController);
        var cannonAim = new CannonAimmingController(cannon, characterView.transform);
        var bulletPool = new ObjectPool(bullets, GameConstants.BULLET_POOL_LENGHT);
        var bulletController = new BulletController(bulletPool, cannon);
        var coinsPool = new ObjectPool(coins[0].gameObject, GameConstants.COINS_POOL_LENGHT);
        var coinsController = new CoinsController(characterView, coinsPool, new CoinsDisplay(coinsText));
        var playerLiveDisplay = new PlayerLiveDisplay(playerLives);
        var levelZone = new LevelCompleteController(characterView, deathZone, winZones, playerLiveDisplay);
        spriteAnimator.StartAnimation(characterView.SpriteRenderer, AnimationType.IDLE, true, EntityData.GameSetting._playerAnimationSpeed);

        //AI
        var _protectorAI = new ProtectorAI(characterView, new PatrolAIModel(protectorWaypoints), aIDestinationSetter, aIPatrolPath);
        _protectorAI.Init();
        var _protectedZone = new ProtectedZone(levelObjectTrigger, new List<IProtector> { _protectorAI });
        _protectedZone.Init();

        _controllers.Add(paralaxManager);
        _controllers.Add(spriteAnimator);
        _controllers.Add(playerMoveController);
        _controllers.Add(cannonAim);
        _controllers.Add(bulletController);
        _controllers.Add(coinsController);
        _controllers.Add(levelZone);





    }
}
