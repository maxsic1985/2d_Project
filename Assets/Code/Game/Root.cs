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

    private Controllers _controllers;
    private ParalaxController _paralaxManager;
    private SpriteAnimatorController _spriteAnimator;

    private void Start()
    {
        _controllers = new Controllers();
        _controllers.Initialization();
        new GameInitialisation(_controllers,_camera,_background.transform,_spriteAnimationConfig,_characterView);
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
