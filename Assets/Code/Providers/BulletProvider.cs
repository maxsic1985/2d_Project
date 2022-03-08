using UnityEngine;

public class BulletProvider : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public float BulletAcceleration = -5;
    public float BulletRadius = 0.01f;
    public float BulletGroundLevel = -0.4f;

    public Transform Transform;
    public Rigidbody2D Rigidbody2D;
    public CircleCollider2D CircleCollider2D;


    public void SetVisible(bool visible)
    {
        _spriteRenderer.enabled = visible;
    }
}
