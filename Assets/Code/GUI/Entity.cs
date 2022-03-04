using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Entity 
{
    public float _playerAnimationSpeed;
    public float _parallaxSpeed;
    public float _playerAnimationSpeed_max;
    public float _parallaxSpeed_max;

    public Entity(float playerAnimationSpeed, float parallaxSpeed, float playerAnimationSpeed_max, float parallaxSpeed_max)
    {
        _playerAnimationSpeed = playerAnimationSpeed;
        _parallaxSpeed = parallaxSpeed;
        _playerAnimationSpeed_max = playerAnimationSpeed_max;
        _parallaxSpeed_max = parallaxSpeed_max;
    }
}
