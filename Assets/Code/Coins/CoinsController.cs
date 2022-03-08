using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinsController : IDisposable,IExecute,IInitialisation
{
  
    private PlayerProvider _characterView;
    private List<LevelObjectView> _coinViews;
    public CoinsController(PlayerProvider characterView, List<LevelObjectView>
    coinViews)
    {
        _characterView = characterView;
        _coinViews = coinViews;
        _characterView.OnLevelObjectContact += OnLevelObjectContact;
      
    }
    private void OnLevelObjectContact(LevelObjectView contactView)
    {
        if (_coinViews.Contains(contactView))
        {
       
            GameObject.Destroy(contactView.gameObject);
        }
    }
    public void Dispose()
    {
        _characterView.OnLevelObjectContact -= OnLevelObjectContact;
    }

    public void Execute(float deltaTime)
    {
       
    }

    public void Initialization()
    {
      
    }
}
