using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

    public PlayerSound playerSound;

    public Rigidbody rb;

    public float accel;
    public float breakForce;
    public float maxTurnAngle;

    private float currAccel = 0f;
    private float currBreakForce = 0f;
    private float currTurnAngle;


    private void FixedUpdate(){

        currAccel = accel * Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.S))
            currBreakForce = breakForce;
        else
            currBreakForce = 0f;

        frontRight.motorTorque = currAccel;
        frontLeft.motorTorque = currAccel;

        frontRight.brakeTorque = currBreakForce;
        frontLeft.brakeTorque = currBreakForce;
        backRight.brakeTorque = currBreakForce;
        backLeft.brakeTorque = currBreakForce;

        currTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currTurnAngle;
        frontRight.steerAngle = currTurnAngle;
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
            Time.fixedDeltaTime = .02f;

        if(frontRight.isGrounded | backLeft.isGrounded)
            playerSound.Grounding(true);
        else    
            playerSound.Grounding(false);
    }
}
