using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimatorController:IExecute
{
    private ICongig<SpriteSequence> _config;
    private Dictionary<SpriteRenderer, CustomAnimation> _activeAnimations = new Dictionary<SpriteRenderer, CustomAnimation>();

    public SpriteAnimatorController(ICongig<SpriteSequence> config)
    {
        _config = config;
    }
    public void StartAnimation(SpriteRenderer spriteRenderer, AnimationType type, bool loop, float speed)
    {
        if (_activeAnimations.TryGetValue(spriteRenderer, out var custom_animation))
        {
            custom_animation.Loop = loop;
            custom_animation.AnimationSpeed = speed;
            custom_animation.Sleeps = false;

            if (custom_animation.AnimType == type)
                return;

            custom_animation.AnimType = type;
            custom_animation.Sprites = _config.Sequences.Find(sequence => sequence.AnimationType == type).Sprites;
            custom_animation.Counter = 0;
        }
        else
        {
            _activeAnimations.Add(spriteRenderer, new CustomAnimation
            {
                AnimType = type,
                Sprites = _config.Sequences.Find(sequence => sequence.AnimationType == type).Sprites,
                Loop = loop,
                AnimationSpeed = speed
            });
        }
    }
    public void StopAnimation(SpriteRenderer sprite)
    {
        if (_activeAnimations.ContainsKey(sprite))
            _activeAnimations.Remove(sprite);
    }
    public void Dispose()
    {
        _activeAnimations.Clear();
    }
    public void Execute(float deltaTime)
    {
        foreach (var animation in _activeAnimations)
        {
             animation.Value.Update();
            animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
        }
    }
}
