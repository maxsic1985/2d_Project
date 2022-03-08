using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : IExecute
{
    private const float _delay = 3;
    private const float _startSpeed = 5;

    private List<PhysicsBullet> _bullets = new List<PhysicsBullet>();
    private Transform _bulletStartPosition;

    private int _currentIndex;
    private float _timeTillNextBullet;

    public BulletController(List<BulletProvider> bullets, Transform bulletStartPosition)
    {
        _bulletStartPosition = bulletStartPosition;

        foreach (var bulletView in bullets)
            _bullets.Add(new PhysicsBullet(bulletView));
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
            _bullets[_currentIndex].Throw(_bulletStartPosition.position,  _bulletStartPosition.up * _startSpeed);
            _currentIndex++;

            if (_currentIndex >= _bullets.Count)
                _currentIndex = 0;
        }

        _bullets.ForEach(b => b.Update());
    }
}

