using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : IExecute
{
    private const float _delay = 1;
    private const float _startSpeed = 5;

    private List<Bullet> _bullets = new List<Bullet>();
    private Transform _transform;

    private int _currentIndex;
    private float _timeTillNextBullet;

    public BulletController(List<BulletProvider> bullets, Transform transform)
    {
        _transform = transform;

        foreach (var bulletView in bullets)
            _bullets.Add(new Bullet(bulletView));
    }

    public void Execute(float deltaTime)
    {
        if (_timeTillNextBullet > 0)
        {
            _timeTillNextBullet -= Time.deltaTime;
        }
        else
        {
            _timeTillNextBullet = _delay;
            _bullets[_currentIndex].Throw(_transform.position, _transform.up * _startSpeed);
            _currentIndex++;

            if (_currentIndex >= _bullets.Count)
                _currentIndex = 0;
        }

        _bullets.ForEach(b => b.Update());
    }
}

