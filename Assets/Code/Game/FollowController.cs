using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    private Transform _target;
    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
       GameObject.FindObjectOfType<PlayerProvider>().TryGetComponent<Transform>(out _target);
        _offset = transform.position - _target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * 1.0f);
    }
}
