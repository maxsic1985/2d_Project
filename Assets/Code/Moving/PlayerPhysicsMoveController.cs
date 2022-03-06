using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsMoveController : IFixedExecute
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private PlayerProvider _characterView;
    private SpriteAnimatorController _spriteAnimator;
    private ContactsPoller _contactsPoller;

    public PlayerPhysicsMoveController(PlayerProvider characterView, SpriteAnimatorController spriteAnimator)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;

        _contactsPoller = new ContactsPoller(characterView.Collider);
    }

    public void FixedExecute(float fixedDeltaTime)
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        var doJump = Input.GetAxis(Vertical) > 0;
        var xAxisInput = Input.GetAxis(Horizontal);

        _contactsPoller.Update();

        var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.PlayerMoveTresh;

        if (isGoSideWay)
            _characterView.SpriteRenderer.flipX = xAxisInput < 0;

        var newVelocity = 0f;

        if (isGoSideWay &&
            (xAxisInput > 0 || !_contactsPoller.HasLeftContacts) &&
            (xAxisInput < 0 || !_contactsPoller.HasRightContacts))
        {
            newVelocity = Time.fixedDeltaTime * _characterView.PlayerWalkSpeed * (xAxisInput < 0 ? -1 : 1);
        }

        _characterView.Rigidbody.velocity = _characterView.Rigidbody.velocity.Change(x: newVelocity);

        if (_contactsPoller.IsGrounded && doJump && Mathf.Abs(_characterView.Rigidbody.velocity.y) <= _characterView.PlayerFlyTresh)
            _characterView.Rigidbody.AddForce(Vector2.up * _characterView.PlayerJumpStartSpeed);

        if (_contactsPoller.IsGrounded)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? AnimationType.WALK : AnimationType.IDLE, true,
                EntityData.GameSetting._playerAnimationSpeed);
        }
        else if (Mathf.Abs(_characterView.Rigidbody.velocity.y) > _characterView.PlayerFlyTresh)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, AnimationType.JUMP, true,
                EntityData.GameSetting._playerAnimationSpeed);
        }
    }
}
