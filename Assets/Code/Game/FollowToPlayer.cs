
using UnityEngine;

public sealed class FollowToPlayer : MonoBehaviour
{
   Transform _player;
    void Start()
    {
        _player =FindObjectOfType<PlayerProvider>().transform;
    }

  
    void LateUpdate()
    {
     transform.position= transform.position.Change(x: _player.position.x);
    }
}
