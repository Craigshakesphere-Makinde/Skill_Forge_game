using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    [SerializeField] private float thrustForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float steerForce;

    private float currentThrust;
    private float currentBrakeForce;
    private float currentSteerForce;

    private float horizontalInput;
    private float verticalInput;

    private bool isBreaking;


    [SerializeField] private WheelCollider frontLeftWheel;
    [SerializeField] private WheelCollider frontRightWheel;
    [SerializeField] private WheelCollider rearLeftWheel;
    [SerializeField] private WheelCollider rearRightWheel;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    // Start is called before the first frame update
    
    void Update()
    {
        MyInput();
        HandleMotors();
        HandleSteering();
        UpdateWheel();
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKeyDown(KeyCode.Space);


    }

    private void HandleMotors()
    {

        currentThrust= thrustForce*verticalInput;
        Debug.Log(currentThrust);
        rearLeftWheel.motorTorque = currentThrust;
        rearRightWheel.motorTorque = currentThrust;
        currentBrakeForce = isBreaking ? brakeForce : 0f;
        ApplyBraking();


    }

    private void ApplyBraking()
    {
        frontLeftWheel.brakeTorque = currentBrakeForce;
        frontRightWheel.brakeTorque=currentBrakeForce;
        rearRightWheel.brakeTorque=-currentBrakeForce;
        rearLeftWheel.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        currentSteerForce= steerForce*horizontalInput*Time.deltaTime;
        frontLeftWheel.steerAngle = currentSteerForce;
        frontRightWheel.steerAngle = currentSteerForce;
    }

    private void UpdateWheel()
    {
        UpdateSingleWheel(frontRightWheel, frontRightWheelTransform);
        UpdateSingleWheel(frontLeftWheel, frontLeftWheelTransform);
        UpdateSingleWheel(rearLeftWheel, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheel, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheel, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheel.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;


    }

    
}
