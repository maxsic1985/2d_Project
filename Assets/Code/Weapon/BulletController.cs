using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletController : IExecute
{
    private List<BulletProvider> _bullets = new List<BulletProvider>();
    private List<CannonProvider> _gunsOnSceene = new List<CannonProvider>();
    private int _currentIndex = 0;
    private float _timeTillNextBullet = 2;
    private readonly ObjectPool _bulletPool;
    private readonly PlayerProvider _playerProvider;
    private float _shootDistance;
    private Dictionary<CannonProvider, float> _gunsDictionary = new Dictionary<CannonProvider, float>();
    public BulletController(ObjectPool bulletPool, List<CannonProvider> guns)
    {
        _playerProvider = GameObject.FindObjectOfType<PlayerProvider>();
        _gunsOnSceene = guns;
        _bulletPool = bulletPool;
        _bullets = new List<BulletProvider>();
        _shootDistance = Mathf.Round(Extenshion.GetCameraWeight(Camera.main).weight);

    }
    public void Execute(float deltaTime)
    {
        Shooting();
        RetoornToPool();
    }
    private void Shooting()
    {
        if (_timeTillNextBullet > 0)
        {
            _timeTillNextBullet -= Time.deltaTime;
        }
        else
        {
            if (Vector2.Distance(GetCurrentCannonStartPosition().position, _playerProvider.transform.position) > _shootDistance) return;
            var bullet = _bulletPool.Pop();
            _bullets.Add(bullet.GetComponent<BulletProvider>());
            _timeTillNextBullet = bullet.GetComponent<BulletProvider>().ShootDelay;
            bullet.GetComponent<BulletProvider>().transform.position = GetCurrentCannonStartPosition().position;
            bullet.GetComponent<BulletProvider>().Rigidbody2D.AddForce(GetCurrentCannonStartPosition().up * _bullets[_currentIndex].StartSpeed, ForceMode2D.Impulse);
        }
    }
    private void RetoornToPool()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (Vector2.Distance(_bullets[i].transform.position, _playerProvider.transform.position) > _shootDistance)
            {
                _bulletPool.Push(_bullets[i].gameObject);
                _bullets.RemoveAt(i);
            }
        }
    }
    private Transform GetCurrentCannonStartPosition()
    {

        for (int i = 0; i < _gunsOnSceene.Count; i++)
        {
            var distanse = Vector2.Distance(_playerProvider.transform.position, _gunsOnSceene[i].transform.position);
            if (_gunsDictionary.ContainsKey(_gunsOnSceene[i])) _gunsDictionary[_gunsOnSceene[i]] = distanse;
            else _gunsDictionary.Add(_gunsOnSceene[i], distanse);
        }
        _gunsDictionary = _gunsDictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        var result = _gunsDictionary.First();
        return result.Key.CannonTransform;
    }
}

