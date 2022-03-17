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
    CoinsDisplay _coinsDisplay;
    public CoinsController(PlayerProvider characterView, ObjectPool coinsPool,CoinsDisplay coinsDisplay)
    {
        _characterView = characterView;
        _coinsPool = coinsPool;
         GenerateCOins();
        _characterView.OnLevelObjectContact += OnLevelObjectContact;
        _coinsDisplay = coinsDisplay;
    }
    private void OnLevelObjectContact(LevelObjectView contactView)
    {
        if (_coinViews.Contains(contactView))
        {
            _coinsPool.Push(contactView.gameObject);
            _coinViews.Remove(contactView);
            _characterView.PlayerCoins += 1;
            _coinsDisplay.UpdateScore(_characterView.PlayerCoins);
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
        ClearCoinsList();

        for (int i = 0; i < _coinsPool.PoolCnt; i++)
        {
            _coin = _coinsPool.Pop();
            _coinViews.Add(_coin.GetComponent<LevelObjectView>());
            _coinViews[i].transform.position = _characterView.transform.position.Change(x: _characterView.transform.position.x * 2 + i, y: _characterView.transform.position.y);
        }


    }

    private void ClearCoinsList()
    {
        for (int i = 0; i < _coinViews.Count; i++)
        {
            _coinsPool.Push(_coinViews[i].gameObject);
            _coinViews.RemoveAt(i);
        }
    }
}
