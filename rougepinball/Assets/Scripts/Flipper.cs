using UnityEngine;

public class Flipper : MonoBehaviour
{
    public HingeJoint2D hinge;

    public float upSpeed = 3000f;
    public float downSpeed = -2000f;
    public float torque = 5000f;

    void Awake()
    {
        if (hinge == null)
            hinge = GetComponent<HingeJoint2D>();
    }

    public void FlipUp()
    {
        JointMotor2D motor = hinge.motor;
        motor.motorSpeed = upSpeed;
        motor.maxMotorTorque = torque;

        hinge.motor = motor;
        hinge.useMotor = true;
    }

    public void FlipDown()
    {
        JointMotor2D motor = hinge.motor;
        motor.motorSpeed = downSpeed;
        motor.maxMotorTorque = torque;

        hinge.motor = motor;
        hinge.useMotor = true;
    }
}