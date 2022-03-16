using UnityEngine;

public class BulletProvider : MonoBehaviour
{
    public float BulletAcceleration = -5;
    public float BulletRadius = 0.01f;
    public float BulletGroundLevel = -0.4f;
    public float ShootDelay =5f;
    public  float StartSpeed = 5f;

    public Transform Transform;
    public Rigidbody2D Rigidbody2D;
    public CircleCollider2D CircleCollider2D;

    private void Start()
    {
       
    }


}
