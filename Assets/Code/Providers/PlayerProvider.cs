
using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerProvider : MonoBehaviour
{
    public float PlayerAcceleration = -5;
    public float PlayerMoveTresh = 0.01f;
    public float PlayerFlyTresh = 1f;
    public float PlayerGroundLevel = 0.1f;
    public float PlayerWalkSpeed = 2;
    public float PlayerJumpStartSpeed = 2;
    public int PlayerCoins = 0;
    public int PlayerLive = 3;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Collider2D _collider;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public Collider2D Collider => _collider;
    public Rigidbody2D Rigidbody => _rigidbody;
    public Action<LevelObjectView> OnLevelObjectContact { get; set; }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var levelObject = collider.gameObject.GetComponent<LevelObjectView>();
        OnLevelObjectContact?.Invoke(levelObject);
     
    }
}
