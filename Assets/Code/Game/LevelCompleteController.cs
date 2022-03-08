using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteController : IDisposable,IInitialisation
{
  
private Vector3 _startPosition;
    private PlayerProvider _characterView;
    private List<LevelObjectView> _deathZones;
    private List<LevelObjectView> _winZones;
    public LevelCompleteController(PlayerProvider characterView,
    List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
    {
        _startPosition = characterView.transform.position;
        characterView.OnLevelObjectContact += OnLevelObjectContact;
        _characterView = characterView;
        _deathZones = deathZones;
        _winZones = winZones;
    }
    private void OnLevelObjectContact(LevelObjectView contactView)
    {
        if (_deathZones.Contains(contactView))
        {
            Time.timeScale = 0f;
        }
        if (_winZones.Contains(contactView))
        {
            _characterView.transform.position = _startPosition;
        }
    }
    public void Dispose()
    {
        _characterView.OnLevelObjectContact -= OnLevelObjectContact;
    }

    public void Initialization()
    {
       
    }
}


