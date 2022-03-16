using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinsController : IDisposable, IExecute
{

    private PlayerProvider _characterView;
    private List<LevelObjectView> _coinViews = new List<LevelObjectView>();
    private ObjectPool _coinsPool;
    private GameObject _coin;
    public CoinsController(PlayerProvider characterView, ObjectPool coinsPool)
    {
        _characterView = characterView;
        _coinsPool = coinsPool;
         GenerateCOins();
        _characterView.OnLevelObjectContact += OnLevelObjectContact;

    }
    private void OnLevelObjectContact(LevelObjectView contactView)
    {
        if (_coinViews.Contains(contactView))
        {
            _coinsPool.Push(contactView.gameObject);
            _coinViews.Remove(contactView);
        }
    }
    public void Dispose()
    {
        _characterView.OnLevelObjectContact -= OnLevelObjectContact;
    }

    public void Execute(float deltaTime)
    {
        if (_coinViews.Count == 0)
            GenerateCOins();
    }

    private void GenerateCOins()
    {
        for (int i = 0; i < _coinsPool.PoolCnt; i++)
        {

            _coin = _coinsPool.Pop();

            _coinViews.Add(_coin.GetComponent<LevelObjectView>());
            _coinViews[i].transform.position = _characterView.transform.position.Change(x: _characterView.transform.position.x * 2 + i,y: _characterView.transform.position.y);
        }


    }
}
