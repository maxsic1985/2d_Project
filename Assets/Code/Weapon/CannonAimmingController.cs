using System.Collections.Generic;
using UnityEngine;

public class CannonAimmingController : IExecute
{
    private List<CannonProvider> _cannonTransform = new List<CannonProvider>();
    private Transform _targetAimTransform;
    public CannonAimmingController(List<CannonProvider> cannonTransform, Transform aimTransform)
    {
        _cannonTransform = cannonTransform;
        _targetAimTransform = aimTransform;
    }
    public void Execute(float deltaTime)
    {
        foreach (var cannon in _cannonTransform)
        {
            var axisOfRotation = GetAxisOfRotation(cannon.transform);
            cannon.transform.rotation = Quaternion.AngleAxis(axisOfRotation.angle, axisOfRotation.axis);
        }

    }
    (float angle, Vector3 axis) GetAxisOfRotation(Transform cannon)
    {
        var dir = _targetAimTransform.position - cannon.position;
        var result = (angle: Vector3.Angle(-Vector3.left, dir), axis: Vector3.Cross(-Vector3.left, dir));
        return result;
    }
}
