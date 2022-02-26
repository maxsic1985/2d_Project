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

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);

        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, AnimationType.IDLE, true, EntityData.GameSetting._animationSpeed);
    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
    }

    private void FixedUpdate()
    {

    }

    private void OnDestroy()
    {

    }
}
