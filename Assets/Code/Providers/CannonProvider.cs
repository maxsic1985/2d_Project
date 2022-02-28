using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProvider : MonoBehaviour
{
    [SerializeField]
    private Transform _cannonTransform;

    public Transform CannonTransform => _cannonTransform;
}
