using UnityEngine;

public class PhysicsBullet
{
    private BulletProvider _view;
    public PhysicsBullet(BulletProvider view)
    {
        _view = view;
    }
    public BulletProvider View => _view;
    public void Throw(Vector3 position, Vector3 velocity)
    {
        View.gameObject.SetActive(true);
        View.Transform.position = position;
        View.Rigidbody2D.velocity = Vector2.zero;
        View.Rigidbody2D.angularVelocity = 0;
        View.Rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
    }
    public void Update(ObjectPool bulletPool)
    {

    }
}
