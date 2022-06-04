using UnityEngine;

public class LiftComponent : MonoBehaviour
{
    SliderJoint2D _sliderJoint2D;
    JointMotor2D _motor;

    void Start()
    {
        TryGetComponent<SliderJoint2D>(out _sliderJoint2D);
        _sliderJoint2D.useMotor = true;
        _motor = _sliderJoint2D.motor;
    }
    void FixedUpdate()
    {
        if (_sliderJoint2D.limitState == JointLimitState2D.LowerLimit)
        {
            SetMotorSpeed(0.4f);
        }
        else if (_sliderJoint2D.limitState == JointLimitState2D.UpperLimit)
        {
            SetMotorSpeed(-0.4f);
        }
    }

    private void SetMotorSpeed(float speed)
    {
        _motor.motorSpeed = speed;
        _sliderJoint2D.motor = _motor;

    }
}
