using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteController : IDisposable, IInitialisation
{

    private Vector3 _startPosition;
    private PlayerProvider _characterView;
    private List<LevelObjectView> _deathZones;
    private List<LevelObjectView> _winZones;
    private PlayerLiveDisplay _playerliveDisplay;
    public LevelCompleteController(PlayerProvider characterView,
    List<LevelObjectView> deathZones, List<LevelObjectView> winZones, PlayerLiveDisplay playerLiveDisplay)
    {
        _startPosition = characterView.transform.position;
        characterView.OnLevelObjectContact += OnLevelObjectContact;
        _characterView = characterView;
        _deathZones = deathZones;
        _winZones = winZones;
        _playerliveDisplay = playerLiveDisplay;
    }
    private void OnLevelObjectContact(LevelObjectView contactView)
    {
        if (_deathZones.Contains(contactView))
        {
            GetDamage(ref contactView);

        }
        if (_winZones.Contains(contactView))
        {
            _characterView.transform.position = _startPosition;
            Debug.LogError($"Yoy Win");
        }
    }

    private void GetDamage(ref LevelObjectView contactView)
    {
        if (_characterView.PlayerLive <= 1)
        {
            GetDeath(contactView);
        }
        else
        {
            _characterView.PlayerLive -= 1;
            _playerliveDisplay.UpdatePlayerLife(_characterView.PlayerLive);
            _characterView.transform.position = _startPosition;

        }
    }

    private void GetDeath(LevelObjectView contactView)
    {

        Debug.LogError($"Yoy killed by {contactView.gameObject.name}");
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Dispose()
    {
        _characterView.OnLevelObjectContact -= OnLevelObjectContact;

    }

    public void Initialization()
    {

    }
}


