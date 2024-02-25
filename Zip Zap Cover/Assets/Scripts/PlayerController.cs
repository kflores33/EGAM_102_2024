using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public HingeJoint2D joint;
    public bool useMotor;

    public Rigidbody2D rbJointOne;
    public Rigidbody2D rb;

    // at rest
    public float angleLimitsAtRest1;
    public float angleLimitsAtRest2;

    public float motorSpeedOnReleased;

    // on click
    public float angleLimitsOnClick1;
    public float angleLimitsOnClick2;

    public float motorSpeedOnClicked;

    public float force;
    public float newAngleDirection;
    public float ogAngleDirection;

    public float angleDirection;

    public enum ClickStates
    {
        Start,
        Released,   
        Clicked,    
    }

    public ClickStates currentState;

    // Start is called before the first frame update
    void Start()
    {
        //var hinge = GetComponent<HingeJoint2D>();
        //var motor = hinge.motor;
        rb.simulated = false;
        rbJointOne.simulated = false;

        currentState = ClickStates.Start;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case ClickStates.Start:
                UpdateStart();
                break;
            case ClickStates.Released:
                UpdateReleased();
                break;
            case ClickStates.Clicked:
                UpdateClicked();
                break;
        }
    }
    private void UpdateStart()
    {
        rb.simulated = false;
        rbJointOne.simulated = false;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.simulated = true;
            rbJointOne.simulated = true;

            var direction = angleDirection;

            rb.velocity = Vector2.up * force;
            rbJointOne.velocity = Vector2.up * force;

            rb.AddForce(new Vector2(direction, force));
            rbJointOne.AddForce(new Vector2(direction, force));

            currentState = ClickStates.Clicked;
        }
    }
    private void UpdateReleased()
    {
        HingeJoint2D hinge = GetComponent<HingeJoint2D>();
        var motor = hinge.motor;

        // set motor speed
        motor.motorSpeed = motorSpeedOnReleased;

        // set angle limit
        JointAngleLimits2D limits = hinge.limits;
        limits.min = angleLimitsAtRest1;
        limits.max = angleLimitsAtRest2;
        hinge.limits = limits;
        hinge.useLimits = true;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            var direction = angleDirection;

            rb.velocity = Vector2.up * force;
            rbJointOne.velocity = Vector2.up * force;

            rb.AddForce(new Vector2(direction, force));
            rbJointOne.AddForce(new Vector2(direction, force));

            currentState = ClickStates.Clicked;
        }
    }
    private void UpdateClicked()
    {
        HingeJoint2D hinge = GetComponent<HingeJoint2D>();
        var motor = hinge.motor;

        // set motor speed
        motor.motorSpeed = motorSpeedOnClicked;

        // set angle limit
        JointAngleLimits2D limits = hinge.limits;
        limits.min = angleLimitsOnClick1;
        limits.max = angleLimitsOnClick2;
        hinge.limits = limits;
        hinge.useLimits = true;

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            
            currentState = ClickStates.Released;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            angleDirection = newAngleDirection;
        }
        if (collision.gameObject.CompareTag("SwapTrigger"))
        {
            angleDirection = ogAngleDirection;
        }
    }
}
