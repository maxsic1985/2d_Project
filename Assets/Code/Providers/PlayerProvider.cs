
using UnityEngine;

public class PlayerProvider : MonoBehaviour
{
    public float PlayerAcceleration = -5;
    public float PlayerMoveTresh = 0.01f;
    public float PlayerFlyTresh = 1f;
    public float PlayerGroundLevel = 0.1f;
    public float PlayerWalkSpeed = 2;
    public float PlayerJumpStartSpeed = 2;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
}
