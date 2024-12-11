using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public HingeJoint2D leftFlipper; 
    public HingeJoint2D rightFlipper;

    public KeyCode leftFlipperKey = KeyCode.A;
    public KeyCode rightFlipperKey = KeyCode.D;

    private JointMotor2D leftMotor;
    private JointMotor2D rightMotor;

    void Start()
    {
        leftMotor = leftFlipper.motor;
        rightMotor = rightFlipper.motor;
    }

    void Update()
    {
        if (Input.GetKey(leftFlipperKey))
        {
            Debug.Log("Left flipper activated!");
            leftMotor.motorSpeed = -1000f;
            leftFlipper.motor = leftMotor;
        }
        else
        {
            leftMotor.motorSpeed = 2000f;
            leftFlipper.motor = leftMotor;
        }
        if (Input.GetKey(rightFlipperKey))
        {
            Debug.Log("Right flipper activated!");
            rightMotor.motorSpeed = 1000f;
            rightFlipper.motor = rightMotor;
        }
        else
        {
            rightMotor.motorSpeed = -2000f;
            rightFlipper.motor = rightMotor;
        }
    }
}
