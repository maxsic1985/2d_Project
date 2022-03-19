using UnityEngine;

public class EnemyProvider : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;
}
