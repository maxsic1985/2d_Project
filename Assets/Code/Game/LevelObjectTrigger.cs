using System;
using UnityEngine;

public class LevelObjectTrigger : MonoBehaviour
{
    public Action<GameObject> TriggerEnter;
    public Action<GameObject> TriggerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerProvider>(out PlayerProvider playerProvider) )
            TriggerEnter?.Invoke(other.gameObject);
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerProvider>(out PlayerProvider playerProvider))
            TriggerExit?.Invoke(other.gameObject);
    }
}
