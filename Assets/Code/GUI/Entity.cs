using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Entity 
{
    public float _animationSpeed;
    public float _parallaxSpeed;
    public float _animationSpeed_max;
    public float _parallaxSpeed_max;
   
    public Entity(float animationSpeed, float parallaxSpeed, float animationSpeed_max, float parallaxSpeed_max) 
    {
        _animationSpeed = animationSpeed;
        _parallaxSpeed = parallaxSpeed;
        _animationSpeed_max = animationSpeed_max;
        _parallaxSpeed_max = parallaxSpeed_max;
    }
}
