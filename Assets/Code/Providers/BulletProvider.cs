using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProvider : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public void SetVisible(bool visible)
    {
        _spriteRenderer.enabled = visible;
    }
}
