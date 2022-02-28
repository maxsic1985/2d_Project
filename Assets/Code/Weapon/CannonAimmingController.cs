using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAimmingController : IExecute
{
    private Transform _cannonTransform;
    private Transform _targetAimTransform;

    public CannonAimmingController(Transform muzzleTransform, Transform aimTransform)
    {
        _cannonTransform = muzzleTransform;
        _targetAimTransform = aimTransform;
    }

    public void Execute(float deltaTime)
    {
      //  float angle;
       // Vector3 axis;
        //GetAxisOfRotation(out angle, out axis);
        var axisOfRotation = GetAxisOfRotation();
        _cannonTransform.rotation = Quaternion.AngleAxis(axisOfRotation.angle, axisOfRotation.axis);
    }

    //private void GetAxisOfRotation(out float angle, out Vector3 axis)
    //{
    //    var dir = _targetAimTransform.position - _cannonTransform.position;
    //    angle = Vector3.Angle(-Vector3.left, dir);
    //    axis = Vector3.Cross(-Vector3.left, dir);
    //}



    (float angle, Vector3 axis) GetAxisOfRotation()
    {
        var dir = _targetAimTransform.position - _cannonTransform.position;
        var result = (angle: Vector3.Angle(-Vector3.left, dir), axis: Vector3.Cross(-Vector3.left, dir));   
        return result;
    }

}
