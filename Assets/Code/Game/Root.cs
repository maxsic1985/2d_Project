using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private SpriteRenderer _background;

    [SerializeField]
    private PlayerProvider _characterView;

    [SerializeField]
    private SpriteAnimationConfig _spriteAnimationConfig;

    [SerializeField]
    private List<CannonProvider> _cannonTransform=new List<CannonProvider>();

    [SerializeField]
    private GameObject _bullets;

    [SerializeField]
    private List<LevelObjectView> _coins;
    [SerializeField]
    private List<LevelObjectView> _deathZones;
    [SerializeField]
    private List<LevelObjectView> _winZones;


    private Controllers _controllers;
    private ParalaxController _paralaxManager;
    private SpriteAnimatorController _spriteAnimator;

    private void Start()
    {
        _controllers = new Controllers();

        new GameInitialisation(_controllers, _camera, _background.transform, _spriteAnimationConfig, _characterView,
            _cannonTransform, _bullets, _coins, _winZones, _deathZones);
        _controllers.Initialization();
    }

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        _controllers.Execute(deltaTime);
    }

    private void FixedUpdate()
    {
        _controllers.FixedExecute(Time.fixedDeltaTime);
    }



    private void OnDestroy()
    {
        _controllers.Cleanup();
    }

}
