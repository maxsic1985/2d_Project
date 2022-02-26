
using UnityEngine;

public class PlayerProvider : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;
}
