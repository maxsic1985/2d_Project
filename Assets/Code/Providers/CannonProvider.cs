using UnityEngine;

public class CannonProvider : MonoBehaviour
{
    [SerializeField]
    private Transform _cannonTransform;
    public Transform CannonTransform => _cannonTransform;
}
