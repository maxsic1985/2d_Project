using UnityEngine;

public class PlayerMoveController : IExecute
{
    private float _yVelocity;
    private PlayerProvider _characterView;
    private SpriteAnimatorController _spriteAnimator;
    public PlayerMoveController(PlayerProvider characterView, SpriteAnimatorController spriteAnimator)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;
    }
    public void Execute(float deltaTime)
    {
        var doJump = Input.GetAxis(GameConstants.Vertical) > 0;
        var xAxisInput = Input.GetAxis(GameConstants.Horizontal);

        var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.PlayerMoveTresh;

        if (isGoSideWay)
            GoSideWay(xAxisInput);

        if (IsGrounded())
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? AnimationType.WALK : AnimationType.IDLE, true, EntityData.GameSetting._playerAnimationSpeed);

            if (doJump && Mathf.Approximately(_yVelocity, 0))
            {
                _yVelocity = _characterView.PlayerJumpStartSpeed;
            }
            else if (_yVelocity < 0)
            {
                _yVelocity = 0;
                MovementCharacter();
            }
        }
        else
        {
            LandingCharater();
        }
    }
    private void LandingCharater()
    {
        _yVelocity += _characterView.PlayerAcceleration * Time.deltaTime;

        if (Mathf.Abs(_yVelocity) > _characterView.PlayerFlyTresh)
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, AnimationType.JUMP, true, EntityData.GameSetting._playerAnimationSpeed);

        _characterView.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
    }
    private void MovementCharacter()
    {
        _characterView.transform.position = _characterView.transform.position.Change(y: _characterView.PlayerGroundLevel);

    }
    private bool IsGrounded()
    {
        return _characterView.transform.position.y <= _characterView.PlayerGroundLevel && _yVelocity <= 0;
    }
    private void GoSideWay(float xAxisInput)
    {

        _characterView.transform.position += Vector3.right * (Time.deltaTime * _characterView.PlayerWalkSpeed * (xAxisInput < 0 ? -1 : 1));
        _characterView.SpriteRenderer.flipX = xAxisInput < 0;
        var bg = GameObject.FindObjectOfType<BackGroundController>();
        bg.MoveBackGround(_characterView.transform);
    }
}
