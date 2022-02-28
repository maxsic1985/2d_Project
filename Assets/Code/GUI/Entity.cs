using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Entity 
{
    public float _playerAnimationSpeed;
    public float _parallaxSpeed;
    public float _playerAnimationSpeed_max;
    public float _parallaxSpeed_max;
    public float _playerMovingTresh;
    public float _playerWalkSpeed;
    public float  _jumpStartSpeed;
    public float _flyTresh;
    public float _groundLevel;
    public float _playerAcceleration;

    public Entity(float animationSpeed, float parallaxSpeed, float animationSpeed_max, float parallaxSpeed_max, float playerMovingTresh, float playerWalkSpeed, float jumpStartSpeed, float flyTresh, float groundLevel, float acceleration)
    {
        _playerAnimationSpeed = animationSpeed;
        _parallaxSpeed = parallaxSpeed;
        _playerAnimationSpeed_max = animationSpeed_max;
        _parallaxSpeed_max = parallaxSpeed_max;
        _playerMovingTresh = playerMovingTresh;
        _playerWalkSpeed = playerWalkSpeed;
        _jumpStartSpeed = jumpStartSpeed;
        _flyTresh = flyTresh;
        _groundLevel = groundLevel;
        _playerAcceleration = acceleration;
    }
}
